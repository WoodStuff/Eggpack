using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Eggpack.Elements.Weapons.Summoner.Whips.Projectiles;

namespace Eggpack.Elements.Weapons.Summoner.Whips
{
	public class WoodenWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Simple. You form it into a whip.'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToWhip(ModContent.ProjectileType<WoodenWhipProjectile>(), 11, 0.5f, 2);

			Item.shootSpeed = 2;
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