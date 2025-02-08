namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A negative cube prefix.
/// </summary>
public class Exhaustive : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			manaCost = 1.5f
		};
	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 0.7f;
	}
	public override void SetStaticDefaults()
	{
		Cube.CubePrefixes.Add(Type);
	}
}