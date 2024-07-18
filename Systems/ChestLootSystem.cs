using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Systems
{
	public class ChestLootSystem : ModSystem
	{
		public override void PostWorldGen()
		{
            foreach (var chest in Main.chest)
            {
				if (chest == null || Main.tile[chest.x, chest.y].TileType != TileID.Containers) continue;
				switch (Main.tile[chest.x, chest.y].TileFrameX)
				{
					case 50 * 36: // granite chest
						// shift all chest items if the first slot isn't free and avoid shifting it if it's empty
						if (!(chest.item.Length == 0 || chest.item[0] == null || chest.item[0].IsAir))
						{
							ShiftChestItems(chest);
						} // from here the first slot is free and we can put items into it

						chest.item[0].SetDefaults(Mod.Find<ModItem>("GraniteStaff").Type);

						break;
				}

            }
        }
		private void ShiftChestItems(Chest chest)
		{
			for (int k = 39; k > 0; k--)
			{
				ref Item itemToShiftTo = ref chest.item[k];
				Utils.Swap(ref chest.item[k], ref chest.item[k - 1]);
			}
		}
	}
}