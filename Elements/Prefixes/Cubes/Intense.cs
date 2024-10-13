namespace Eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A neutral cube prefix.
	/// </summary>
	public class Intense : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				manaCost = 1.15f,
				damage = 1.1f
			};
		}
		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.25f;
		}
		public override void SetStaticDefaults()
		{
			Cube.CubePrefixes.Add(Type);
		}
	}
}