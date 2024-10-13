using Eggpack.Elements.Accessories;
using Eggpack.Elements.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack
{
	public class ModRecipes : ModSystem
	{
		public override void AddRecipes()
		{
			// MACE
			Recipe.Create(ItemID.Mace)
				.AddIngredient<ThingiteBar>(10)
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
				.AddIngredient<SpeedRing>()
				.AddIngredient(ItemID.JungleSpores, 20)
				.AddIngredient(ItemID.Vine, 5)
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

			// THROWING KNIFE
			Recipe.Create(ItemID.ThrowingKnife, 50)
				.AddRecipeGroup(RecipeGroupID.IronBar)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}