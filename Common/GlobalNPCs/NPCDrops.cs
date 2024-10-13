using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Eggpack.Elements.Weapons.Melee.Yoyos;

namespace Eggpack.Common.GlobalNPCs
{
	public class NPCDrops : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			List<int> hyperboreanDrop = [NPCID.IceBat, NPCID.SnowFlinx, NPCID.SpikedIceSlime, NPCID.UndeadViking];

			if (hyperboreanDrop.Contains(npc.type))
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Hyperborean>(), 60));
			}
		}
	}
}