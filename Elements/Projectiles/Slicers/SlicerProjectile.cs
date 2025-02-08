using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles.Slicers
{
	/// <summary>
	/// Base class for slicer projectiles.
	/// </summary>
	public abstract class SlicerProjectile : ModProjectile
	{
		/// <summary>
		/// Delay after which the projectile falls.
		/// </summary>
		protected virtual float GravityDelay => 15f;
		/// <summary>
		/// The force of gravity.
		/// </summary>
		protected virtual float GravityForce => 0.2f;
		/// <summary>
		/// Maximum falling speed.
		/// </summary>
		protected virtual float MaxFallSpeed => 16f;

		public override void AI()
		{
			Projectile.ai[0]++;

			if (Projectile.ai[0] > GravityDelay)
			{
				Projectile.velocity.Y += GravityForce;
				if (Projectile.velocity.Y > MaxFallSpeed) Projectile.velocity.Y = MaxFallSpeed;
			}

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			modifiers.CritDamage += 1f;
		}
	}
}
