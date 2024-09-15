using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles.Slicers
{
	public class MeteorSlicerProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;

			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = 5;
		}

		public override void AI()
		{
			Projectile.ai[0]++;

			if (Projectile.ai[0] > 15f)
			{
				Projectile.velocity.Y += 0.2f;
				if (Projectile.velocity.Y > 16f) Projectile.velocity.Y = 16f;
			}

			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(
					new Vector2(Projectile.position.X, Projectile.position.Y),
					Projectile.width,
					Projectile.height,
					DustID.Torch,
					0f,
					0f,
					100
				);
			}

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			modifiers.CritDamage += 1f;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 2 * 60);
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
					DustID.Meteorite,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).X * 3,
					new Vector2(0, 1).RotatedBy(Math.PI * 2 / particles).Y * 3
				);
				Main.dust[particle].noGravity = true;
			}
		}
	}
}
