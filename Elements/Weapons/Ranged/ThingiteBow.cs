using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Ranged
{
	public class ThingiteBow : ModItem {
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			int damage = 13;
			int speed = 25;
			float velocity = 8f;
			float knockback = 6f;

			Item.DefaultToBow(speed, velocity);

			Item.width = 16;
			Item.height = 32;
			Item.scale = 1.2f;

			Item.damage = damage;
			Item.knockBack = knockback;

			Item.value = Item.sellPrice(0, 0, 15, 0);
			Item.rare = ItemRarityID.Blue;
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