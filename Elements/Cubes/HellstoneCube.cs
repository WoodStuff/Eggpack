using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;

namespace Eggpack.Elements.Cubes;

public class HellstoneCube : Cube
{
	/// <summary>
	/// Radius of the circle to set things on fire in.
	/// </summary>
	private const float radius = 50 * 16;

	public override void CustomDefaults()
	{
		Item.SetShopValues(ItemRarityColor.Orange3, Item.sellPrice(0, 1));
	}

	public override CubeSettings GetCubeSettings()
	{
		CubeSettings settings = new()
		{
			cooldown = Eggpack.ToFrames(25),
			manaCost = 50,

			buffDuration = 5,
			debuffDuration = 10,

			buffPrefix = true,
			debuffPrefix = true,
		};

		return settings;
	}

	public override void OnActivate(Player player)
	{
		CubeSettings cubeSettings = GetModifiedStats(player);

		foreach (var npc in Main.ActiveNPCs)
		{
			if (Vector2.Distance(player.Center, npc.Center) <= radius)
			{
				npc.AddBuff(BuffID.OnFire3, (int)Eggpack.ToFrames(cubeSettings.buffDuration));
			}
		}

		foreach (var otherPlayer in Main.ActivePlayers)
		{
			if (!otherPlayer.dead && Vector2.Distance(player.Center, otherPlayer.Center) <= radius)
			{
				otherPlayer.AddBuff(BuffID.OnFire, (int)Eggpack.ToFrames(cubeSettings.debuffDuration));
			}
		}
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient(ItemID.HellstoneBar, 10)
			.AddTile(TileID.Anvils)
			.Register();
	}
}