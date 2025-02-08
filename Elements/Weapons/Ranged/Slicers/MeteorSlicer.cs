using Eggpack.Elements.Projectiles.Slicers;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Ranged.Slicers;

public class MeteorSlicer : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 99;
	}

	public override void SetDefaults()
	{
		Item.DefaultToThrownWeapon(ModContent.ProjectileType<MeteorSlicerProjectile>(), 18, 12);
		Item.SetWeaponValues(23, 2.5f, 4);
		Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 0, 75));

		Item.width = 32;
		Item.height = 32;
		Item.UseSound = SoundID.Item1;
		Item.noUseGraphic = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe(100)
			.AddIngredient(ItemID.MeteoriteBar)
			.AddTile(TileID.Anvils)
			.Register();
	}
}