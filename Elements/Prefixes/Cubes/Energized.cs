using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A neutral cube prefix.
	/// </summary>
	public class Energized : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				manaCost = 1.25f,
				cooldown = 0.8f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.35f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}