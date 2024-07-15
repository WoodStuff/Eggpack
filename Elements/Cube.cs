using eggpack.Elements.Prefixes.Cubes;
using eggpack.Players;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.GameContent.UI.Chat;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace eggpack.Elements
{
	/// <summary>
	/// A cube item. This, when equipped, allows you to have active abilities.
	/// </summary>
	public abstract class Cube : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
			List<int> prefixes = CubePrefixes;
			foreach (int id in prefixes)
			{
				CubePrefix prefix = PrefixLoader.GetPrefix(id) as CubePrefix;
				CubePrefixModifiers prefix_stats = prefix.GetModifiedStats();
				CubeSettings cube_stats = GetCubeSettings();
					 if (prefix_stats.damage != 1 && !cube_stats.damages) prefixes.Remove(id);
				else if (prefix_stats.knockback != 1 && !cube_stats.damages) prefixes.Remove(id);
				else if (prefix_stats.buffDuration != 1 && cube_stats.buffID == 0) prefixes.Remove(id);
				else if (prefix_stats.backfireBuffDuration != 1 && cube_stats.backfireBuffID == 0) prefixes.Remove(id);
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
		/// <param name="player">The player that has the cube.</param>
		/// <returns>Cube's stats taking into account the prefix.</returns>
		public CubeSettings GetModifiedStats(Player player)
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
				modifiers.backfireBuffDuration *= pref.GetModifiedStats().backfireBuffDuration;
				modifiers.requireLife = (int)(modifiers.manaCost * pref.GetModifiedStats().lifeCost);
				modifiers.healLife = (int)(modifiers.healLife * pref.GetModifiedStats().healing);
				modifiers.projectileSpeed *= pref.GetModifiedStats().projectileSpeed;
			}
			return modifiers;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.CurrentPlayer;

			var line = new TooltipLine(Mod, "UseMana", $"Uses {GetModifiedStats(player).manaCost} mana");
			tooltips.Add(line);

			var tooltip = Language.GetTextValue($"Mods.eggpack.Items.{Name}.CubeTooltip");
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
		/// The cooldown before you can use the cube again, in frames. Use <c>eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public float cooldown = eggpack.ToFrames(10);
		/// <summary>
		/// How much MP you need to use the cube and how much it consumes. You can set the amount of mana taken separately using takeMana.
		/// </summary>
		public int manaCost = 25;
		/// <summary>
		/// How much MP the cube takes when using it.
		/// </summary>
		public int takeMana;
		/// <summary>
		/// How much HP you need to use the cube.
		/// </summary>
		public int requireLife;
		/// <summary>
		/// How much HP this cube heals when used.
		/// </summary>
		public int healLife;

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
		/// Multiplies the knockkback. Mainly used for projectiles.
		/// </summary>
		public float knockbackMult = 1;
		/// <summary>
		/// If the cube damages other entities.
		/// </summary>
		public bool damages = false;

		/// <summary>
		/// A sound can be played on cube use, this will be the SoundStyle for it.
		/// </summary>
		public SoundStyle? sound = null;

		/// <summary>
		/// The buff the cube gives you when used. 0 is none.
		/// </summary>
		public int buffID;
		/// <summary>
		/// The duration of the cube's buff, in frames. Use <c>eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public float buffDuration;
		/// <summary>
		/// The debuff the cube gives you when used, since pre-ML can't get too easy. 0 is none.
		/// </summary>
		public int backfireBuffID;
		/// <summary>
		/// The duration of the cube's debuff, in frames. Use <c>eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public float backfireBuffDuration;
		/// <summary>
		/// How much HP the cube damages you for when used. 0 is none.
		/// </summary>
		public int backfireDamage;
	}
}