namespace Eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A positive cube prefix.
	/// </summary>
	public class Powerful : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				damage = 1.08f,
				knockback = 1.15f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.4f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}