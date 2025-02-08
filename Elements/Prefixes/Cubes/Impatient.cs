namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A neutral cube prefix.
/// </summary>
public class Impatient : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			cooldown = 1.2f,
			damage = 0.8f
		};
	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 0.95f;
	}
	public override void SetStaticDefaults()
	{
		Cube.CubePrefixes.Add(Type);
	}
}