using Eggpack.Elements.Buffs;
using Eggpack.Elements.Items;
using Eggpack.Elements.Projectiles.Cube;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Cubes;

public class PearlstoneCube : Cube
{
	public override void CustomDefaults()
	{
		Item.SetShopValues(ItemRarityColor.LightRed4, Item.sellPrice(0, 1));
	}
	public override CubeSettings GetCubeSettings()
	{
		CubeSettings settings = new()
		{
			cooldown = Eggpack.ToFrames(1),
			manaCost = 50,

			projectileID = ModContent.ProjectileType<PearlstoneRockBig>(),
			projectileSpeed = 14,
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