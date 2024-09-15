using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Eggpack.Elements.Projectiles.Slicers;
using Eggpack.Elements.Items;

namespace Eggpack.Elements.Weapons.Ranged.Slicers
{
	public class ThingiteSlicer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults()
		{
			Item.DefaultToThrownWeapon(ModContent.ProjectileType<ThingiteSlicerProjectile>(), 18, 10);
			Item.SetWeaponValues(15, 2, 4);
			Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 0, 50));

			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe(75)
				.AddIngredient<ThingiteBar>()
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}