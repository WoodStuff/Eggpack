using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.ModLoader;
using eggpack.Systems;
using eggpack.Elements;
using eggpack.Elements.Weapons.Melee;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace eggpack.Players
{
	public class KeybindPlayer : ModPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (KeybindSystem.CubeAbility.JustPressed && Player.GetModPlayer<EggPlayer>().equippedCube != 0)
			{
				Cube cube = (Cube)ModContent.GetModItem(Player.GetModPlayer<EggPlayer>().equippedCube);
				CubeSettings cubeSettings = cube.GetCubeSettings(Player);

				// dont do anything if player has insufficient mana or life
				if (Player.statMana < cubeSettings.requireMana || Player.statLife < cubeSettings.requireLife) return;

				// shoot the projectile if it exists
				if (cubeSettings.projectileID != 0)
				{
					Projectile.NewProjectile(
						Player.GetSource_Accessory(cube.Item), Player.position, Vector2.Zero, cubeSettings.projectileID, cubeSettings.projectileDamage, cubeSettings.projectileKnockback
					);
				}

				// take the mana and life
				Player.statMana -= cubeSettings.takeMana;
				if (cubeSettings.backfireDamage != 0) {
					bool kb = Player.noKnockback;
					Player.noKnockback = true;
					Player.Hurt(PlayerDeathReason.ByCustomReason($"{Player.name} got cubed to death."), cubeSettings.backfireDamage, 0);
					Player.noKnockback = kb;
				}

				// add the buffs & debuffs
				if (cubeSettings.buffID != 0) Player.AddBuff(cubeSettings.buffID, cubeSettings.buffDuration);
				if (cubeSettings.backfireBuffID != 0) Player.AddBuff(cubeSettings.backfireBuffID, cubeSettings.backfireBuffDuration);

				cube.OnActivate(Player);
			}
		}
	}
}