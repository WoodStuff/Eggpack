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
	public class WeaponExhaustion : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Weapon Exhaustion");
			// Description.SetDefault("Weapons are slowed down by 25%");
			Main.debuff[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetAttackSpeed(DamageClass.Generic) *= 0.75f;
		}
	}
}