using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.Weapons.Ranged
{
	public class ThingiteBow : ModItem {
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PlatinumBow);
			Item.damage = 13;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(0, 0, 15, 0);
			Item.rare = ItemRarityID.Blue;
			Item.scale = 1.2f;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "ThingiteBar", 7)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}