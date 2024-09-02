using Eggpack.Elements.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Tools
{
	public class ThingiteAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 36;
			Item.height = 32;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.axe = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient<ThingiteBar>(8)
			.AddRecipeGroup(RecipeGroupID.Wood, 3)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}