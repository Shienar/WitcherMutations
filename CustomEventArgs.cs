using WitcherMutations.Content.UI;
using System;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;


//Credit: https://github.com/abluescarab/tModLoader-CustomSlot/blob/cb84c70580fc25736a16a2465a878f22df05e098/CustomEventArgs.cs
namespace WitcherMutations
{
    public delegate void ItemChangedEventHandler_Mutagen(CustomItemSlot_Mutagen slot, ItemChangedEventArgs e);
    public delegate void ItemVisiblityChangedEventHandler_Mutagen(CustomItemSlot_Mutagen slot, ItemVisibilityChangedEventArgs e);

    public delegate void ItemChangedEventHandler_Mutation(CustomItemSlot_Mutation slot, ItemChangedEventArgs e);
    public delegate void ItemVisiblityChangedEventHandler_Mutation(CustomItemSlot_Mutation slot, ItemVisibilityChangedEventArgs e);

    public delegate void PanelDragEventHandler(UIPanel sender, PanelDragEventArgs e);

    public class PanelDragEventArgs : EventArgs
    {
        public readonly StyleDimension X;
        public readonly StyleDimension Y;

        public PanelDragEventArgs(StyleDimension x, StyleDimension y)
        {
            X = x;
            Y = y;
        }
    }

    public class ItemChangedEventArgs : EventArgs
    {
        public readonly Item OldItem;
        public readonly Item NewItem;

        public ItemChangedEventArgs(Item oldItem, Item newItem)
        {
            OldItem = oldItem;
            NewItem = newItem;
        }
    }

    public class ItemVisibilityChangedEventArgs : EventArgs
    {
        public readonly bool Visibility;

        public ItemVisibilityChangedEventArgs(bool visibility)
        {
            Visibility = visibility;
        }
    }
}