using Eggpack.Elements.Items;
using Eggpack.Elements.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Melee.Swords
{
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
			Item.SetWeaponValues(18, 7, 3);
			Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 1, 0, 0));
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 48;
			Item.useAnimation = 24;
			Item.shoot = ModContent.ProjectileType<GraniteSwordProjectile>();
			Item.shootSpeed = 9f;
			Item.scale = 1.1f;

			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item1;
		}
	}
}