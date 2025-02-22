﻿using System.Collections.Generic;
using Eggpack.Elements.Weapons.Summoner.Whips.Debuffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Summoner.Whips.Projectiles;

public class WoodenWhipProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		ProjectileID.Sets.IsAWhip[Type] = true;
	}

	public override void SetDefaults()
	{
		Projectile.DefaultToWhip();

		Projectile.WhipSettings.Segments = 20;
		Projectile.WhipSettings.RangeMultiplier = 1.25f;
	}

	private float Timer
	{
		get => Projectile.ai[0];
		set => Projectile.ai[0] = value;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(ModContent.BuffType<WoodenWhipDebuff>(), 240);
		Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
	}

	private void DrawLine(List<Vector2> list)
	{
		Texture2D texture = TextureAssets.FishingLine.Value;
		Rectangle frame = texture.Frame();
		Vector2 origin = new(frame.Width / 2, 2);

		Vector2 pos = list[0];
		for (int i = 0; i < list.Count - 1; i++)
		{
			Vector2 element = list[i];
			Vector2 diff = list[i + 1] - element;

			float rotation = diff.ToRotation() - MathHelper.PiOver2;
			Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
			Vector2 scale = new(1, (diff.Length() + 2) / frame.Height);

			Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

			pos += diff;
		}
	}

	public override bool PreDraw(ref Color lightColor)
	{
		List<Vector2> list = [];
		Projectile.FillWhipControlPoints(Projectile, list);

		DrawLine(list);

		SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

		Main.instance.LoadProjectile(Type);
		Texture2D texture = TextureAssets.Projectile[Type].Value;

		Vector2 pos = list[0];

		for (int i = 0; i < list.Count - 1; i++)
		{
			// These two values are set to suit this projectile's sprite, but won't necessarily work for your own.
			// You can change them if they don't!
			Rectangle frame = new(0, 0, 10, 32);
			Vector2 origin = new(5, 8);
			float scale = 1;

			// These statements determine what part of the spritesheet to draw for the current segment.
			// They can also be changed to suit your sprite.
			if (i == list.Count - 2)
			{
				frame.Y = 74;
				frame.Height = 18;

				// For a more impactful look, this scales the tip of the whip up when fully extended, and down when curled up.
				Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
				float t = Timer / timeToFlyOut;
				scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
			}
			else if (i > 5)
			{
				frame.Y = 58;
				frame.Height = 16;
			}
			else if (i > 3)
			{
				frame.Y = 42;
				frame.Height = 16;
			}
			else if (i > 0)
			{
				frame.Y = 26;
				frame.Height = 16;
			}

			Vector2 element = list[i];
			Vector2 diff = list[i + 1] - element;

			float rotation = diff.ToRotation() - MathHelper.PiOver2; // This projectile's sprite faces down, so PiOver2 is used to correct rotation.
			Color color = Lighting.GetColor(element.ToTileCoordinates());

			Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

			pos += diff;
		}
		return false;
	}
}