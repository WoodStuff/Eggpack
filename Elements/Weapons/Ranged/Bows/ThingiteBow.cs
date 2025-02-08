using Eggpack.Elements.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Ranged.Bows;

public class ThingiteBow : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		int damage = 13;
		int speed = 25;
		float velocity = 8f;
		float knockback = 6f;

		Item.DefaultToBow(speed, velocity);

		Item.width = 16;
		Item.height = 32;
		Item.scale = 1.2f;

		Item.damage = damage;
		Item.knockBack = knockback;

		Item.value = Item.sellPrice(0, 0, 15, 0);
		Item.rare = ItemRarityID.Blue;
	}
	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<ThingiteBar>(7)
			.AddTile(TileID.Anvils)
			.Register();
	}
}