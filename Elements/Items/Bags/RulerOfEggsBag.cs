using Eggpack.Elements.Items.Tiles;
using Eggpack.Elements.NPCs.RulerOfEggsBoss;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Items.Bags
{
	public class RulerOfEggsBag : ModItem
	{
		public override bool CanRightClick() => true;

		public override void SetStaticDefaults()
		{
			ItemID.Sets.BossBag[Type] = true;
			ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;

			Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults() {
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Purple;
			Item.expert = true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot)
		{
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<YolkShard>(), 1, 1, 3));
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Yolkifier>()));
			itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<RulerOfEggs>()));
		}
	}
}
