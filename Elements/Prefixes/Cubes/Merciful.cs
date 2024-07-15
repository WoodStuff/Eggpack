using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A positive cube prefix.
	/// </summary>
	public class Merciful : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				backfireBuffDuration = 0.8f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.2f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}