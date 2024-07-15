using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Eggpack
{
	public class ModRecipes : ModSystem
	{
		public override void AddRecipes()
		{
			// MACE
			Recipe.Create(ItemID.Mace)
				.AddIngredient(null, "ThingiteBar", 10)
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				.AddRecipeGroup(RecipeGroupID.Wood, 20)
				.AddTile(TileID.Anvils)
				.Register();

			// BAND OF REGENERATION
			Recipe.Create(ItemID.BandofRegeneration)
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.PanicNecklace)
				.AddIngredient(ItemID.PurificationPowder, 10)
				.AddTile(TileID.WorkBenches)
				.Register();

			Recipe.Create(ItemID.BandofRegeneration)
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.BandofStarpower)
				.AddIngredient(ItemID.PurificationPowder, 10)
				.AddTile(TileID.WorkBenches)
				.Register();

			// ANKLET OF THE WIND
			Recipe.Create(ItemID.AnkletoftheWind)
				.AddIngredient(null, "SpeedRing")
				.AddIngredient(ItemID.JungleSpores, 20)
				.AddIngredient(ItemID.Amethyst, 5)
				.AddTile(TileID.Anvils)
				.Register();

			// SHADOW KEY
			Recipe.Create(ItemID.ShadowKey)
				.AddIngredient(ItemID.GoldenKey, 5)
				.AddRecipeGroup(ModRecipeGroup.EvilBar, 15)
				.AddIngredient(ItemID.Bone, 30)
				.AddTile(TileID.Anvils)
				.Register();

			// HAND WARMER
			Recipe.Create(ItemID.HandWarmer)
				.AddIngredient(ItemID.FlinxFur, 5)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}