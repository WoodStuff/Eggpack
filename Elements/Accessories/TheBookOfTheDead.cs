using Eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Eggpack.Elements.Accessories
{
	public class TheBookOfTheDead : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Increases your max number of minions by 3\n16% increased summon damage");
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 50, 0, 0);
			Item.rare = ItemRarityID.Pink;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "PygmyEmblem")
				.AddIngredient(ItemID.PapyrusScarab)
				.AddIngredient(ItemID.Ectoplasm, 10)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Summon) += 0.16f;
			player.maxMinions += 3;
			player.GetKnockback(DamageClass.Summon).Flat += 2f;
		}
    }
}