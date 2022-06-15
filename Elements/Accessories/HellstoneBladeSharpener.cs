using eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Accessories
{
	public class HellstoneBladeSharpener : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+6% melee damage, +7% melee critical strike chance\n50% chance to set struck enemies on fire");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BladeSharpener")
				.AddIngredient(ItemID.HellstoneBar, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Melee) += 0.06f;
			player.GetCritChance(DamageClass.Melee) += 7f;
			player.GetModPlayer<EggPlayer>().hasHellSharpener = true;
		}
	}
}