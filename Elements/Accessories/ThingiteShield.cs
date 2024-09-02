﻿using Eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Eggpack.Elements.Items;

namespace Eggpack.Elements.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ThingiteShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.value = Item.sellPrice(0, 0, 75, 0);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.defense = 2;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient<ThingiteBar>(5)
			.AddIngredient<WoodenShield>()
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}