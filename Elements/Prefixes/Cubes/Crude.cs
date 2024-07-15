using Terraria.ModLoader;
using Eggpack.Elements;
using Terraria;

namespace Eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A negative cube prefix.
	/// </summary>
	public class Crude : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				buffDuration = 0.8f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 0.8f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}