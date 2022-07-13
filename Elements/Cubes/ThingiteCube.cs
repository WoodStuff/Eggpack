using eggpack.Elements.Buffs;
using eggpack.Elements.Items;
using eggpack.Elements.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.Cubes
{
	public class ThingiteCube : Cube
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault(
				"Costs 40 mana\n" +
				"Releases a Thingite Burst that does 60 damage, but slows down weapons by 25% for 10 seconds"
			);
		}
		public override void CustomDefaults()
		{
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.rare = ItemRarityID.White;
		}
		public override CubeSettings GetCubeSettings(Player player)
		{
			CubeSettings settings = new()
			{
				cooldown = eggpack.ToFrames(20),
				manaCost = 40,
				projectileID = ModContent.ProjectileType<ThingiteBurst>(),
				projectileSpeed = 10,
				backfireBuffID = ModContent.BuffType<WeaponExhaustion>(),
				backfireBuffDuration = eggpack.ToFrames(10),
			};

			return settings;
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