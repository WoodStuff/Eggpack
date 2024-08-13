using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Eggpack;
using Terraria.GameContent.Creative;

namespace Eggpack.Elements.Items
{
	/// <summary>
	/// A crafting material dropped by the Wild Egg.
	/// </summary>
	public class YolkShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
			Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults()
		{
			Item.maxStack = Item.CommonMaxStack;
			Item.width = 22;
			Item.height = 36;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.White;
		}
	}
}