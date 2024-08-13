using Eggpack.Elements.Items;
using Eggpack.Elements.Items.Bags;
using Eggpack.Elements.Projectiles;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.NPCs.RulerOfEggsBoss
{
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
			NPC.damage = 50;
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

			if (!Main.dedServ)
			{
				Music = MusicID.Boss3;
			}
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			LeadingConditionRule notExpertRule = new(new Conditions.NotExpert());

			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<YolkShard>(), 1, 1, 3));

			npcLoot.Add(notExpertRule);

			npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<RulerOfEggsBag>()));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange([
				new FlavorTextBestiaryInfoElement("As the democratically-chosen emperor of the Empire of Eggs, he seeks to punish those who treat the eggs in brutal ways.")
			]);
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
		/// Used for a different thing in each subphase. For Dash it's the angle around the player, and for Shards and Summon it's left/right.
		/// </summary>
		private float Variance
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

		private Vector2 TargetVector;
		private Vector2 TargetLocation;
		private int LastSubphase;

		public override void OnSpawn(IEntitySource source)
		{
			Subphase = (float)Subphases.Spawn;
			LastSubphase = 4;
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

		private void RandomizeSubphase()
		{
			if (LastSubphase == 4) Subphase = Main.rand.Next(2);
			else Subphase = (LastSubphase + Main.rand.Next(1, 2)) % 2;
			LastSubphase = (int)Subphase;
			StartSubphase();
		}

		private void StartSubphase()
		{
			Timer = 0;
			Main.NewText((Subphases)Subphase);
			switch ((Subphases)Subphase)
			{
				case Subphases.Dash:
					Variance = Main.rand.NextFloat() * MathHelper.TwoPi;
					break;
				case Subphases.Shards:
				case Subphases.Summon:
					Variance = Main.rand.NextBool() ? 1 : -1;
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
				default:
					break;
			}
		}

		private void DoSubphase_Dash(Player player)
		{
			Timer++;

			if (Timer < 75) // align on a random point on a circle near the player
			{
				TargetVector = player.Center - NPC.Center + CreateNormalizedVector(Variance) * DashRadius;
				Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

				float speed = Math.Min(15, TargetVector.Length() / 12);
				NPC.velocity = moveVector * speed;
			}
			else if (Timer == 75) // target: dash through the player and onto the opposite side of the circle
			{
				TargetVector = player.Center - NPC.Center;
				TargetLocation = player.Center * 2 - NPC.Center; // on the opposite side of the player as the boss is right now
			}
			else if (Timer < 150) // dash through the player
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

			// move either to the left or to the right of the player
			TargetVector = player.Center - NPC.Center + new Vector2(Variance, 0) * ShardsRadius;
			Vector2 moveVector = TargetVector.SafeNormalize(Vector2.UnitY);

			float speed = Math.Min(20 - Timer * 0.08f, TargetVector.Length() / (12 + Timer * 0.5f));
			Main.NewText(speed);
			NPC.velocity = moveVector * speed;

			if (Timer == 75) // shoot 9 yolk blasts
			{
				for (int y = -5; y <= 3; y++)
				{
					Projectile.NewProjectile(
						NPC.GetSource_FromAI(),
						NPC.Center,
						new(Variance * -9, y * 2),
						ModContent.ProjectileType<YolkShardProjectile>(),
						20,
						4
					);
				}
			}
			else if (Timer >= 150) // subphase over, randomize it again
			{
				Subphase = (float)Subphases.Randomize;
			}
		}
		private Vector2 CreateNormalizedVector(float angleInRadians)
		{
			// Calculate the x and y components
			float x = (float)Math.Cos(angleInRadians);
			float y = (float)Math.Sin(angleInRadians);

			// Create and return the normalized Vector2
			return new Vector2(x, y);
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.WriteVector2(TargetVector);
			writer.WriteVector2(TargetLocation);
			writer.Write7BitEncodedInt(LastSubphase);
		}
		public override void ReceiveExtraAI(BinaryReader reader)
		{
			TargetVector = reader.ReadVector2();
			TargetLocation = reader.ReadVector2();
			LastSubphase = reader.Read7BitEncodedInt();
		}
	}
}