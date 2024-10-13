using Terraria;
using Terraria.ID;

namespace Eggpack.Elements.Projectiles.Spear
{
	public class SlimeTridentProjectile : SpearProjectile
	{
		protected override float HoldoutRangeMin => 48f;
		protected override float HoldoutRangeMax => 128;
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Spear);
		}
	}
}