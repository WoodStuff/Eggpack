using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.Weapons.Summoner.SMetalOrb
{
	public class MetalOrbBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Metal Orb");
			Description.SetDefault("The metal orb will fight for you");

			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<MetalOrb>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}