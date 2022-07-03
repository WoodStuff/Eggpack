using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.NPCs.RulerOfAllEggs
{
	public class RulerOfAllEggs : ModNPC
	{
		private enum Subphases
        {
			// phase 1 - alternates between the subphases
			Rain, // goes on the top left or top right of a targeted player, rains buffed wild eggs at them for 10 seconds
			Charge, // dashes at the player 4-6 times, in expert mode the dashes are faster and does 5-8 dashes

			// phase 2 - picks a subphase randomly, a subphase cannot repeat twice in a row
			Dash, // goes on a random angle of the targeted player and dashes at them, in expert mode also dashes back at them
			Shards, // goes on the left or right side of a targeted player then throws 9 (13 in expert mode) yolk shards at them
			Summon, // goes to above and a bit to the left or right of a targeted player, then goes right or left respectively while summoning 7 buffed wild eggs
			Bursts, // goes to the left of a targeted player, makes a large counterclockwise circle around them while summoning 12 (16 in expert mode) yolk bursts that slowly charge at the center
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruler of All Eggs");
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
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				new FlavorTextBestiaryInfoElement("")
			});
		}

		public bool SecondPhase
		{
			get => NPC.ai[0] / 2 == Math.Floor((NPC.ai[0] / 2) + 0.001);
			set => NPC.ai[0] = (SecondPhase ? (value ? NPC.ai[0] : NPC.ai[0] - 1) : (value ? NPC.ai[0] + 1 : NPC.ai[0]));
		}
		public float Subphase
		{
			get => (float)Math.Ceiling(NPC.ai[0] / 2);
			set => NPC.ai[0] += (value - Subphase) * 2;
		}

		private bool Spawned = false;
		private bool DoingPhase1 = false;

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

			if (!SecondPhase)
            {
				Phase1();
            }
		}

		private void Phase1()
        {
			if (!Spawned)
            {
				Spawned = true;
            }
        }
	}
}