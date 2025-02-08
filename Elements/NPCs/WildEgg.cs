using Eggpack.Elements.Items;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Eggpack.Elements.NPCs;

/// <summary>
/// A wild egg that sometimes drops Yolk Shards and can be used to summon the Ruler of Eggs.
/// </summary>
public class WildEgg : ModNPC
{
	public override void SetDefaults()
	{
		NPC.width = 32;
		NPC.height = 32;
		NPC.damage = 15;
		NPC.defense = 4;
		NPC.lifeMax = 50;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		NPC.value = 100;
		NPC.knockBackResist = 0.75f;
		NPC.aiStyle = NPCAIStyleID.Slime;
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		return SpawnCondition.OverworldDay.Chance * 0.25f;
	}

	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<YolkShard>(), 30));
		npcLoot.Add(ItemDropRule.Common(ItemID.FriedEgg, 50));
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		bestiaryEntry.Info.AddRange([
			BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

			new FlavorTextBestiaryInfoElement("Sometimes, eggs become alive and fight anyone they see for the empire.")
		]);
	}
}