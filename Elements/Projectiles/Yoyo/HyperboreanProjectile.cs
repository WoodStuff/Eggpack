using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Projectiles.Yoyo;

public class HyperboreanProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 6.5f;
		ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 208;
		ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12f;
	}

	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 16;

		Projectile.aiStyle = ProjAIStyleID.Yoyo;

		Projectile.friendly = true;
		Projectile.DamageType = DamageClass.MeleeNoSpeed;
		Projectile.penetrate = -1;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(BuffID.Frostburn, 3 * 60);
	}
}