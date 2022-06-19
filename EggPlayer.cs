using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using System.Collections.Generic;
using System;

namespace eggpack
{
	public class EggPlayer : ModPlayer
	{
		public bool hasHellSharpener;

		public override void ResetEffects()
		{
			hasHellSharpener = false;
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			Random rng = new();
			if (hasHellSharpener && rng.Next(1) == 0) target.AddBuff(BuffID.OnFire, 180);
		}
    }
}