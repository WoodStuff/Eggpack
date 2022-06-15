using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.Weapons
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }
    public override void SetDefaults()
    {
		Item.damage = 13;
		Item.DamageType = DamageClass.Ranged;
		Item.width = 40;
		Item.height = 40;
		Item.useTime = 19;
		Item.useAnimation = 19;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 6;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Blue;
		Item.UseSound = SoundID.Item1;
		Item.scale = 1.2f;
	}
}
	public override void AddRecipes()
    {
		CreateRecipe()
				.AddIngredient(null, "ThingiteBar", 7)
				.AddTile(TileID.Anvils)
				.Register();
	}
}