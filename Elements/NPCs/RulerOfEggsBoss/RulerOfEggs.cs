using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.NPCs.RulerOfEggsBoss
{
	public class RulerOfEggs : ModNPC
	{
		private enum Subphases
		{
			// picks a subphase randomly, a subphase cannot repeat twice in a row
			Dash, // goes on a random angle of the targeted player and dashes at them, in expert mode also dashes back at them
			Shards, // goes on the left or right side of a targeted player then throws 9 (13 in expert mode) yolk shards at them
			Summon, // goes to above and a bit to the left or right of a targeted player, then goes right or left respectively while summoning 7 buffed wild eggs
			Bursts, // goes to the left of a targeted player, makes a large counterclockwise circle around them while summoning 12 (16 in expert mode) yolk bursts that slowly charge at the center

			// misc
			Spawn,
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ruler of Eggs");
		}
		public override void SetDefaults()
		{
			NPC.width = 296;
			NPC.height = 378;
			NPC.damage = 25;
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

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				new FlavorTextBestiaryInfoElement("")
			});
		}

		public bool Enraged
		{
			get => NPC.ai[0] / 2 == Math.Floor((NPC.ai[0] / 2) + 0.001);
			set => NPC.ai[0] = Enraged ? (value ? NPC.ai[0] : NPC.ai[0] - 1) : (value ? NPC.ai[0] + 1 : NPC.ai[0]);
		}
		public float Subphase
		{
			get => (float)Math.Ceiling(NPC.ai[0] / 2);
			set => NPC.ai[0] += (value - Subphase) * 2;
		}

		private Vector2 TargetLocation;

		/// <summary>
		/// Waits a second before attacking, this is true if it's doing that.
		/// </summary>
		private bool Spawning = true;

		private int SpawningTimer = 0;
		private int SubphaseTimer = 0;
		private int SubphaseTimer2 = 0;

		public override void AI()
		{
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
			{
				NPC.TargetClosest();
			}
			Player player = Main.player[NPC.target];

			if (player.dead)
			{
				// If the targeted player is dead, flee
				NPC.velocity.X -= 0.05f;
				// This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
				NPC.EncourageDespawn(10);
				return;
			}

			if (Spawning)
			{
				StartSpawning(player);
			}

			// check for 2nd phase
			float Phase2HP = 0.5f; // transform into phase 2 at 50% hp
			if (NPC.life <= NPC.lifeMax * Phase2HP) Enraged = true;

			DoSubphase(player);
		}

		private void StartSpawning(Player player)
		{
			if (!Spawning) return;

			TargetLocation = player.Center - NPC.Center - new Vector2(0, NPC.height * 0.75f);
			Vector2 toDestinationNormalized = TargetLocation.SafeNormalize(Vector2.UnitY);

			if (TargetLocation.Length() < 1000) SpawningTimer++;

			float speed = Math.Min(400, TargetLocation.Length());
			NPC.velocity = toDestinationNormalized * speed / 30;

			if (SpawningTimer == 90)
			{
				Spawning = false;
				RandomizeSubphase();
			}
			else
			{
				Subphase = (float)Subphases.Spawn;
			}
		}

		private void RandomizeSubphase()
		{
			float subphase = Subphase;
			subphase += Main.rand.Next(3) + 1;
			subphase %= 4;
			Subphase = subphase;
		}

		private void DoSubphase(Player player)
		{
			//Main.NewText((Subphases)Subphase);
			switch ((Subphases)Subphase)
			{
				case Subphases.Dash:
					DoSubphase_Dash(player);
					break;
				default:
					break;
			}
		}

		private bool Expert => Main.expertMode;


		private void DoSubphase_Dash(Player player)
		{
			double angle = Main.rand.NextDouble() * MathHelper.TwoPi;

		}
	}
}