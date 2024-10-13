using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Items
{
	public class ThingiteBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Elements.Tiles.Ore.ThingiteBarTile>());
			Item.width = 12;
			Item.height = 12;
			Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 30, 0));
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient<ThingiteOre>(4)
			.AddTile(TileID.Furnaces)
			.Register();
		}
	}
}