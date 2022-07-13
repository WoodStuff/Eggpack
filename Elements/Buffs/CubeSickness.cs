using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Elements.Buffs
{
	public class CubeSickness : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cube Cooldown");
			Description.SetDefault("Cannot use any cubes");
			Main.debuff[Type] = true;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		}
	}
}
