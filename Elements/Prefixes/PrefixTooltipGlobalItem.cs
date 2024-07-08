using eggpack.Elements.Prefixes.Cubes;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace eggpack.Elements.Prefixes
{
	public class PrefixTooltipGlobalItem : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			bool prefixed = true;
			TooltipLine line  = new(Mod, "CubePrefix", "") { IsModifier = true };
			TooltipLine line2 = new(Mod, "CubePrefix", "") { IsModifier = true };

			if (item.prefix == ModContent.PrefixType<Fast>()) { line.Text = "-10% cooldown duration"; }
			else if (item.prefix == ModContent.PrefixType<Quick>()) { line.Text = "-15% cooldown duration"; }

			else { prefixed = false; }
			if (prefixed)
			{
				tooltips.Add(line);
				if (line2.Text != "") tooltips.Add(line2);
			}
		}
	}
}