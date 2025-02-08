namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A positive cube prefix.
/// </summary>
public class Mythic : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			manaCost = 0.5f
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