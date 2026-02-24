using Eggpack.Elements.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Melee.Swords;

/// <summary>
/// A generic sword made from Thingite.
/// </summary>
public class ThingiteSword : ModItem
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
		Item.damage = 17;
		Item.knockBack = 6;
		Item.useTime = 21;
		Item.useAnimation = 21;
		Item.scale = 1.2f;

		// item properties
		Item.width = 32;
		Item.height = 32;
		Item.value = Item.sellPrice(0, 0, 30, 0);
		Item.rare = ItemRarityID.Blue;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
			.AddIngredient<ThingiteBar>(10)
			.AddTile(TileID.Anvils)
			.Register();
	}

	public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (hit.Crit) target.AddBuff(BuffID.Weak, 3 * 60);
	}
}