using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Accessories
{
	public class WoodenCrosshair : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+2% critical strike chance");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 46;
			Item.height = 46;
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.Wood, 30)
				.AddTile(TileID.WorkBenches)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Generic) += 2f;
		}
	}
}