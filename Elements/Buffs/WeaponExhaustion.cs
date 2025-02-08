using Terraria;
using Terraria.ModLoader;

namespace Eggpack.Elements.Buffs;

public class WeaponExhaustion : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
	}
	public override void Update(Player player, ref int buffIndex)
	{
		player.GetAttackSpeed(DamageClass.Generic) *= 0.75f;
	}
}