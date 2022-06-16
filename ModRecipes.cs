using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace eggpack
{
	public class ModRecipes : ModSystem
	{
		public override void AddRecipes()
		{
			// MACE
			Mod.CreateRecipe(ItemID.Mace)
				.AddIngredient(null, "ThingiteBar", 10)
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				.AddRecipeGroup(RecipeGroupID.Wood, 20)
				.AddTile(TileID.Anvils)
				.Register();

			// BAND OF REGENERATION
			Mod.CreateRecipe(ItemID.BandofRegeneration)
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.PanicNecklace)
				.AddIngredient(ItemID.PurificationPowder, 10)
				.AddTile(TileID.WorkBenches)
				.Register();

			Mod.CreateRecipe(ItemID.BandofRegeneration)
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.BandofStarpower)
				.AddIngredient(ItemID.PurificationPowder, 10)
				.AddTile(TileID.WorkBenches)
				.Register();

			// MAGIC MIRROR (from 1.4.4 update)
			Mod.CreateRecipe(ItemID.MagicMirror)
				.AddIngredient(ItemID.FallenStar)
				.AddIngredient(ItemID.Glass, 5)
				.AddRecipeGroup(ModRecipeGroup.GoldBar, 8)
				.Register();

			// ANKLET OF THE WIND
			Mod.CreateRecipe(ItemID.AnkletoftheWind)
				.AddIngredient(null, "SpeedRing")
				.AddIngredient(ItemID.JungleSpores, 20)
				.AddIngredient(ItemID.Amethyst, 5)
				.AddTile(TileID.Anvils)
				.Register();

			// SHADOW KEY
			Mod.CreateRecipe(ItemID.ShadowKey)
				.AddIngredient(ItemID.GoldenKey, 5)
				.AddRecipeGroup(ModRecipeGroup.EvilBar, 15)
				.AddIngredient(ItemID.Bone, 30)
				.AddTile(TileID.Anvils)
				.Register();

			// HAND WARMER
			Mod.CreateRecipe(ItemID.HandWarmer)
				.AddIngredient(ItemID.FlinxFur, 5)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}