using Eggpack.Elements.Items;
using Eggpack.Elements.Projectiles.Slicers;
using Eggpack.Elements.Tiles;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Ranged.Slicers;

public class YolkDagger : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 99;
	}

	public override void SetDefaults()
	{
		Item.DefaultToThrownWeapon(ModContent.ProjectileType<YolkDaggerProjectile>(), 10, 12.5f);
		Item.SetWeaponValues(13, 1f, 6);
		Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 0, 50));

		Item.width = 32;
		Item.height = 32;
		Item.UseSound = SoundID.Item1;
		Item.noUseGraphic = true;
	}

	public override bool ConsumeItem(Player player)
	{
		return Main.rand.NextFloat() >= 0.33f;
	}

	public override void AddRecipes()
	{
		CreateRecipe(350)
			.AddIngredient<YolkShard>()
			.AddTile<Yolkifier>()
			.Register();
	}
}