﻿using Eggpack.Elements.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Armor.Thingite;

[AutoloadEquip(EquipType.Head)]
public class ThingiteHelmet : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 22;
		Item.value = Item.sellPrice(0, 0, 55, 0);
		Item.rare = ItemRarityID.Blue;
		Item.defense = 6;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		return head.type == ModContent.ItemType<ThingiteHelmet>() && body.type == ModContent.ItemType<ThingiteBreastplate>() && legs.type == ModContent.ItemType<ThingiteGreaves>();
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = "+2 defense, slightly increased movement speed";
		player.statDefense += 2;
		player.moveSpeed += 0.02f;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient<ThingiteBar>(10)
		.AddTile(TileID.Anvils)
		.Register();
	}
}


[AutoloadEquip(EquipType.Body)]
public class ThingiteBreastplate : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 26;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 0, 65, 0);
		Item.rare = ItemRarityID.Blue;
		Item.defense = 6;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient<ThingiteBar>(12)
		.AddTile(TileID.Anvils)
		.Register();
	}
}


[AutoloadEquip(EquipType.Legs)]
public class ThingiteGreaves : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 22;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.rare = ItemRarityID.Blue;
		Item.defense = 5;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient<ThingiteBar>(8)
		.AddTile(TileID.Anvils)
		.Register();
	}
}