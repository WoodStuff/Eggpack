using Terraria;
using Terraria.ModLoader;

namespace Eggpack.Elements.Buffs;

public class Paperskin : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
	}
	public override void Update(Player player, ref int buffIndex)
	{
		player.statDefense -= 8;
	}
}