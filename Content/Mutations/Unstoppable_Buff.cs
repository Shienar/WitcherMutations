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
    public class Unstoppable_Buff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.statLife < (int)(player.statLifeMax2 * Constants.Unstoppable_RestorePercentage))
            {
                player.statLife = (int)(player.statLifeMax2 * Constants.Unstoppable_RestorePercentage);
            }


            int index = player.FindBuffIndex(Type);
            if (index < Player.MaxBuffs && player.buffTime[index] <= 5)
            {
                Main.LocalPlayer.AddBuff(ModContent.BuffType<Unstoppable_Cooldown>(), 60 * Constants.Unstoppable_Cooldown, true, false);

            }
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            rare = -13;
            tip = "Your mutations have given you another chance at life";
            buffName = "Unstoppable";
        }   
    }
}