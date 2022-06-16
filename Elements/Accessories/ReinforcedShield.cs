using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ReinforcedShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 250000;
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.defense = 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Shackle)
			.AddIngredient(null, "WoodenShield")
			.AddIngredient(null, "ThingiteShield")
			.AddTile(TileID.TinkerersWorkbench)
			.Register();
		}
	}
}