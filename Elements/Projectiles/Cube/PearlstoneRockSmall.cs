using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles.Cube
{
	/// <summary>
	/// The small Pearlstone Cube projectiles that the big one splits into three of.
	/// </summary>
	public class PearlstoneRockSmall : ModProjectile
	{
		private NPC HomingTarget
		{
			get => Projectile.ai[0] == 0 ? null : Main.npc[(int)Projectile.ai[0] - 1];
			set
			{
				Projectile.ai[0] = value == null ? 0 : value.whoAmI + 1;
			}
		}

		public ref float Timer => ref Projectile.ai[1];

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Generic;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.friendly = true;
			Projectile.timeLeft = 180;

			Projectile.width = 16;
			Projectile.height = 16;
		}

		public override void AI()
		{
			float maxDetectRadius = 800f;

			if (Timer < 10)
			{
				Timer += 1;
				return;
			}

			if (HomingTarget == null) HomingTarget = FindClosestNPC(maxDetectRadius);

			if (HomingTarget != null && !IsValidTarget(HomingTarget)) HomingTarget = null;

			if (HomingTarget == null) return;

			float length = Projectile.velocity.Length();
			float targetAngle = Projectile.AngleTo(HomingTarget.Center);
			Projectile.velocity = Projectile.velocity.ToRotation().AngleTowards(targetAngle, MathHelper.ToRadians(12)).ToRotationVector2() * length;
			Projectile.rotation = Projectile.velocity.ToRotation();

			if (Main.rand.NextBool(4))
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
		}

		private NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs
			foreach (var target in Main.ActiveNPCs)
			{
				// Check if NPC able to be targeted. 
				if (IsValidTarget(target))
				{
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}

		public bool IsValidTarget(NPC target) => target.CanBeChasedBy() && Collision.CanHit(Projectile.Center, 1, 1, target.position, target.width, target.height);
	}
}
