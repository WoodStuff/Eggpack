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
			// MACE
			CreateRecipe(ItemID.Mace)
				.AddIngredient(null, "ThingiteBar", 10)
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				.AddRecipeGroup(RecipeGroupID.Wood, 20)
				.AddTile(TileID.Anvils)
				.Register();

			// BAND OF REGENERATION
			CreateRecipe(ItemID.BandofRegeneration)
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.PanicNecklace)
				.AddIngredient(ItemID.PurificationPowder, 10)
				.AddTile(TileID.WorkBenches)
				.Register();

			CreateRecipe(ItemID.BandofRegeneration)
				.AddIngredient(ItemID.LifeCrystal)
				.AddIngredient(ItemID.BandofStarpower)
				.AddIngredient(ItemID.PurificationPowder, 10)
				.AddTile(TileID.WorkBenches)
				.Register();

			// MAGIC MIRROR (from 1.4.4 update)
			CreateRecipe(ItemID.MagicMirror)
				.AddIngredient(ItemID.FallenStar)
				.AddIngredient(ItemID.Glass, 5)
				.AddRecipeGroup("GoldBar", 8)
				.Register();

			// ANKLET OF THE WIND
			CreateRecipe(ItemID.AnkletoftheWind)
				.AddIngredient(null, "SpeedRing")
				.AddIngredient(ItemID.JungleSpores, 20)
				.AddIngredient(ItemID.Amethyst, 5)
				.AddTile(TileID.Anvils)
				.Register();

			// SHADOW KEY
			CreateRecipe(ItemID.ShadowKey)
				.AddIngredient(ItemID.GoldenKey, 5)
				.AddRecipeGroup("EvilBars", 15)
				.AddIngredient(ItemID.Bone, 30)
				.AddTile(TileID.Anvils)
				.Register();
		}
		public override void AddRecipeGroups()
		{
			// GEMS
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gem", new int[]
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

			// ----------- BARS BELOW -----------

			// EVIL BARS
			group = new(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bar", new int[]
			{
				ItemID.DemoniteBar,
				ItemID.CrimtaneBar,
			});
			RecipeGroup.RegisterGroup("EvilBars", group);

			// COPPER ORE
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Copper Ore", new int[]
			{
				ItemID.CopperOre,
				ItemID.TinOre,
			});
			RecipeGroup.RegisterGroup("CopperOre", group);

			// IRON ORE
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Iron Ore", new int[]
			{
				ItemID.IronOre,
				ItemID.LeadOre,
			});
            RecipeGroup.RegisterGroup("IronOre", group);

            // SILVER ORE
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Ore", new int[]
			{
				ItemID.SilverOre,
				ItemID.TungstenOre,
			});
			RecipeGroup.RegisterGroup("SilverOre", group);

			// GOLD ORE
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Ore", new int[]
			{
				ItemID.GoldOre,
				ItemID.PlatinumOre,
			});
			RecipeGroup.RegisterGroup("GoldOre", group);


			// COPPER BAR
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Copper Bar", new int[]
			{
				ItemID.CopperBar,
				ItemID.TinBar,
			});
			RecipeGroup.RegisterGroup("CopperBar", group);

			// SILVER BAR
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Bar", new int[]
			{
				ItemID.SilverBar,
				ItemID.TungstenBar,
			});
			RecipeGroup.RegisterGroup("SilverBar", group);

			// GOLD BAR
			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Bar", new int[]
			{
				ItemID.GoldBar,
				ItemID.PlatinumBar,
			});
			RecipeGroup.RegisterGroup("GoldBar", group);
		}
	}
}