using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A negative cube prefix.
	/// </summary>
	public class Inferior : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				damage = 0.85f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 0.75f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}