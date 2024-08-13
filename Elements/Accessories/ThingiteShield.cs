using Eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Eggpack.Elements.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ThingiteShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.defense = 3;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(null, "ThingiteBar", 7)
			.AddRecipeGroup(RecipeGroupID.Wood, 25)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}