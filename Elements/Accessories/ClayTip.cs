using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Eggpack.Elements.Accessories
{
	public class ClayTip : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 16;
			Item.value = Item.sellPrice(0, 0, 15, 0);
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ClayBlock, 50)
				.AddIngredient(ItemID.StoneBlock, 20)
				.AddTile(TileID.WorkBenches)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Ranged) += 4f;
		}
	}
}