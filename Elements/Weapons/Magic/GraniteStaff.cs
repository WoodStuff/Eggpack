using Eggpack.Elements.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Magic
{
	/// <summary>
	/// A magic weapon that shoots out 3 projectiles.
	/// </summary>
	public class GraniteStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.DefaultToStaff(ModContent.ProjectileType<GraniteStaffProjectile>(), 10, 28, 10);
			Item.SetWeaponValues(20, 5, 5);
			Item.SetShopValues(ItemRarityColor.Green2, 13000);
			Item.width = 48;
			Item.height = 18;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(30)), type, damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(-30)), type, damage, knockback, player.whoAmI);
			return true;
		}
	}
}