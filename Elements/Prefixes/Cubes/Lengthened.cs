using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A neutral cube prefix.
	/// </summary>
	public class Lengthened : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				buffDuration = 1.25f,
				backfireBuffDuration = 1.25f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.1f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}