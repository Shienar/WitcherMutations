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
    public class Slaughterhouse_Buff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += Slaughterhouse.DMGBuff;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            rare = -13;
            tip = "Increases damage by " + Slaughterhouse.DMGBuff * 100 + "%";
            buffName = "Slaughterhouse";
        }   
    }
}