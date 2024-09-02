using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles
{
	/// <summary>
	/// A yolk burst fired in the Ruler of Eggs' Bursts attack.
	/// </summary>
	public class YolkBurst : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.DontAttachHideToAlpha[Type] = true;
		}
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Generic;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.hostile = true;
			Projectile.timeLeft = 300;
			Projectile.hide = true;

			Projectile.width = 30;
			Projectile.height = 30;
		}

		private Vector2 Target
		{
			get => new(Projectile.ai[0], Projectile.ai[1]);
			set
			{
				Projectile.ai[0] = value.X;
				Projectile.ai[1] = value.Y;
			}
		}
		private float Duration
		{
			get => Projectile.ai[2];
			set => Projectile.ai[2] = value;
		}
		private Vector2 Spawn = Vector2.Zero;

		public override void AI()
		{
			if (Spawn == Vector2.Zero) Spawn = Projectile.Center;
			if ((Projectile.Center - Spawn).Length() >= Duration)
			{
				Projectile.Kill();
				return;
			}

			Projectile.velocity += (Target - Spawn).SafeNormalize(Vector2.Zero) / 5;

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

		public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
		{
			behindNPCs.Add(index);
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.WriteVector2(Spawn);
		}
		public override void ReceiveExtraAI(BinaryReader reader)
		{
			Spawn = reader.ReadVector2();
		}
	}
}
