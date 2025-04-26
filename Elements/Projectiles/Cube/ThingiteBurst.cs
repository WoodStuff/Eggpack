using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles.Cube;

/// <summary>
/// A projectile fired by the Thingite Cube.
/// </summary>
public class ThingiteBurst : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.damage = 80;
		Projectile.knockBack = 4;
		Projectile.DamageType = DamageClass.Generic;
		Projectile.penetrate = 5;
		Projectile.tileCollide = true;
		Projectile.friendly = true;
		Projectile.timeLeft = 180;

		Projectile.width = 30;
		Projectile.height = 30;
	}
	public override void AI()
	{
		for (int i = 0; i < 2; i++)
		{
			int particle = Dust.NewDust(
				new Vector2(Projectile.position.X, Projectile.position.Y),
				Projectile.width,
				Projectile.height,
				DustID.Sandstorm,
				0f,
				0f,
				100
			);
			Main.dust[particle].noGravity = true;
		}
	}
	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		Projectile.penetrate--;
		if (Projectile.penetrate <= 0)
			Projectile.Kill();
		else
		{
			Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

			if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
				Projectile.velocity.X = -oldVelocity.X;

			if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
				Projectile.velocity.Y = -oldVelocity.Y;
		}

		return false;
	}
	public override void OnKill(int timeLeft)
	{
		int particles = 16;
		for (int i = 0; i < particles; i++)
		{
			int particle = Dust.NewDust(
				new Vector2(Projectile.position.X, Projectile.position.Y),
				Projectile.width,
				Projectile.height,
				DustID.RainbowTorch,
				new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).X * 3,
				new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3,
				100,
				new Color(192, 192, 192)
			);
			Main.dust[particle].noGravity = true;
		}
	}
}
