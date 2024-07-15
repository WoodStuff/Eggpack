using Eggpack.Elements;
using Eggpack.Elements.Buffs;
using Eggpack.Systems;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Eggpack.Players
{
	public class CubePlayer : ModPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (KeybindSystem.CubeAbility.JustPressed && Player.GetModPlayer<EggPlayer>().equippedCube != 0 && !Player.HasBuff<CubeSickness>())
			{
				
				Cube cube = (Cube)ModContent.GetModItem(Player.GetModPlayer<EggPlayer>().equippedCube);
				CubeSettings cubeSettings = cube.GetModifiedStats(Player);

				// dont do anything if player has insufficient mana or life
				if (Player.statMana < cubeSettings.manaCost || Player.statLife < cubeSettings.requireLife) return;

				// shoot the projectile if it exists
				if (cubeSettings.projectileID != 0)
				{
					Projectile projectile = ModContent.GetModProjectile(cubeSettings.projectileID).Projectile;
					Projectile.NewProjectile(
						Player.GetSource_Accessory(cube.Item),
						Player.Center,
						(Main.MouseWorld - Player.Center).SafeNormalize(Vector2.Zero) * cubeSettings.projectileSpeed,
						cubeSettings.projectileID,
						Convert.ToInt32(projectile.damage * cubeSettings.damageMult),
						projectile.knockBack * cubeSettings.knockbackMult,
						Player.whoAmI
					);
				}

				// take the mana and life
				Player.statMana -= cubeSettings.takeMana == 0 ? cubeSettings.manaCost : cubeSettings.takeMana;
				if (cubeSettings.backfireDamage != 0)
				{
					// gives the player knockback immunity for this specific attack
					bool kb = Player.noKnockback;
					Player.noKnockback = true;
					Player.Hurt(PlayerDeathReason.ByCustomReason($"{Player.name} got cubed to death."), cubeSettings.backfireDamage, 0);
					Player.noKnockback = kb;
				}

				if (cubeSettings.healLife != 0) Player.Heal(cubeSettings.healLife);

				// add the buffs & debuffs
				if (cubeSettings.buffID != 0) Player.AddBuff(cubeSettings.buffID, (int)cubeSettings.buffDuration);
				if (cubeSettings.backfireBuffID != 0) Player.AddBuff(cubeSettings.backfireBuffID, (int)cubeSettings.backfireBuffDuration);

				// play the sound
				if (cubeSettings.sound != null) SoundEngine.PlaySound((SoundStyle)cubeSettings.sound, Player.Center);

				// add the cooldown debuff
				Player.AddBuff(ModContent.BuffType<CubeSickness>(), (int)cubeSettings.cooldown);

				cube.OnActivate(Player);
			}
		}
	}
}