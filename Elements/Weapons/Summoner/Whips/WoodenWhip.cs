using Eggpack.Elements.Weapons.Summoner.Whips.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Summoner.Whips
{
	public class WoodenWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<WoodenWhipProjectile>(), 11, 0.5f, 2);

			Item.rare = ItemRarityID.White;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(RecipeGroupID.Wood, 20);
			recipe.AddIngredient(ItemID.Cobweb, 20);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}