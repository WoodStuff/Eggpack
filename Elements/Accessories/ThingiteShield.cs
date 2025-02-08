using Eggpack.Elements.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Accessories;

[AutoloadEquip(EquipType.Shield)]
public class ThingiteShield : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 30;
		Item.height = 30;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.rare = ItemRarityID.Blue;
		Item.accessory = true;
		Item.defense = 2;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient<ThingiteBar>(5)
		.AddIngredient<WoodenShield>()
		.AddTile(TileID.Anvils)
		.Register();
	}
}