using System.Collections.Generic;
using Eggpack.Elements.Prefixes.Cubes;
using Terraria;
using Terraria.ModLoader;

namespace Eggpack.Elements.Prefixes;

public class PrefixTooltipGlobalItem : GlobalItem
{
	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		bool prefixed = true;
		TooltipLine g1 = new(Mod, "CubePrefix", "") { IsModifier = true };
		TooltipLine g2 = new(Mod, "CubePrefix", "") { IsModifier = true };
		TooltipLine g3 = new(Mod, "CubePrefix", "") { IsModifier = true };
		TooltipLine g4 = new(Mod, "CubePrefix", "") { IsModifier = true };
		TooltipLine b1 = new(Mod, "CubePrefix", "") { IsModifier = true, IsModifierBad = true };
		TooltipLine b2 = new(Mod, "CubePrefix", "") { IsModifier = true, IsModifierBad = true };
		TooltipLine b3 = new(Mod, "CubePrefix", "") { IsModifier = true, IsModifierBad = true };
		TooltipLine b4 = new(Mod, "CubePrefix", "") { IsModifier = true, IsModifierBad = true };

		switch (item.prefix)
		{
			case int p when p == ModContent.PrefixType<Fast>():
				g1.Text = "-5% cooldown duration";
				break;
			case int p when p == ModContent.PrefixType<Quick>():
				g1.Text = "-10% cooldown duration";
				break;
			case int p when p == ModContent.PrefixType<Empowered>():
				g1.Text = "+20% buff duration";
				break;
			case int p when p == ModContent.PrefixType<Powerful>():
				g1.Text = "+8% damage";
				g2.Text = "+15% knockback";
				break;
			case int p when p == ModContent.PrefixType<Merciful>():
				g1.Text = "-20% backfire duration";
				break;
			case int p when p == ModContent.PrefixType<Healthy>():
				g1.Text = "+15% healing";
				break;
			case int p when p == ModContent.PrefixType<Efficient>():
				g1.Text = "-10% cooldown";
				g2.Text = "+10% damage";
				break;
			case int p when p == ModContent.PrefixType<Sharp>():
				g1.Text = "+15% damage";
				break;
			case int p when p == ModContent.PrefixType<Legendary>():
				g1.Text = "+8% damage";
				g2.Text = "-10% cooldown";
				g3.Text = "+15% knockback";
				g4.Text = "-20% mana cost";
				break;
			case int p when p == ModContent.PrefixType<Mythic>():
				g1.Text = "-50% mana cost";
				break;
			case int p when p == ModContent.PrefixType<Intense>():
				g1.Text = "+10% damage";
				b1.Text = "+15% mana cost";
				break;
			case int p when p == ModContent.PrefixType<Impatient>():
				g1.Text = "-20% cooldown";
				b1.Text = "-20% damage";
				break;
			case int p when p == ModContent.PrefixType<Sacrificial>():
				g1.Text = "+15% damage";
				b1.Text = "+30% life taken";
				break;
			case int p when p == ModContent.PrefixType<Lengthened>():
				g1.Text = "+25% buff duration";
				b1.Text = "+25% backfire duration";
				break;
			case int p when p == ModContent.PrefixType<Charged>():
				g1.Text = "+25% damage";
				b1.Text = "+20% cooldown";
				break;
			case int p when p == ModContent.PrefixType<Rapid>():
				g1.Text = "-8% cooldown";
				g2.Text = "+15% velocity";
				b1.Text = "-10% damage";
				break;
			case int p when p == ModContent.PrefixType<Forceful>():
				g1.Text = "+15% knockback";
				break;
			case int p when p == ModContent.PrefixType<Generous>():
				g1.Text = "-15% cooldown";
				b1.Text = "-15% healing";
				break;
			case int p when p == ModContent.PrefixType<Energized>():
				g1.Text = "-20% cooldown";
				b1.Text = "+25% mana cost";
				break;
			case int p when p == ModContent.PrefixType<Frugal>():
				g1.Text = "-25% mana cost";
				b1.Text = "+10% cooldown";
				break;
			case int p when p == ModContent.PrefixType<Slow>():
				b1.Text = "+15% cooldown";
				break;
			case int p when p == ModContent.PrefixType<Wasteful>():
				b1.Text = "+20% mana cost";
				break;
			case int p when p == ModContent.PrefixType<Broken>():
				b1.Text = "+10% mana cost";
				b2.Text = "+10% cooldown";
				b3.Text = "-15% buff duration";
				break;
			case int p when p == ModContent.PrefixType<Weak>():
				b1.Text = "+10% mana cost";
				b2.Text = "+10% cooldown";
				b3.Text = "-20% damage";
				b4.Text = "-15% knockback";
				break;
			case int p when p == ModContent.PrefixType<Lazy>():
				b1.Text = "-20% healing";
				break;
			case int p when p == ModContent.PrefixType<Punishing>():
				b1.Text = "+25% backfire duration";
				break;
			case int p when p == ModContent.PrefixType<Spherical>():
				b1.Text = "-25% damage";
				b2.Text = "-15% knockback";
				b3.Text = "-25% velocity";
				break;
			case int p when p == ModContent.PrefixType<Inferior>():
				b1.Text = "-15% damage";
				break;
			case int p when p == ModContent.PrefixType<Crude>():
				b1.Text = "-20% buff duration";
				break;
			case int p when p == ModContent.PrefixType<Exhaustive>():
				b1.Text = "+50% mana cost";
				break;
			default:
				prefixed = false;
				break;
		}

		if (prefixed)
		{
			if (g1.Text != "") tooltips.Add(g1);
			if (g2.Text != "") tooltips.Add(g2);
			if (g3.Text != "") tooltips.Add(g3);
			if (g4.Text != "") tooltips.Add(g4);
			if (b1.Text != "") tooltips.Add(b1);
			if (b2.Text != "") tooltips.Add(b2);
			if (b3.Text != "") tooltips.Add(b3);
			if (b4.Text != "") tooltips.Add(b4);
		}
	}
}