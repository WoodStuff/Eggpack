using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace eggpack
{
    public class EggPlayer : ModPlayer
    {
        public bool hasHellSharpener;
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (hasHellSharpener) target.AddBuff(BuffID.OnFire, 180);
        }
    }
}