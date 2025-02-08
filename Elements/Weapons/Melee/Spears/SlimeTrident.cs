using Eggpack.Elements.Projectiles.Spear;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Melee.Spears;

public class SlimeTrident : ModItem
{
	public override void SetStaticDefaults()
	{
		ItemID.Sets.Spears[Item.type] = true; // This allows the game to recognize our new item as a spear.
		Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		Item.DefaultToSpear(ModContent.ProjectileType<SlimeTridentProjectile>(), 6, 32);
		Item.SetWeaponValues(24, 5, 0);
		Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 30, 0));
		Item.DamageType = DamageClass.Melee;

		Item.width = 40;
		Item.height = 40;
		Item.UseSound = SoundID.Item71;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.Gel, 30)
			.AddRecipeGroup(RecipeGroupID.IronBar, 4)
			.AddTile(TileID.Solidifier)
			.Register();
	}

	public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] < 1;
}