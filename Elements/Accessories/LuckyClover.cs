using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Accessories
{
	public class LuckyClover : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+4% critical strike chance");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 40000;
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Blinkroot, 2)
				.AddIngredient(ItemID.Daybloom, 3)
				.AddIngredient(ItemID.Sunflower)
				.AddTile(TileID.WorkBenches)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Generic) += 4f;
		}
	}
}