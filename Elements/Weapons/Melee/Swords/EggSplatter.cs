using Eggpack.Elements.Items;
using Eggpack.Elements.NPCs;
using Eggpack.Elements.NPCs.RulerOfEggsBoss;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Melee.Swords;

/// <summary>
/// A weapon crafted from Yolk Shards and used to summon the Ruler of Eggs.
/// </summary>
public class EggSplatter : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		// sword properties
		Item.DamageType = DamageClass.Melee;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.UseSound = SoundID.Item1;

		// sword stats
		Item.damage = 10;
		Item.knockBack = 5;
		Item.useTime = 18;
		Item.useAnimation = 18;

		// item properties
		Item.width = 40;
		Item.height = 40;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.rare = ItemRarityID.Green;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<YolkShard>()
			.AddRecipeGroup(ModRecipeGroup.EvilBar, 5)
			.AddTile(TileID.Anvils)
			.Register();
	}

	public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
	{
		if (target.type == ModContent.NPCType<WildEgg>()) modifiers.SetInstantKill();
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (target.type == ModContent.NPCType<WildEgg>() && player.whoAmI == Main.myPlayer)
		{
			SoundEngine.PlaySound(SoundID.Roar, target.position);

			int type = ModContent.NPCType<RulerOfEggs>();

			if (Main.netMode != NetmodeID.MultiplayerClient) NPC.SpawnOnPlayer(player.whoAmI, type);
			else NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
		}
	}
}