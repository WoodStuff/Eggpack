using Eggpack.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Accessories;

public class HellstoneBladeSharpener : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 28;
		Item.value = Item.sellPrice(0, 0, 60, 0);
		Item.rare = ItemRarityID.Orange;
		Item.accessory = true;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<BladeSharpener>()
			.AddIngredient(ItemID.HellstoneBar, 10)
			.AddTile(TileID.Anvils)
			.Register();
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetDamage(DamageClass.Melee) += 0.02f;
		player.GetCritChance(DamageClass.Melee) += 6f;
		player.GetModPlayer<EggPlayer>().hasHellSharpener = true;
	}
}