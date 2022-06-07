using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace eggpack
{
	public class eggpack : Mod
	{
		public override void AddRecipes()
		{
			// BAND OF REGENERATION
			CreateRecipe(ItemID.BandofRegeneration)
			.AddIngredient(ItemID.LifeCrystal)
			.AddRecipeGroup("EvilBars", 5)
			.Register();


			// MAGIC MIRROR (from 1.4.4 update)
			CreateRecipe(ItemID.MagicMirror)
			.AddIngredient(ItemID.FallenStar)
			.AddIngredient(ItemID.Glass, 5)
			.AddIngredient(ItemID.GoldBar, 8)
			.Register();

			CreateRecipe(ItemID.MagicMirror)
			.AddIngredient(ItemID.FallenStar)
			.AddIngredient(ItemID.Glass, 5)
			.AddIngredient(ItemID.PlatinumBar, 8)
			.Register();
		}
		public override void AddRecipeGroups()
		{
			// EVIL BARS
			RecipeGroup group = new(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bar", new int[]
			{
				ItemID.DemoniteBar,
				ItemID.CrimtaneBar,
			});
			RecipeGroup.RegisterGroup("EvilBars", group);

			// GEMS
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gem", new int[]
			{
				ItemID.Amethyst,
				ItemID.Topaz,
				ItemID.Sapphire,
				ItemID.Emerald,
				ItemID.Ruby,
				ItemID.Diamond,
				ItemID.Amber,
			});
			RecipeGroup.RegisterGroup("Gems", group);

			// TIER 3 ORE
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Ore", new int[]
			{
				ItemID.SilverOre,
				ItemID.TungstenOre,
			});
			RecipeGroup.RegisterGroup("Tier3Ore", group);

			// TIER 4 ORE
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Ore", new int[]
			{
				ItemID.GoldOre,
				ItemID.PlatinumOre,
			});
			RecipeGroup.RegisterGroup("Tier4Ore", group);
		}
	}
}