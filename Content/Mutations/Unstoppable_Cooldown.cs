using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using WitcherMutations.Content.Mutations;

namespace WitcherMutations.Content.Mutations
{
    public class Unstoppable_Cooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            rare = -13;
            tip = "Your mutations have given you another chance at life";
            buffName = "Unstoppable Cooldown";
        }

        public override bool RightClick(int buffIndex)
        {
            return false;
        }
    }
}