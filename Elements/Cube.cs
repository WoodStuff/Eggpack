using Eggpack.Elements.Prefixes.Cubes;
using Eggpack.Players;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Eggpack.Elements
{
	/// <summary>
	/// A cube item. This, when equipped, allows you to have active abilities.
	/// </summary>
	public abstract class Cube : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.maxStack = 1;
			Item.width = 30;
			Item.height = 30;
			Item.accessory = true;

			CustomDefaults();
		}

		/// <summary>
		/// All cube prefixes.
		/// </summary>
		public static List<int> CubePrefixes = [];

		/// <summary>
		/// SetDefaults sets common variables for all cubes, use this for cubes. You can override SetDefaults here too. Things you need to set:
		/// <c>Item.value</c>, <c>Item.rare</c>
		/// </summary>
		public virtual void CustomDefaults() { }
		public override bool CanEquipAccessory(Player player, int slot, bool modded)
		{
			return slot == ModContent.GetInstance<CubeSlot>().Type;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<EggPlayer>().equippedCube = Type;
			player.GetModPlayer<EggPlayer>().equippedCubePrefix = Item.prefix;
		}
		public override int ChoosePrefix(UnifiedRandom rand)
		{
			List<int> prefixes = new(CubePrefixes);
			foreach (int id in CubePrefixes)
			{
				CubePrefix prefix = PrefixLoader.GetPrefix(id) as CubePrefix;
				CubePrefixModifiers prefix_stats = prefix.GetModifiedStats();
				CubeSettings cube_stats = GetCubeSettings();
				if (prefix_stats.damage != 1 && !cube_stats.damages) prefixes.Remove(id);
				else if (prefix_stats.knockback != 1 && !cube_stats.damages) prefixes.Remove(id);
				else if (prefix_stats.buffDuration != 1 && cube_stats.buffID == 0 && !cube_stats.buffPrefix) prefixes.Remove(id);
				else if (prefix_stats.debuffDuration != 1 && cube_stats.debuffID == 0 && !cube_stats.debuffPrefix) prefixes.Remove(id);
				else if (prefix_stats.lifeCost != 1 && cube_stats.requireLife == 0) prefixes.Remove(id);
				else if (prefix_stats.healing != 1 && cube_stats.healLife == 0) prefixes.Remove(id);
				else if (prefix_stats.projectileSpeed != 1 && cube_stats.projectileID == 0) prefixes.Remove(id);
			}
			return rand.Next(prefixes);
		}
		public override bool AllowPrefix(int pre)
		{
			return true;
		}
		/// <summary>
		/// Allows you to do something when the cube activates.
		/// </summary>
		public virtual void OnActivate(Player player) { }
		/// <summary>
		/// Sets most of the cube's stats.
		/// </summary>
		public virtual CubeSettings GetCubeSettings()
		{
			return new CubeSettings();
		}
		/// <summary>
		/// Get the cube's stats taking into account the cube's prefix.
		/// </summary>
		/// <returns>Cube's stats taking into account the prefix.</returns>
		public CubeSettings GetModifiedStats()
		{
			int prefix = Item.prefix;
			CubeSettings modifiers = GetCubeSettings();
			if (prefix == 0) return modifiers;

			if (CubePrefixes.Contains(prefix))
			{
				CubePrefix pref = PrefixLoader.GetPrefix(prefix) as CubePrefix;
				modifiers.cooldown *= pref.GetModifiedStats().cooldown;
				modifiers.manaCost = (int)(modifiers.manaCost * pref.GetModifiedStats().manaCost);
				modifiers.damageMult *= pref.GetModifiedStats().damage;
				modifiers.knockbackMult *= pref.GetModifiedStats().knockback;
				modifiers.buffDuration *= pref.GetModifiedStats().buffDuration;
				modifiers.debuffDuration *= pref.GetModifiedStats().debuffDuration;
				modifiers.requireLife = (int)(modifiers.manaCost * pref.GetModifiedStats().lifeCost);
				modifiers.healLife = (int)(modifiers.healLife * pref.GetModifiedStats().healing);
				modifiers.projectileSpeed *= pref.GetModifiedStats().projectileSpeed;
			}
			return modifiers;
		}
		/// <summary>
		/// Get the cube's stats taking into account the cube's prefix.
		/// </summary>
		/// <param name="player">The player that has the cube.</param>
		/// <returns>Cube's stats taking into account the prefix.</returns>
		public CubeSettings GetModifiedStats(Player player)
		{
			int prefix = player.GetModPlayer<EggPlayer>().equippedCubePrefix;
			CubeSettings modifiers = GetCubeSettings();
			if (prefix == 0) return modifiers;

			if (CubePrefixes.Contains(prefix))
			{
				CubePrefix pref = PrefixLoader.GetPrefix(prefix) as CubePrefix;
				modifiers.cooldown *= pref.GetModifiedStats().cooldown;
				modifiers.manaCost = (int)(modifiers.manaCost * pref.GetModifiedStats().manaCost);
				modifiers.damageMult *= pref.GetModifiedStats().damage;
				modifiers.knockbackMult *= pref.GetModifiedStats().knockback;
				modifiers.buffDuration *= pref.GetModifiedStats().buffDuration;
				modifiers.debuffDuration *= pref.GetModifiedStats().debuffDuration;
				modifiers.requireLife = (int)(modifiers.manaCost * pref.GetModifiedStats().lifeCost);
				modifiers.healLife = (int)(modifiers.healLife * pref.GetModifiedStats().healing);
				modifiers.projectileSpeed *= pref.GetModifiedStats().projectileSpeed;
			}
			return modifiers;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			CubeSettings stats = GetModifiedStats();
			var tooltip = $"[i:109]{GetModifiedStats().manaCost} [i:3099]{Eggpack.ToSeconds(stats.cooldown)}s";
			var line = new TooltipLine(Mod, "ManaCooldown", tooltip);
			tooltips.Add(line);

			tooltip = Language.GetTextValue($"Mods.Eggpack.Items.{Name}.CubeTooltip");
			line = new TooltipLine(Mod, "CubeTooltip", tooltip);
			tooltips.Add(line);
		}
	}
	/// <summary>
	/// A class used to easily make the properties of the cube.
	/// </summary>
	public class CubeSettings
	{
		/// <summary>
		/// The cooldown before you can use the cube again, in frames. Use <c>Eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public float cooldown = Eggpack.ToFrames(10);
		/// <summary>
		/// How much MP you need to use the cube and how much it consumes. You can set the amount of mana taken separately using takeMana.
		/// </summary>
		public int manaCost = 25;
		/// <summary>
		/// How much MP the cube takes when using it.
		/// </summary>
		public int takeMana;
		/// <summary>
		/// How much HP you need to use the cube. This does not take away life, use <see cref="backfireDamage"/> to take away the life.
		/// </summary>
		public int requireLife;
		/// <summary>
		/// How much HP this cube heals when used.
		/// </summary>
		public int healLife;

		/// <summary>
		/// Determines if activating shoots the projectile. Set to true if adding own projectile shooting behavior.
		/// </summary>
		public bool dontShoot = false;
		/// <summary>
		/// The projectile the cube fires. 0 is none.
		/// </summary>
		public int projectileID;
		/// <summary>
		/// The projectile's speed multiplier.
		/// 1 is really slow, 6 is good, 12 is fast.
		/// </summary>
		public float projectileSpeed = 6;
		/// <summary>
		/// Multiplies the damage. Mainly used for projectiles.
		/// </summary>
		public float damageMult = 1;
		/// <summary>
		/// Multiplies the knockback. Mainly used for projectiles.
		/// </summary>
		public float knockbackMult = 1;
		/// <summary>
		/// If the cube damages other entities.
		/// </summary>
		public bool damages = false;

		/// <summary>
		/// True if the cube should get buff prefixes even if it doesn't give any buffs.
		/// </summary>
		public bool buffPrefix = false;
		/// <summary>
		/// True if the cube should get debuff prefixes even if it doesn't give any debuffs.
		/// </summary>
		public bool debuffPrefix = false;

		/// <summary>
		/// A sound can be played on cube use, this will be the SoundStyle for it.
		/// </summary>
		public SoundStyle? sound = null;

		/// <summary>
		/// The buff the cube gives you when used. 0 is none.
		/// </summary>
		public int buffID;
		/// <summary>
		/// The duration of the cube's buff, in frames. Use <c>Eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public float buffDuration;
		/// <summary>
		/// The debuff the cube gives you when used, since pre-ML can't get too easy. 0 is none.
		/// </summary>
		public int debuffID;
		/// <summary>
		/// The duration of the cube's debuff, in frames. Use <c>Eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public float debuffDuration;
		/// <summary>
		/// How much HP the cube damages you for when used. 0 is none.
		/// </summary>
		public int backfireDamage;
	}
}