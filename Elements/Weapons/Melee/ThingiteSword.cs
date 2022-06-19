using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.Weapons.Melee
{
	public class ThingiteSword : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Critical strikes weaken enemies");
		}
        public override void SetDefaults() 
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.2f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(null, "ThingiteBar", 10)
				.AddTile(TileID.Anvils)
				.Register();
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			if (!crit) return;
			target.AddBuff(BuffID.Weak, 180);
        }
    }
}