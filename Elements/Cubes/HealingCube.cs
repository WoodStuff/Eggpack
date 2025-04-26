using Eggpack.Elements.Buffs;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Cubes;

public class HealingCube : Cube
{
	public override void CustomDefaults()
	{
		Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 50));
	}
	public override CubeSettings GetCubeSettings()
	{
		CubeSettings settings = new()
		{
			cooldown = Eggpack.ToFrames(25),
			manaCost = 20,

			healLife = 25,

			debuffID = ModContent.BuffType<Paperskin>(),
			debuffDuration = Eggpack.ToFrames(8),
		};

		return settings;
	}
	public override void AddRecipes()
	{
		CreateRecipe()
			.AddRecipeGroup(ModRecipeGroup.EvilBar, 8)
			.AddIngredient(ItemID.LesserHealingPotion, 15)
			.AddTile(TileID.Anvils)
			.Register();
	}
}