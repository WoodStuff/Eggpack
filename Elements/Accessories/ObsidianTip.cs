using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Accessories
{
	public class ObsidianTip : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<ClayTip>()
				.AddIngredient(ItemID.Obsidian, 15)
				.AddRecipeGroup(ModRecipeGroup.EvilMaterials, 4)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Ranged) += 0.02f;
			player.GetCritChance(DamageClass.Ranged) += 4f;
		}
	}
}