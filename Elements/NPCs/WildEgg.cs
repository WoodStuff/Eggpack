using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using eggpack.Elements.Items;

namespace eggpack.Elements.NPCs
{
	public class WildEgg : ModNPC
	{
		public bool[] aggressive = { false, false };

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wild Egg");
		}

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
			NPC.aiStyle = -1;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<YolkShard>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDay.Chance * 0.5f;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.RottenEgg, 2));
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				new FlavorTextBestiaryInfoElement("Sometimes, eggs become alive and fight anyone they see for the empire.")
			});
		}

        public override void AI()
		{
			NPC.ai[1] = -1f;
			bool flag = false;
			if (!Main.dayTime || NPC.life != NPC.lifeMax || (double)NPC.position.Y > Main.worldSurface * 16.0)
			{
				flag = true;
				aggressive[0] = true;
			}
			if (NPC.ai[2] > 1f)
			{
				NPC.ai[2] -= 1f;
			}
			if (NPC.wet)
			{
				if (NPC.collideY)
				{
					NPC.velocity.Y = -2f;
				}
				if (NPC.velocity.Y < 0f && NPC.ai[3] == NPC.position.X)
				{
					NPC.direction *= -1;
					NPC.ai[2] = 200f;
				}
				if (NPC.velocity.Y > 0f)
				{
					NPC.ai[3] = NPC.position.X;
				}
				if (NPC.velocity.Y > 2f)
				{
					NPC.velocity.Y *= 0.9f;
				}
				NPC.velocity.Y -= 0.5f;
				if (NPC.velocity.Y < -4f)
				{
					NPC.velocity.Y = -4f;
				}
				if (NPC.ai[2] == 1f && flag)
				{
					NPC.TargetClosest();
				}
			}
			NPC.aiAction = 0;
			if (NPC.ai[2] == 0f)
			{
				NPC.ai[0] = -100f;
				NPC.ai[2] = 1f;
				NPC.TargetClosest();
			}
			if (NPC.velocity.Y == 0f)
			{
				if (NPC.collideY && NPC.oldVelocity.Y != 0f && Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
				{
					NPC.position.X -= NPC.velocity.X + (float)NPC.direction;
				}
				if (NPC.ai[3] == NPC.position.X)
				{
					NPC.direction *= -1;
					NPC.ai[2] = 200f;
				}
				NPC.ai[3] = 0f;
				NPC.velocity.X *= 0.8f;
				if ((double)NPC.velocity.X > -0.1 && (double)NPC.velocity.X < 0.1)
				{
					NPC.velocity.X = 0f;
				}
				if (flag)
				{
					NPC.ai[0] += 1f;
				}
				NPC.ai[0] += 1f;
				int num11 = 0;
				if (NPC.ai[0] >= 0f)
				{
					num11 = 1;
				}
				if (flag)
				{
					if (NPC.ai[0] >= -750f && NPC.ai[0] <= -250f)
					{
						num11 = 2;
					}
					if (NPC.ai[0] >= -1500f && NPC.ai[0] <= -1000f)
					{
						num11 = 3;
					}
				}
				else {
					if (NPC.ai[0] >= -1000f && NPC.ai[0] <= -500f)
					{
						num11 = 2;
					}
					if (NPC.ai[0] >= -2000f && NPC.ai[0] <= -1500f)
					{
						num11 = 3;
					}
				}
				if (num11 > 0)
				{
					NPC.netUpdate = true;
					if (flag && NPC.ai[2] == 1f)
					{
						NPC.TargetClosest();
					}
					if (num11 == 3)
					{
						NPC.velocity.Y = -8f;
						NPC.velocity.X += 3 * NPC.direction;
						NPC.ai[0] = -50f;
						NPC.ai[3] = NPC.position.X;
					}
					else
					{
						NPC.velocity.Y = -6f;
						NPC.velocity.X += 2 * NPC.direction;
						NPC.ai[0] = -120f;
						if (num11 == 1)
						{
							NPC.ai[0] -= 1000f;
						}
						else
						{
							NPC.ai[0] -= 2000f;
						}
					}
				}
				else if (NPC.ai[0] >= -30f)
				{
					NPC.aiAction = 1;
				}
			}
			else if (NPC.target < 255 && ((NPC.direction == 1 && NPC.velocity.X < 3f) || (NPC.direction == -1 && NPC.velocity.X > -3f)))
			{
				if (NPC.collideX && Math.Abs(NPC.velocity.X) == 0.2f)
				{
					NPC.position.X -= 1.4f * (float)NPC.direction;
				}
				if (NPC.collideY && NPC.oldVelocity.Y != 0f && Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
				{
					NPC.position.X -= NPC.velocity.X + (float)NPC.direction;
				}
				if ((NPC.direction == -1 && (double)NPC.velocity.X < 0.01) || (NPC.direction == 1 && (double)NPC.velocity.X > -0.01))
				{
					NPC.velocity.X += 0.2f * (float)NPC.direction;
				}
				else
				{
					NPC.velocity.X *= 0.93f;
				}
			}

			if (aggressive[0] && !aggressive[1]) {
				NPC.ai[0] = -50f;
				aggressive[0] = false;
				aggressive[1] = true;
			}
		}
	}
}