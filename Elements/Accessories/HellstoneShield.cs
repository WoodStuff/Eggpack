using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class HellstoneShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+5% critical strike chance");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 350000;
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.defense = 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(null, "ReinforcedShield")
			.AddIngredient(ItemID.HellstoneBar, 10)
			.AddTile(TileID.Anvils)
			.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Generic) += 5f;
		}
	}
}