using Eggpack.Common.Systems;
using System;
using Terraria.ModLoader;

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

		public override object Call(params object[] args)
		{
			if (args is null)
			{
				throw new ArgumentNullException(nameof(args), "Arguments cannot be null!");
			}

			if (args.Length == 0)
			{
				throw new ArgumentException("Arguments cannot be empty!");
			}
			if (args[0] is string content)
			{
				switch (content)
				{
					case "downedRulerOfEggs":
						return DownedBossSystem.downedRulerOfEggs;
				}
			}
			return false;
		}
	}
}
