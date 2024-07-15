using Eggpack.Elements.Tools;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Summoner.Whips.Debuffs
{
	public class WoodenWhipDebuff : ModBuff
	{
		public static readonly int TagDamage = 5;

		public override void SetStaticDefaults()
		{
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}

	public class WoodenWhipDebuffNPC : GlobalNPC
	{
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
		{
			if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated) return;

			var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
			if (npc.HasBuff<WoodenWhipDebuff>())
			{
				modifiers.FlatBonusDamage += WoodenWhipDebuff.TagDamage * projTagMultiplier;
			}
		}
	}
}