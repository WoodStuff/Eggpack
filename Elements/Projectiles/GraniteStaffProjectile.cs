using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles
{
	/// <summary>
	/// A projectile fired by the Granite Staff.
	/// </summary>
	public class GraniteStaffProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Magic;

			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
		}
		public override void AI()
		{
			int particle = Dust.NewDust(
				new Vector2(Projectile.position.X, Projectile.position.Y),
				Projectile.width,
				Projectile.height,
				DustID.Granite,
				Projectile.velocity.X,
				Projectile.velocity.Y,
				100
			);
			Main.dust[particle].noGravity = true;
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
					DustID.Granite,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).X * 3,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3
				);
				Main.dust[particle].noGravity = true;
			}
		}
	}
}
