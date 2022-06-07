using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace eggpack.Elements.Accessories
{
	public class BladeSharpener : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+2% melee damage, +3% melee critical strike chance");
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 40000;
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddRecipeGroup(RecipeGroupID.IronBar, 4)
			.AddTile(TileID.Anvils);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Melee) += 3f;
			player.GetCritChance(DamageClass.Melee) += 2f;
		}
	}
}