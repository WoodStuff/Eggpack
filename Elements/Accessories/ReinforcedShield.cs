using Eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Eggpack.Elements.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ReinforcedShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 250000;
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.defense = 3;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Shackle)
			.AddIngredient<ThingiteShield>()
			.AddRecipeGroup(RecipeGroupID.IronBar, 6)
			.AddTile(TileID.TinkerersWorkbench)
			.Register();
		}
	}
}