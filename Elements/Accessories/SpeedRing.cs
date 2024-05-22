using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Accessories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class SpeedRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+10% movement speed");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 0, 80, 0);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(ModRecipeGroup.SilverBar, 6)
				.AddIngredient(ItemID.Emerald)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed *= 1.1f;
			player.maxRunSpeed *= 1.1f;
			player.runAcceleration *= 1.4f;
			player.runSlowdown *= 1.4f;
		}
	}
}