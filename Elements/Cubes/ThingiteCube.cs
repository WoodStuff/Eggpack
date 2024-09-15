using Eggpack.Elements.Buffs;
using Eggpack.Elements.Items;
using Eggpack.Elements.Projectiles;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Cubes
{
	public class ThingiteCube : Cube
	{
		public override void CustomDefaults()
		{
			Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 50));
		}
		public override CubeSettings GetCubeSettings()
		{
			CubeSettings settings = new()
			{
				cooldown = Eggpack.ToFrames(20),
				manaCost = 40,

				projectileID = ModContent.ProjectileType<ThingiteBurst>(),
				projectileSpeed = 10,
				damages = true,

				debuffID = ModContent.BuffType<WeaponExhaustion>(),
				debuffDuration = Eggpack.ToFrames(10),
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