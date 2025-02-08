namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A neutral cube prefix.
/// </summary>
public class Forceful : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			knockback = 1.15f
		};
	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 1.10f;
	}
	public override void SetStaticDefaults()
	{
		Cube.CubePrefixes.Add(Type);
	}
}