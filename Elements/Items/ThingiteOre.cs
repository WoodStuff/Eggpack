using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Items
{
	public class ThingiteOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Elements.Tiles.Ore.ThingiteOreTile>());
			Item.width = 12;
			Item.height = 12;
			Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 7, 50));
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddRecipeGroup("SilverOre")
			.AddRecipeGroup("GoldOre")
			.AddTile(TileID.WorkBenches)
			.Register();
		}
	}
}