using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Accessories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class ManaRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("-10% mana cost\n+20 max mana");
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
				.AddIngredient(ItemID.Sapphire)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaCost -= 0.1f;
			player.statManaMax2 += 20;
		}
	}
}