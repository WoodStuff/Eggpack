using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using eggpack.Elements.NPCs;
using eggpack.Elements.NPCs.RulerOfEggsBoss;
using Terraria.Audio;
using eggpack.Elements.Items;

namespace eggpack.Elements.Weapons.Melee
{
	/// <summary>
	/// A weapon crafted from Yolk Shards and used to summon the Ruler of Eggs.
	/// </summary>
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
				.AddIngredient<YolkShard>()
				.AddRecipeGroup(ModRecipeGroup.EvilBar, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if (target.type == ModContent.NPCType<WildEgg>()) damage = 1000;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (target.type == ModContent.NPCType<WildEgg>())
            {
				if (player.whoAmI == Main.myPlayer)
				{
					SoundEngine.PlaySound(SoundID.Roar, target.position);

					int type = ModContent.NPCType<RulerOfEggs>();

					if (Main.netMode != NetmodeID.MultiplayerClient)
					{
						NPC.SpawnOnPlayer(player.whoAmI, type);
					}
					else
					{
						NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
					}
				}
			}
		}
	}
}