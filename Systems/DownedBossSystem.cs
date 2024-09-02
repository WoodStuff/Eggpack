using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Eggpack.Systems
{
	public class DownedBossSystem : ModSystem
	{
		public static bool downedRulerOfEggs = false;
		// public static bool downedOtherBoss = false;

		public override void ClearWorld()
		{
			downedRulerOfEggs = false;
			// downedOtherBoss = false;
		}

		public override void SaveWorldData(TagCompound tag)
		{
			if (downedRulerOfEggs)
			{
				tag["downedRulerOfEggs"] = true;
			}

			// if (downedOtherBoss) {
			//    tag["downedOtherBoss"] = true;
			// }
		}

		public override void LoadWorldData(TagCompound tag)
		{
			downedRulerOfEggs = tag.ContainsKey("downedRulerOfEggs");
			// downedOtherBoss = tag.ContainsKey("downedOtherBoss");
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedRulerOfEggs;
			// flags[1] = downedOtherBoss;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedRulerOfEggs = flags[0];
			// downedOtherBoss = flags[1];
		}
	}
}