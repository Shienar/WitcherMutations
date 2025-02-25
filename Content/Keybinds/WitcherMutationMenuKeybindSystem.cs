using Terraria.ModLoader;
using Terraria.GameInput;
using Terraria.ID;

namespace WitcherMutations.Content.Keybinds
{
    public class WitcherMutationMenuKeybindSystem : ModSystem
    {
        public static ModKeybind openMenuKeybind { get; private set; }

        public override void Load()
        {
            // Registers a new keybind
            // We localize keybinds by adding a Mods.{ModName}.Keybind.{KeybindName} entry to our localization files. The actual text displayed to English users is in en-US.hjson
            openMenuKeybind = KeybindLoader.RegisterKeybind(Mod, "Open Mutagen Menu", "U");
        }

        // Please see ExampleMod.cs' Unload() method for a detailed explanation of the unloading process.
        public override void Unload()
        {
            // Not required if your AssemblyLoadContext is unloading properly, but nulling out static fields can help you figure out what's keeping it loaded.
            openMenuKeybind = null;
        }
    }
}