using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.ModLoader;
using WitcherMutations.Content.UI;
using WitcherMutations.Content.Mutations;
using Terraria.DataStructures;

namespace WitcherMutations.Content.Misc
{
    class GlobalNPCManager: GlobalNPC
    {
        public override void PostAI(NPC npc)
        {
            if (WitcherMutationUI.mutationSlot.Item.Name.Equals("Lightning Reflexes") && npc.CanBeChasedBy())
            {
                Vector2 slowPos = npc.position - npc.oldPosition;;
                npc.position.X -= ((slowPos.X)*(1-Constants.LightningReflexes));
                npc.position.Y -= ((slowPos.Y)*(1-Constants.LightningReflexes));

            }

        }

    }
}
