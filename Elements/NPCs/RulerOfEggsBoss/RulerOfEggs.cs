using System;
using System.IO;
using Eggpack.Common.Systems;
using Eggpack.Elements.Items;
using Eggpack.Elements.Items.Bags;
using Eggpack.Elements.Items.Tiles;
using Eggpack.Elements.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.NPCs.RulerOfEggsBoss;

[AutoloadBossHead]
public class RulerOfEggs : ModNPC
{
	/// <summary>
	/// How far away the boss will be from the player during the Dash subphase.
	/// </summary>
	private const int DashRadius = 350;
	/// <summary>
	/// How far away the boss will be from the player during the Shards subphase.
	/// </summary>
	private const int ShardsRadius = 450;
	/// <summary>
	/// How horizontally far away the boss will be from the player during the Summon subphase.
	/// </summary>
	private const int SummonRadius = 250;
	/// <summary>
	/// How high the boss will be during the Summon subphase.
	/// </summary>
	private const int SummonDistUp = 300;
	/// <summary>
	/// How far away the boss will be from the player during the Bursts subphase.
	/// </summary>
	private const int BurstsRadius = 450;

	/// <summary>
	/// The boss' attack patterns. The subphases are picked randomly and a subphase cannot repeat twice in a row.
	/// </summary>
	private enum Subphases
	{
		/// <summary>
		/// Goes at a random angle of the targeted player and dashes at it.
		/// </summary>
		Dash,
		/// <summary>
		/// Goes to the left or right side of a targeted player then throws 9 (EX: 13) yolk shards at it.
		/// </summary>
		Shards,
		/// <summary>
		/// Goes to the top left or top right of a targeted player, then goes to the other side while summoning 7 buffed Wild Eggs.
		/// </summary>
		Summon,
		/// <summary>
		/// Goes to the left of a targeted player, makes a large counterclockwise circle around it while summoning 16 (EX: 20) yolk bursts that slowly charge at the center
		/// </summary>
		Bursts,

		// misc
		/// <summary>
		/// The boss is in the one-second spawning stage where it goes above the player.
		/// </summary>
		Spawn,
		/// <summary>
		/// The boss is currently inbetween subphases and is requesting a randomize.
		/// </summary>
		Randomize,
	}

	private bool Enraged
	{
		get => NPC.ai[0] / 2 == Math.Floor((NPC.ai[0] / 2) + 0.001);
		set => NPC.ai[0] = Enraged ? (value ? NPC.ai[0] : NPC.ai[0] - 1) : (value ? NPC.ai[0] + 1 : NPC.ai[0]);
	}
	/// <summary>
	/// The current state of the boss.
	/// </summary>
	private float Subphase
	{
		get => (float)Math.Ceiling(NPC.ai[0] / 2);
		set => NPC.ai[0] += (value - Subphase) * 2;
	}
	/// <summary>
	/// Used for a different thing in each subphase. For Dash and Bursts it's the angle around the player and for Shards and Summon it's left/right.
	/// </summary>
	private float Direction
	{
		get => NPC.ai[1];
		set => NPC.ai[1] = value;
	}
	/// <summary>
	/// The number of elapsed ticks since the start of the subphase.
	/// </summary>
	private float Timer
	{
		get => NPC.ai[2];
		set => NPC.ai[2] = value;
	}
	/// <summary>
	/// The number of Loyal Eggs/Yolk Bursts that have been summoned this subphase. Used for Summon and Bursts.
	/// </summary>
	private float Summoned
	{
		get => NPC.ai[3];
		set => NPC.ai[3] = value;
	}

	private Vector2 TargetVector;
	private Vector2 TargetLocation;
	private Vector2 SummonStartLocation;
	private bool CanHit = true;
	private int LastSubphase;

