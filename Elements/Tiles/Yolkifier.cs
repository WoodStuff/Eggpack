using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Eggpack.Elements.Tiles;

public class Yolkifier : ModTile
{
	public override void SetStaticDefaults()
	{
		Main.tileNoAttach[Type] = true;
		Main.tileFrameImportant[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;

		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.addTile(Type);

		AddMapEntry(new Color(200, 200, 200), Language.GetText("Tiles.Yolkifier.MapEntry"));
	}
}