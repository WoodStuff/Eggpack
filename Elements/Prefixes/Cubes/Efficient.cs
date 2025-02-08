namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A positive cube prefix.
/// </summary>
public class Efficient : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			cooldown = 0.9f,
			damage = 1.1f
		};
	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 1.5f;
	}
	public override void SetStaticDefaults()
	{
		Cube.CubePrefixes.Add(Type);
	}
}