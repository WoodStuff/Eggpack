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
    }
}
