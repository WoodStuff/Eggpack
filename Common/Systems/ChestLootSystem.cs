using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Common.Systems
{
    /// <summary>
    /// The script for adding loot to vanilla world-generated chests.
    /// </summary>
    public class ChestLootSystem : ModSystem
    {
        private int graniteCounter = 0;

        public override void PostWorldGen()
        {
            // change gold chests into granite chests
            foreach (var chest in Main.chest)
            {
                // match only gold chests in front of unsafe granite walls
                if (chest == null
                    || Main.tile[chest.x, chest.y].TileType != TileID.Containers
                    || Main.tile[chest.x, chest.y].TileFrameX != 36
                    || Main.tile[chest.x, chest.y].WallType != WallID.GraniteUnsafe) continue;

                Main.tile[chest.x, chest.y].TileFrameX = 50 * 36;
                Main.tile[chest.x + 1, chest.y].TileFrameX = 50 * 36 + 18;
                Main.tile[chest.x, chest.y + 1].TileFrameX = 50 * 36;
                Main.tile[chest.x + 1, chest.y + 1].TileFrameX = 50 * 36 + 18;
            }

            // add chest loot
            foreach (var chest in Main.chest)
            {
                if (chest == null || Main.tile[chest.x, chest.y].TileType != TileID.Containers) continue;
                switch (Main.tile[chest.x, chest.y].TileFrameX)
                {
                    case 50 * 36: // granite chest
                                  // shift all chest items if the first slot isn't free and avoid shifting it if it's empty
                        if (!(chest.item.Length == 0 || chest.item[0] == null || chest.item[0].IsAir))
                            ShiftChestItems(chest);

                        switch (graniteCounter % 2)
                        {
                            case 0:
                                chest.item[0].SetDefaults(Mod.Find<ModItem>("GraniteStaff").Type);
                                break;
                            case 1:
                                chest.item[0].SetDefaults(Mod.Find<ModItem>("GraniteSword").Type);
                                break;
                            default:
                                break;
                        }
                        graniteCounter++;
                        if (WorldGen.genRand.NextBool()) chest.item[0].Prefix(-1);

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