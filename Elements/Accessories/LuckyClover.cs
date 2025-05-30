﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Accessories;

public class LuckyClover : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.rare = ItemRarityID.White;
		Item.accessory = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Blinkroot, 2)
			.AddIngredient(ItemID.Daybloom, 3)
			.AddIngredient(ItemID.Sunflower)
			.AddTile(TileID.WorkBenches)
			.Register();
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetCritChance(DamageClass.Generic) += 4f;
	}
}