	public override void SetStaticDefaults()
	{
		NPCID.Sets.MPAllowedEnemies[Type] = true;

		NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
		NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Shimmer] = true;
	}
	public override void SetDefaults()
	{
		NPC.width = 142;
		NPC.height = 179;
		NPC.damage = 30;
		NPC.defense = 10;
		NPC.lifeMax = 4000;
		NPC.DeathSound = SoundID.NPCDeath1;
		NPC.knockBackResist = 0f;
		NPC.noGravity = true;
		NPC.noTileCollide = true;
		NPC.value = 50000;
		NPC.boss = true;
		NPC.npcSlots = 10f;
		NPC.aiStyle = -1;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;

		if (!Main.dedServ)
		{
			Music = MusicID.Boss3;
		}
	}

	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		LeadingConditionRule notExpertRule = new(new Conditions.NotExpert());

		notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<YolkShard>(), 1, 3, 5));
		notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Yolkifier>()));

		npcLoot.Add(notExpertRule);

		npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<RulerOfEggsBag>()));
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		bestiaryEntry.Info.AddRange([
			new FlavorTextBestiaryInfoElement("As the democratically-chosen emperor of the Empire of Eggs, he seeks to punish those who treat the eggs in brutal ways.")
		]);
	}

	public override void OnSpawn(IEntitySource source)
	{
		Subphase = (float)Subphases.Spawn;
		LastSubphase = 4;
	}
	public override void OnKill()
	{
		NPC.SetEventFlagCleared(ref DownedBossSystem.downedRulerOfEggs, -1);
	}

	public override void AI()
	{
		if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
		{
			NPC.TargetClosest(); // target closest player
		}
		Player player = Main.player[NPC.target];

		if (player.dead) // flee and despawn if everyone is dead
		{
			NPC.velocity.X -= 0.05f;
			NPC.EncourageDespawn(10);
			return;
		}

		if (Subphase == (float)Subphases.Spawn)
		{
			StartSpawning(player);
		}

		// check for 2nd phase
		float Phase2HP = 0.5f; // transform into phase 2 at 50% hp
		if (NPC.life <= NPC.lifeMax * Phase2HP) Enraged = true;

		if (Subphase == (float)Subphases.Randomize)
		{
			Timer = 0;
			RandomizeSubphase();
		}

		DoSubphase(player);
	}

	private void RandomizeSubphase()
	{
		if (LastSubphase == 4) Subphase = Main.rand.Next(4);
		else Subphase = (LastSubphase + Main.rand.Next(1, 4)) % 4;
		LastSubphase = (int)Subphase;
		StartSubphase();
	}
	private void StartSubphase()
	{
		Timer = 0;
		Summoned = 0;
		NPC.velocity = Vector2.Zero;

		switch ((Subphases)Subphase)
		{
			case Subphases.Dash:
				Direction = Main.rand.NextFloat() * MathHelper.TwoPi;
				break;
			case Subphases.Shards:
			case Subphases.Summon:
				Direction = Main.rand.NextBool() ? 1 : -1;
				break;
			case Subphases.Bursts:
				Direction = 0;
				break;
			default:
				break;
		}
		if (Main.dedServ) NPC.netUpdate = true;
	}
	private void DoSubphase(Player player)
	{
		switch ((Subphases)Subphase)
		{
			case Subphases.Dash:
				DoSubphase_Dash(player);
				break;
			case Subphases.Shards:
				DoSubphase_Shards(player);
				break;
			case Subphases.Summon:
				DoSubphase_Summon(player);
				break;
			case Subphases.Bursts:
				DoSubphase_Bursts(player);
				break;
			default:
				break;
		}
	}

	private void StartSpawning(Player player)
	{
		if (Subphase != (float)Subphases.Spawn) return;

		TargetVector = player.Center - NPC.Center - new Vector2(0, NPC.height * 1.5f);
		Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

		if (TargetVector.Length() < 1000) Timer++;

		float speed = Math.Min(60, TargetVector.Length() / 28);
		NPC.velocity = moveVector * speed;

		if (Timer == 90)
		{
			NPC.velocity = Vector2.Zero;
			Subphase = (float)Subphases.Randomize;
		}
		else
		{
			Subphase = (float)Subphases.Spawn;
		}
	}

	private void DoSubphase_Dash(Player player)
	{
		Timer++;
		CanHit = Timer > 75;

		if (Timer < 75) // align on a random point on a circle near the player
		{
			TargetVector = player.Center - NPC.Center + CreateNormalizedVector(Direction) * DashRadius;
			Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

			float speed = Math.Min(15, TargetVector.Length() / 12);
			NPC.velocity = moveVector * speed;
		}
		else if (Timer == 75) // target: dash through the player and onto the opposite side of the circle
		{
			TargetVector = player.Center - NPC.Center;
			TargetLocation = player.Center * 2 - NPC.Center; // on the opposite side of the player as the boss is right now
		}
		else if (Timer < 180) // dash through the player
		{
			Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

			float speed = Math.Min(20, (TargetLocation - NPC.Center).Length() / 15);
			NPC.velocity = moveVector * speed;
		}
		else // subphase over, randomize it again
		{
			Subphase = (float)Subphases.Randomize;
		}
	}
	private void DoSubphase_Shards(Player player)
	{
		Timer++;
		CanHit = Timer > 75;

		// move either to the left or to the right of the player
		TargetVector = player.Center - NPC.Center + new Vector2(Direction, 0) * ShardsRadius;
		Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

		float speed = Math.Min(20 - Timer * 0.08f, TargetVector.Length() / (12 + Timer * 0.5f));
		NPC.velocity = moveVector * speed;

		if (Timer == 75 && Main.netMode != NetmodeID.MultiplayerClient) // shoot 9 yolk blasts
		{
			for (int y = -5; y <= 3; y++)
			{
				Projectile.NewProjectile(
					NPC.GetSource_FromAI(),
					NPC.Center,
					new(Direction * -9, y * 2),
					ModContent.ProjectileType<YolkShardProjectile>(),
					20,
					4
				);
			}
		}
		else if (Timer >= 180) // subphase over, randomize it again
		{
			Subphase = (float)Subphases.Randomize;
		}
	}
	private void DoSubphase_Summon(Player player)
	{
		Timer++;
		CanHit = Timer > 75;

		if (Timer < 75) // move either to the top left or to the top right of the player
		{
			TargetVector = player.Center - NPC.Center + new Vector2(Direction * SummonRadius, -SummonDistUp);
			Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

			float speed = Math.Min(15, TargetVector.Length() / 12);
			NPC.velocity = moveVector * speed;
		}
		else if (Timer == 75) // target: go on the opposite side of the player, horizontally
		{
			TargetVector = new((player.Center.X - NPC.Center.X) * 2, 0);
			TargetLocation = NPC.Center + new Vector2((player.Center.X - NPC.Center.X) * 2, 0); // go left if boss is to the right of the player and vice versa
			SummonStartLocation = NPC.Center;
		}
		else if (Timer < 180) // move to the opposite side, summoning buffed Wild Eggs in the process
		{
			Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

			float speed = Math.Min(15, (TargetLocation - NPC.Center).Length() / 12);
			NPC.velocity = moveVector * speed;

			float percent = ReverseClamp(SummonStartLocation.X, TargetLocation.X, NPC.Center.X);
			if (Summoned / 3 + 1f / 6 < percent && percent < 1) // if its time to summon an egg
			{
				Summoned++;

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					NPC.NewNPC(
						NPC.GetSource_FromAI(),
						(int)NPC.Center.X,
						(int)NPC.Center.Y,
						ModContent.NPCType<LoyalEgg>()
					);
				}
			}
		}
		else // subphase over, randomize it again
		{
			Subphase = (float)Subphases.Randomize;
		}
	}
	private void DoSubphase_Bursts(Player player)
	{
		Timer++;
		CanHit = Timer > 75;

		if (Timer < 75) // move to the left of the player
		{
			TargetVector = player.Center - NPC.Center - new Vector2(BurstsRadius, 0);
			Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

			float speed = Math.Min(30, TargetVector.Length() / 10);
			NPC.velocity = moveVector * speed;
		}
		else if (Timer == 75) // set target location as the center of the circle
		{
			TargetLocation = NPC.Center + new Vector2(BurstsRadius, 0);
		}
		else if (Timer < 210) // move along a circle
		{
			float remaining = MathHelper.TwoPi - Direction;
			float percent = Direction / MathHelper.TwoPi;
			float divide = 0.002f * (Timer - 180) * (Timer - 180) + 10;

			Direction += Math.Min(MathHelper.TwoPi / 70, remaining / divide);

			Vector2 circleVector = CreateNormalizedVector(Direction) * BurstsRadius;
			circleVector.X *= -1;
			NPC.Center = TargetLocation + circleVector;

			if (Summoned / 16 < percent) // if its time to summon a burst
			{
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					Vector2 pos = CreateNormalizedVector(Summoned / 16 * MathHelper.TwoPi) * BurstsRadius;
					pos.X *= -1;
					pos += TargetLocation;

					Projectile.NewProjectile(
						NPC.GetSource_FromAI(),
						pos,
						Vector2.Zero,
						ModContent.ProjectileType<YolkBurst>(),
						20,
						2,
						-1,
						pos.X + (TargetLocation.X - pos.X) * 2,
						pos.Y + (TargetLocation.Y - pos.Y) * 2,
						BurstsRadius * 2
					);
				}
				Summoned++;
			}
		}
		else // subphase over, randomize it again
		{
			Subphase = (float)Subphases.Randomize;
		}
	}

	public override bool CanHitPlayer(Player target, ref int cooldownSlot) => CanHit;

	public override void SendExtraAI(BinaryWriter writer)
	{
		writer.WriteVector2(TargetVector);
		writer.WriteVector2(TargetLocation);
		writer.WriteVector2(SummonStartLocation);
		writer.Write7BitEncodedInt(LastSubphase);
	}
	public override void ReceiveExtraAI(BinaryReader reader)
	{
		TargetVector = reader.ReadVector2();
		TargetLocation = reader.ReadVector2();
		SummonStartLocation = reader.ReadVector2();
		LastSubphase = reader.Read7BitEncodedInt();
	}

	/// <summary>
	/// Helper method that returns a normalized vector based on the angle in radians. Used for the Dash and Bursts subphases.
	/// </summary>
	/// <param name="angleInRadians">Angle in radians.</param>
	/// <returns>The vector.</returns>
	private Vector2 CreateNormalizedVector(float angleInRadians)
	{
		// Calculate the x and y components
		float x = (float)Math.Cos(angleInRadians);
		float y = (float)Math.Sin(angleInRadians);

		// Create and return the normalized Vector2
		return new Vector2(x, y);
	}
	public static float ReverseClamp(float min, float max, float value)
	{
		return (value - min) / (max - min);
	}
}