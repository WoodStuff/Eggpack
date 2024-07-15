using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A positive cube prefix.
	/// </summary>
	public class Legendary : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				damage = 1.08f,
				cooldown = 0.9f,
				knockback = 1.15f,
				manaCost = 0.8f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.75f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}