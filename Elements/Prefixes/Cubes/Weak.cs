namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A negative cube prefix.
/// </summary>
public class Weak : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			manaCost = 1.1f,
			cooldown = 1.1f,
			damage = 0.8f,
			knockback = 0.85f
		};
	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 0.35f;
	}
	public override void SetStaticDefaults()
	{
		Cube.CubePrefixes.Add(Type);
	}
}