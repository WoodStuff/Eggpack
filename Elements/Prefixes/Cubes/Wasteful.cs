using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A negative cube prefix.
	/// </summary>
	public class Wasteful : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				manaCost = 1.2f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 0.9f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}