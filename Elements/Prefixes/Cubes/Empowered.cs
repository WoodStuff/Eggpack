namespace Eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A positive cube prefix that gives +20% buff duration.
	/// </summary>
	public class Empowered : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				buffDuration = 1.2f
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