using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using eggpack;
using Terraria.GameContent.Creative;

namespace eggpack.Elements.Items
{
	public class YolkShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.width = 22;
			Item.height = 36;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.White;
		}
	}
}