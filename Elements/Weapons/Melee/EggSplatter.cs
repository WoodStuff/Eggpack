using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using eggpack.Elements.NPCs;
using eggpack.Elements.NPCs.RulerOfAllEggs;
using Terraria.Audio;

namespace eggpack.Elements.Weapons.Melee
{
	public class EggSplatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Please do not hit a wild egg with this");
		}
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(0, 7, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "YolkShard")
				.AddRecipeGroup(ModRecipeGroup.EvilBar, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (target.type == ModContent.NPCType<WildEgg>())
            {
				target.life = 0;
				if (player.whoAmI == Main.myPlayer)
				{
					// If the player using the item is the client
					// (explicitely excluded serverside here)
					SoundEngine.PlaySound(SoundID.Roar, player.position);

					int type = ModContent.NPCType<RulerOfAllEggs>();

					if (Main.netMode != NetmodeID.MultiplayerClient)
					{
						// If the player is not in multiplayer, spawn directly
						NPC.SpawnOnPlayer(player.whoAmI, type);
					}
					else
					{
						// If the player is in multiplayer, request a spawn
						// This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
						NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
					}
				}
			}
		}
	}
}