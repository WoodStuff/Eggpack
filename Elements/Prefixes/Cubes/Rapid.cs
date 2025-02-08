namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A neutral cube prefix.
/// </summary>
public class Rapid : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			cooldown = 0.92f,
			projectileSpeed = 1.15f,
			damage = 0.9f
		};
	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 1.15f;
	}
	public override void SetStaticDefaults()
	{
		Cube.CubePrefixes.Add(Type);
	}
}