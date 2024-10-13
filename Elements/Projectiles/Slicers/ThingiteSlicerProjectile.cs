using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles.Slicers
{
	public class ThingiteSlicerProjectile : SlicerProjectile
	{
		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;

			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = 2;
		}

		public override void OnKill(int timeLeft)
		{
			int particles = 8;
			for (int i = 0; i < particles; i++)
			{
				int particle = Dust.NewDust(
					new Vector2(Projectile.position.X, Projectile.position.Y),
					Projectile.width,
					Projectile.height,
					DustID.Marble,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).X * 3,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3
				);
				Main.dust[particle].noGravity = true;
			}
		}
	}
}
