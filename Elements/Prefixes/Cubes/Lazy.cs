using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A negative cube prefix.
	/// </summary>
	public class Lazy : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				healing = 0.8f,
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