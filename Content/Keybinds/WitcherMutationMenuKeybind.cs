using System;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using WitcherMutations.Content.UI;

namespace WitcherMutations.Content.Keybinds
{
    public class WitcherMutationMenuKeybind : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if(WitcherMutationMenuKeybindSystem.openMenuKeybind.JustPressed)
            {
                 if(ModContent.GetInstance<WitcherMutationUISystem>().isVisible())
                 {
                    ModContent.GetInstance<WitcherMutationUISystem>().HideMyUI();
                }
                 else
                 {
                    ModContent.GetInstance<WitcherMutationUISystem>().ShowMyUI();
                }
            }
        }
       
    }
}