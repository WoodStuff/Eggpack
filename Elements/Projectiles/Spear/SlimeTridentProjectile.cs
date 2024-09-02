using Eggpack.Elements.Items;
using Eggpack.Elements.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

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