﻿namespace Eggpack.Elements.Prefixes.Cubes;

/// <summary>
/// A positive cube prefix that gives -10% cooldown duration.
/// </summary>
public class Fast : CubePrefix
{
	public override CubePrefixModifiers GetModifiedStats()
	{
		return new()
		{
			cooldown = 0.95f
		};
	}
	public override void ModifyValue(ref float valueMult)
	{
		valueMult *= 1.2f;
	}
	public override void SetStaticDefaults()
	{
		Cube.CubePrefixes.Add(Type);
	}
}