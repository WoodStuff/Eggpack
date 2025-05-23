﻿using Terraria;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Summoner.MetalOrbSummon;

public class MetalOrbBuff : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.buffNoSave[Type] = true;
		Main.buffNoTimeDisplay[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		if (player.ownedProjectileCounts[ModContent.ProjectileType<MetalOrb>()] > 0)
			player.buffTime[buffIndex] = 18000;
		else
		{
			player.DelBuff(buffIndex);
			buffIndex--;
		}
	}
}