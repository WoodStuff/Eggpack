using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
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
			Projectile.damage = 0;
			Projectile.knockBack = 4;
			Projectile.DamageType = DamageClass.Magic;

			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			AIType = ProjectileID.Bullet;
		}
		public override void AI()
		{
			for (int i = 0; i < 3; i++)
			{
				int particle = Dust.NewDust(
					new Vector2(Projectile.position.X, Projectile.position.Y),
					Projectile.width,
					Projectile.height,
					DustID.Granite,
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
					DustID.Granite,
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
