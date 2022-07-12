using eggpack.Players;
using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

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
		}
		/// <summary>
		/// Allows you to do something when the cube activates.
		/// </summary>
		public virtual void OnActivate(Player player) { }
		/// <summary>
		/// Sets most of the cube's stats.
		/// </summary>
		public virtual CubeSettings GetCubeSettings(Player player) {
			return new CubeSettings();
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
		/// How much MP you need to use the cube. Unless you want to use this, you should probably use SetManaCost.
		/// </summary>
		public int requireMana = 25;
		/// <summary>
		/// How much MP the cube takes when using it. Unless you want to use this, you should probably use SetManaCost.
		/// </summary>
		public int takeMana = 25;
		/// <summary>
		/// How much HP you need to use the cube.
		/// </summary>
		public int requireLife;

		/// <summary>
		/// The projectile the cube fires. 0 is none.
		/// </summary>
		public int projectileID;
		/// <summary>
		/// Damage of the projectile the cube fires.
		/// </summary>
		public int projectileDamage;
		/// <summary>
		/// Knockback of the projectile the cube fires.
		/// </summary>
		public float projectileKnockback;

		/// <summary>
		/// The buff the cube gives you when used. 0 is none.
		/// </summary>
		public int buffID;
		/// <summary>
		/// The duration of the cube's buff, in frames. Use <c>eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public int buffDuration;
		/// <summary>
		/// The debuff the cube gives you when used, since pre-ML can't get too easy. 0 is none.
		/// </summary>
		public int backfireBuffID;
		/// <summary>
		/// The duration of the cube's debuff, in frames. Use <c>eggpack.ToFrames(seconds)</c> for seconds.
		/// </summary>
		public int backfireBuffDuration;
		/// <summary>
		/// How much HP the cube damages you for when used. 0 is none.
		/// </summary>
		public int backfireDamage;
	}
}