using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Eggpack.Elements.Tiles.Ore;

public class ThingiteOreTile : ModTile
{
	public override void SetStaticDefaults()
	{
		TileID.Sets.Ore[Type] = true;
		Main.tileSpelunker[Type] = true;
		Main.tileOreFinderPriority[Type] = 420;
		Main.tileShine2[Type] = true;
		Main.tileShine[Type] = 975;
		Main.tileMergeDirt[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;

		LocalizedText name = CreateMapEntryName();
		AddMapEntry(new Color(140, 180, 219), name);

		DustType = DustID.Platinum;
		MinPick = 40;
	}
}
public class ThingiteOreSystem : ModSystem
{
	public static LocalizedText ThingiteOrePassMessage { get; private set; }

	public override void SetStaticDefaults()
	{
		ThingiteOrePassMessage = Mod.GetLocalization($"WorldGen.{nameof(ThingiteOrePassMessage)}");
	}

	public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
	{
		int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

		if (ShiniesIndex != -1)
		{
			tasks.Insert(ShiniesIndex + 1, new ThingiteOrePass("Egg Ores", 237.4298f));
		}
	}
}

public class ThingiteOrePass(string name, float loadWeight) : GenPass(name, loadWeight)
{
	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	{
		progress.Message = ThingiteOreSystem.ThingiteOrePassMessage.Value;

		for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 0.00015); k++)
		{
			int x = WorldGen.genRand.Next(0, Main.maxTilesX);
			int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY);

			WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(1, 2), ModContent.TileType<ThingiteOreTile>());

		}
	}
}