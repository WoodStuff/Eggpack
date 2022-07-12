using eggpack.Elements;
using eggpack.Elements.Cubes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace eggpack.Players
{
	/// <summary>
	/// The slot that holds Cubes.
	/// </summary>
	public class CubeSlot : ModAccessorySlot
	{
		public override bool CanAcceptItem(Item item, AccessorySlotType context)
		{
			return item.ModItem is Cube;
		}

		public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
		{
			return item.ModItem is Cube;
		}

		public override string FunctionalTexture => "eggpack/Elements/Cube";

		public override void OnMouseHover(AccessorySlotType context)
		{
			switch (context)
			{
				case AccessorySlotType.FunctionalSlot:
					Main.hoverItemName = "Cube";
					break;
				case AccessorySlotType.VanitySlot:
					Main.hoverItemName = "Cuboid";
					break;
				case AccessorySlotType.DyeSlot:
					Main.hoverItemName = "Parallelepiped";
					break;
			}
		}
	}
}