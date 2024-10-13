using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Eggpack.Elements.Projectiles.Yoyo;
using Terraria.Enums;

namespace Eggpack.Elements.Weapons.Melee.Yoyos
{
	public class Hyperborean : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 9;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.SetWeaponValues(17, 4.5f, 2);
			Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 1));

			Item.width = 24;
			Item.height = 24;

			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;

			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.channel = true;

			Item.shoot = ModContent.ProjectileType<HyperboreanProjectile>();
			Item.shootSpeed = 16f;
		}
	}
}
