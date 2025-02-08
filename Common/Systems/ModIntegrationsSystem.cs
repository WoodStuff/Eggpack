using System;
using System.Collections.Generic;
using Eggpack.Elements.Items;
using Eggpack.Elements.Items.Tiles;
using Eggpack.Elements.NPCs.RulerOfEggsBoss;
using Eggpack.Elements.Weapons.Melee.Swords;
using Terraria.ModLoader;

namespace Eggpack.Common.Systems;

public class ModIntegrationsSystem : ModSystem
{
	public override void PostSetupContent()
	{
		DoBossChecklistIntegration();
	}

	private void DoBossChecklistIntegration()
	{
		if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
			return;

		string internalName = "RulerOfEggs";

		float weight = 3.75f;

		Func<bool> downed = () => DownedBossSystem.downedRulerOfEggs;

		int bossType = ModContent.NPCType<RulerOfEggs>();

		int spawnItem = ModContent.ItemType<EggSplatter>();

		List<int> collectibles =
		[
			ModContent.ItemType<YolkShard>(),
				ModContent.ItemType<Yolkifier>(),
			];

		bossChecklistMod.Call(
			"LogBoss",
			Mod,
			internalName,
			weight,
			downed,
			bossType,
			new Dictionary<string, object>()
			{
				["spawnItems"] = spawnItem,
				["collectibles"] = collectibles,
			}
		);
	}
}