using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles.Cube;

/// <summary>
/// The big projectile fired from the Pearlstone Cube. Splits into three smaller projectiles.
/// </summary>
public class PearlstoneRockBig : ModProjectile
{
	public ref float Timer => ref Projectile.ai[0];

	public override void SetDefaults()
	{
		Projectile.damage = 300;
		Projectile.knockBack = 6;
		Projectile.DamageType = DamageClass.Generic;
		Projectile.penetrate = 1;
		Projectile.tileCollide = true;
		Projectile.friendly = true;

		Projectile.width = 24;
		Projectile.height = 24;
	}

	public override void AI()
	{
		Timer++;

		Projectile.velocity *= 0.92f;

		if (Timer > 500) Projectile.Kill();

		for (int i = 0; i < 2; i++)
		{
			int particle = Dust.NewDust(
				new Vector2(Projectile.position.X, Projectile.position.Y),
				Projectile.width,
				Projectile.height,
				DustID.DungeonPink,
				0f,
				0f,
				100
			);
			Main.dust[particle].noGravity = true;
		}

		Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
	}

	public override void OnKill(int timeLeft)
	{
		int particles = 6;
		for (int i = 0; i < particles; i++)
		{
			int particle = Dust.NewDust(
				new Vector2(Projectile.position.X, Projectile.position.Y),
				Projectile.width,
				Projectile.height,
				DustID.DungeonPink,
				new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).X * 3,
				new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3,
				100,
				new Color(192, 192, 192)
			);
			Main.dust[particle].noGravity = true;
		}

		if (Timer <= 50) return;

		for (int i = 0; i < 3; i++)
		{
			Projectile.NewProjectile(
				Projectile.GetSource_FromThis(),
				Projectile.Center,
				Vector2.UnitY.RotatedByRandom(Math.PI * 2) * 10,
				ModContent.ProjectileType<PearlstoneRockSmall>(),
				75,
				3
			);
		}
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

		if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
			Projectile.velocity.X = -oldVelocity.X;

		if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
			Projectile.velocity.Y = -oldVelocity.Y;

		return false;
	}
}
