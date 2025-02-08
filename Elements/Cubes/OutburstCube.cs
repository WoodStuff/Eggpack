using System;
using Eggpack.Elements.Buffs;
using Eggpack.Elements.Items;
using Eggpack.Elements.Projectiles.Cube;
using Eggpack.Elements.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace Eggpack.Elements.Cubes;

public class OutburstCube : Cube
{
	public override void CustomDefaults()
	{
		Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 1));
	}

	public override CubeSettings GetCubeSettings()
	{
		CubeSettings settings = new()
		{
			cooldown = Eggpack.ToFrames(15),
			manaCost = 30,

			projectileID = ModContent.ProjectileType<YolkBurstFriendly>(),
			projectileSpeed = 8,
			damages = true,
			dontShoot = true,

			debuffID = ModContent.BuffType<WeaponExhaustion>(),
			debuffDuration = Eggpack.ToFrames(8),
		};

		return settings;
	}

	public override void OnActivate(Player player)
	{
		CubeSettings cubeSettings = GetModifiedStats(player);

		Projectile projectile = ModContent.GetModProjectile(cubeSettings.projectileID).Projectile;
		for (int i = 0; i < 8; i++)
		{
			Projectile.NewProjectile(
				player.GetSource_Accessory(Item),
				player.Center,
				Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 8) * cubeSettings.projectileSpeed,
				cubeSettings.projectileID,
				Convert.ToInt32(projectile.damage * cubeSettings.damageMult),
				projectile.knockBack * cubeSettings.knockbackMult,
				player.whoAmI
			);
		}
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<YolkShard>(5)
			.AddTile<Yolkifier>()
			.Register();
	}
}