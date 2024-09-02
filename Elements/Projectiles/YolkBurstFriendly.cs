using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles
{
	/// <summary>
	/// A yolk burst fired from the Outburst Cube.
	/// </summary>
	public class YolkBurstFriendly : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.damage = 60;
			Projectile.knockBack = 3;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.penetrate = 2;
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
					DustID.Honey,
					0f,
					0f,
					100
				);
				Main.dust[particle].noGravity = true;
			}
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
					DustID.Honey,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).X * 3,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3,
					100,
					new Color(192, 192, 192)
				);
				Main.dust[particle].noGravity = true;
			}
		}
	}
}
