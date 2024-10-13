namespace Eggpack.Elements.Prefixes.Cubes
{
	/// <summary>
	/// A positive cube prefix that gives -15% cooldown duration.
	/// </summary>
	public class Quick : CubePrefix
	{
		public override CubePrefixModifiers GetModifiedStats()
		{
			return new()
			{
				cooldown = 0.9f
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