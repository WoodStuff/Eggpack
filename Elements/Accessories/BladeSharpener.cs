using Eggpack.Elements.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Eggpack.Elements.Accessories
{
	public class BladeSharpener : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 28;
			Item.value = Item.sellPrice(0, 0, 80, 0);
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.StoneBlock, 50)
				.AddIngredient(ItemID.Diamond, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Melee) += 0.02f;
			player.GetCritChance(DamageClass.Melee) += 3f;
		}
	}
}