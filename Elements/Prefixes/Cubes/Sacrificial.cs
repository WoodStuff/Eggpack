using Terraria.ModLoader;
using Eggpack.Elements;
using Terraria;

namespace Eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A neutral cube prefix.
	/// </summary>
	public class Sacrificial : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				lifeCost = 1.3f,
				damage = 1.2f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.30f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}