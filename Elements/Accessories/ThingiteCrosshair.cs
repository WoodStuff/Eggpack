using Eggpack.Elements.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Accessories;

public class ThingiteCrosshair : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 46;
		Item.height = 46;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.White;
		Item.accessory = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<WoodenCrosshair>()
			.AddIngredient<ThingiteBar>(4)
			.AddTile(TileID.Anvils)
			.Register();
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetCritChance(DamageClass.Generic) += 5f;
	}
}