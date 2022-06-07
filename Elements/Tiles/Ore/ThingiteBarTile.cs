﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace eggpack.Elements.Tiles.Ore
{
	public class ThingiteBarTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileShine[Type] = 1100;
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("ThingiteBar");
			AddMapEntry(new Color(100, 100, 120), Language.GetText("MapObject.MetalBar"));

			DustType = 84;
			ItemDrop = ModContent.ItemType<Elements.Items.Tile.ThingiteBar>();
		}
	}
}
