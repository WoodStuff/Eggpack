﻿using Eggpack.Elements.Buffs;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Cubes;

public class AdvancedHealingCube : Cube
{
	public override void CustomDefaults()
	{
		Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 1, 50));
	}

	public override CubeSettings GetCubeSettings()
	{
		CubeSettings settings = new()
		{
			cooldown = Eggpack.ToFrames(25),
			manaCost = 30,

			healLife = 50,

			debuffID = ModContent.BuffType<Paperskin>(),
			debuffDuration = Eggpack.ToFrames(12),
		};

		return settings;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<HealingCube>()
			.AddRecipeGroup(ModRecipeGroup.EvilMaterials, 12)
			.AddIngredient(ItemID.LifeCrystal)
			.AddTile(TileID.Anvils)
			.Register();
	}
}