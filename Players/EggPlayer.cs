using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Players
{
	/// <summary>
	/// The main player without any focus on anything.
	/// </summary>
	public class EggPlayer : ModPlayer
	{
		public bool hasHellSharpener;
		public int equippedCube;

		public override void ResetEffects()
		{
			hasHellSharpener = false;
			equippedCube = 0;
		}
		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)/* tModPorter If you don't need the Item, consider using OnHitNPC instead */
		{
			Random rng = new();
			if (hasHellSharpener && rng.Next(2) == 0) target.AddBuff(BuffID.OnFire, 180);
		}
	}
}