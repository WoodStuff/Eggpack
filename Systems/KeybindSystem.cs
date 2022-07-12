using Terraria.ModLoader;

namespace eggpack.Systems
{
	public class KeybindSystem : ModSystem
	{
		public static ModKeybind CubeAbility { get; private set; }

		public override void Load()
		{
			CubeAbility = KeybindLoader.RegisterKeybind(Mod, "Cube Ability", "Z");
		}

		public override void Unload()
		{
			CubeAbility = null;
		}
	}
}