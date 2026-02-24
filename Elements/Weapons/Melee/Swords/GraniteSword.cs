using Eggpack.Elements.Projectiles;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Melee.Swords;

/// <summary>
/// A sword that fires a Granite Orb, found in Granite Chests.
/// </summary>
public class GraniteSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		Item.CloneDefaults(ItemID.IceBlade);

		// sword properties
		Item.DamageType = DamageClass.Melee;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;

		// sword stats
		Item.damage = 18;
		Item.knockBack = 7;
		Item.useTime = 48;
		Item.useAnimation = 24;
		Item.crit = 3;
		Item.scale = 1.1f;

		// projectile stats
		Item.shoot = ModContent.ProjectileType<GraniteSwordProjectile>();
		Item.shootSpeed = 9f;

		// item properties
		Item.width = 40;
		Item.height = 40;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Green;
	}
}