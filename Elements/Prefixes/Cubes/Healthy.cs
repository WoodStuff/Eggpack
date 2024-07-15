using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A positive cube prefix.
	/// </summary>
	public class Healthy : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				healing = 1.5f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.3f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}