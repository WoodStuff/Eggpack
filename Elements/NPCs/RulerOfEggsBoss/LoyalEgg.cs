﻿using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.NPCs.RulerOfEggsBoss;

/// <summary>
/// The Ruler of Eggs' minion that appears in the Summon attack.
/// </summary>
public class LoyalEgg : ModNPC
{
	public override void SetDefaults()
	{
		NPC.width = 32;
		NPC.height = 32;
		NPC.damage = 30;
		NPC.defense = 10;
		NPC.lifeMax = 75;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		NPC.value = 40;
		NPC.knockBackResist = 0.6f;
		NPC.aiStyle = NPCAIStyleID.Slime;
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		bestiaryEntry.Info.AddRange([
			BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

			new FlavorTextBestiaryInfoElement("Sometimes, eggs become alive and fight anyone they see for the empire.")
		]);
	}
}