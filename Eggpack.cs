using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace Eggpack
{
	public class Eggpack : Mod
	{
		public static float ToFrames(float secs)
		{
			return secs * 60;
		}
		public static float ToSeconds(float frames)
		{
			return frames / 60;
		}
	}
}
