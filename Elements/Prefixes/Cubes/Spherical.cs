using Terraria.ModLoader;
using Eggpack.Elements;
using Terraria;

namespace Eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A negative cube prefix.
	/// </summary>
	public class Spherical : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				damage = 0.75f,
				knockback = 0.85f,
				projectileSpeed = 0.75f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 0.55f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}