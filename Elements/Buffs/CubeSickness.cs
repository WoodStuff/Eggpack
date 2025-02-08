using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Buffs;

public class CubeSickness : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
	}
}
