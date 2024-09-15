using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Eggpack.Elements.Prefixes.Cubes
{
	public abstract class CubePrefix : ModPrefix
	{
		/// <summary>
		/// Return a CubePrefixModifiers here to modify cube when it has this prefix.
		/// </summary>
		/// <returns>What should be modified in the cube.</returns>
		public abstract CubePrefixModifiers GetModifiedStats();

		/*public override bool CanRoll(Item item)
		{
			return 
		}*/
	}

	/// <summary>
	/// Return this in GetModifiedStats() to modify the stats of a cube.
	/// </summary>
	public class CubePrefixModifiers
	{
		public float cooldown = 1;
		public float manaCost = 1;
		public float damage = 1;
		public float knockback = 1;
		public float buffDuration = 1;
		public float debuffDuration = 1;
		public float lifeCost = 1;
		public float healing = 1;
		public float projectileSpeed = 1;
	}
}