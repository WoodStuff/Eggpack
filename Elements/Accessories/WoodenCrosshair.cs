using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Accessories;

public class WoodenCrosshair : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 46;
		Item.height = 46;
		Item.value = Item.sellPrice(0, 0, 1, 50);
		Item.rare = ItemRarityID.White;
		Item.accessory = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup(RecipeGroupID.Wood, 30)
			.AddTile(TileID.WorkBenches)
			.Register();
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetCritChance(DamageClass.Generic) += 2f;
	}
}