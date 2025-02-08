namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A neutral cube prefix.
/// </summary>
public class Charged : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			cooldown = 1.2f,
			damage = 1.25f
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