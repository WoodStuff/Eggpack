using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Eggpack.Elements.Weapons.Summoner.SMetalOrb
{
	public class MetalStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;
			ItemID.Sets.LockOnIgnoresCollision[Type] = true;

			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 5;
			Item.knockBack = 3f;
			Item.mana = 10; // mana cost
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item44;

			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;
			Item.buffType = ModContent.BuffType<MetalOrbBuff>();
			Item.shoot = ModContent.ProjectileType<MetalOrb>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
			position = Main.MouseWorld;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer); // summon the minion
			projectile.originalDamage = Item.damage; // set minion damage

			return false; // so game knows that it shouldnt spawn the projectile itself (it was already spawned by the code above)
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 12)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}