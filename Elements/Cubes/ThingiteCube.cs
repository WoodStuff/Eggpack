using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace eggpack.Elements.Cubes
{
	public class ThingiteCube : Cube
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void CustomDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.White;
        }
		public override CubeSettings GetCubeSettings(Player player)
		{
			CubeSettings settings = new()
			{
				cooldown = eggpack.ToFrames(15)
			};

			return settings;
		}
	}
}