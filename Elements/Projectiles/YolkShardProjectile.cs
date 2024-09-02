using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles
{
	/// <summary>
	/// A yolk shard fired in the Ruler of Eggs' Shards attack.
	/// </summary>
	public class YolkShardProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Generic;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.hostile = true;
			Projectile.timeLeft = 300;
			Projectile.aiStyle = ProjAIStyleID.Arrow;

			Projectile.width = 18;
			Projectile.height = 18;
		}
		public override void AI()
		{
			for (int i = 0; i < 3; i++)
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
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3
				);
				Main.dust[particle].noGravity = true;
			}
		}
	}
}
