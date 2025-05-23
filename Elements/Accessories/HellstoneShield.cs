﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Accessories;

[AutoloadEquip(EquipType.Shield)]
public class HellstoneShield : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.rare = ItemRarityID.Orange;
		Item.accessory = true;
		Item.defense = 3;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient<ReinforcedShield>()
		.AddIngredient(ItemID.HellstoneBar, 10)
		.AddTile(TileID.Anvils)
		.Register();
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetCritChance(DamageClass.Generic) += 5f;
	}
}