using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Eggpack
{
	public class ModRecipeGroup : ModSystem
	{
		public static RecipeGroup Gems;
		public static RecipeGroup EvilMaterials;

		public static RecipeGroup EvilOre;
		public static RecipeGroup EvilBar;
		public static RecipeGroup CopperOre;
		public static RecipeGroup IronOre;
		public static RecipeGroup SilverOre;
		public static RecipeGroup GoldOre;
		public static RecipeGroup CopperBar;
		public static RecipeGroup SilverBar;
		public static RecipeGroup GoldBar;
		public override void AddRecipeGroups()
		{
			// GEMS
			Gems = new(() => Language.GetTextValue("LegacyMisc.37") + " Gem",
			[
				ItemID.Amethyst,
				ItemID.Topaz,
				ItemID.Sapphire,
				ItemID.Emerald,
				ItemID.Ruby,
				ItemID.Diamond,
				ItemID.Amber,
			]);
			RecipeGroup.RegisterGroup("Gems", Gems);

			// EVIL MATERIALS
			EvilMaterials = new(() => Language.GetTextValue("LegacyMisc.37") + " Evil Material",
			[
				ItemID.ShadowScale,
				ItemID.TissueSample,
			]);
			RecipeGroup.RegisterGroup("EvilMaterials", EvilMaterials);

			// ----------- BARS BELOW ----------- //

			// EVIL ORE
			EvilOre = new(() => Language.GetTextValue("LegacyMisc.37") + " Evil Ore",
			[
				ItemID.DemoniteOre,
				ItemID.CrimtaneOre,
			]);
			RecipeGroup.RegisterGroup("EvilOre", EvilOre);

			// EVIL BARS
			EvilBar = new(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bar",
			[
				ItemID.DemoniteBar,
				ItemID.CrimtaneBar,
			]);
			RecipeGroup.RegisterGroup("EvilBar", EvilBar);

			// COPPER ORE
			CopperOre = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Copper Ore",
			[
				ItemID.CopperOre,
				ItemID.TinOre,
			]);
			RecipeGroup.RegisterGroup("CopperOre", CopperOre);

			// IRON ORE
			IronOre = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Iron Ore",
			[
				ItemID.IronOre,
				ItemID.LeadOre,
			]);
			RecipeGroup.RegisterGroup("IronOre", IronOre);

			// SILVER ORE
			SilverOre = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Ore",
			[
				ItemID.SilverOre,
				ItemID.TungstenOre,
			]);
			RecipeGroup.RegisterGroup("SilverOre", SilverOre);

			// GOLD ORE
			GoldOre = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Ore",
			[
				ItemID.GoldOre,
				ItemID.PlatinumOre,
			]);
			RecipeGroup.RegisterGroup("GoldOre", GoldOre);


			// COPPER BAR
			CopperBar = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Copper Bar",
			[
				ItemID.CopperBar,
				ItemID.TinBar,
			]);
			RecipeGroup.RegisterGroup("CopperBar", CopperBar);

			// SILVER BAR
			SilverBar = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Bar",
			[
				ItemID.SilverBar,
				ItemID.TungstenBar,
			]);
			RecipeGroup.RegisterGroup("SilverBar", SilverBar);

			// GOLD BAR
			GoldBar = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Bar",
			[
				ItemID.GoldBar,
				ItemID.PlatinumBar,
			]);
			RecipeGroup.RegisterGroup("GoldBar", GoldBar);
		}
	}
}
