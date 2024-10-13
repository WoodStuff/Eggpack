using Eggpack.Elements.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Tools
{
	public class ThingiteHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.hammer = 65;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient<ThingiteBar>(6)
			.AddRecipeGroup(RecipeGroupID.Wood, 4)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}