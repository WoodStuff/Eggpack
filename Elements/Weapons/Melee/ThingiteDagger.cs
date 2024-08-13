using Eggpack.Elements.Items;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Melee
{
	/// <summary>
	/// A quick sword with auto-swing, but low damage.
	/// </summary>
	public class ThingiteDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.crit = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.3f;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<ThingiteBar>(10)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}