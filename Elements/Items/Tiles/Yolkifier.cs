using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Enums;

namespace Eggpack.Elements.Items.Tiles
{
	public class Yolkifier : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Elements.Tiles.Yolkifier>());
			Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 2));
			Item.width = 32;
			Item.height = 32;
		}

		public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
		{
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.CraftingObjects;
		}
	}
}
