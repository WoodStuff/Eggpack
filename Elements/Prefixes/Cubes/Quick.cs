using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A positive cube prefix that gives -10% cooldown duration.
	/// </summary>
	public class Quick : CubePrefix
	{
		public override CubePrefixModifiers ModifyStats()
		{
			return new()
			{
				cooldown = 0.85f
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