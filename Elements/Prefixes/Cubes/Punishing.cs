using Terraria.ModLoader;
using eggpack.Elements;
using Terraria;

namespace eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A negative cube prefix.
	/// </summary>
	public class Punishing : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				backfireBuffDuration = 1.25f,
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