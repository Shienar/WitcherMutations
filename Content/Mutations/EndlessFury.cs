using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Collections.Generic;
using WitcherMutations.Content.UI;
using Microsoft.Xna.Framework;
using WitcherMutations.Content.Mutagens;

namespace WitcherMutations.Content.Mutations
{
    public class EndlessFury : ModItem
    {
        private int CritBuff;
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = -13; //Fiery Red
            Item.maxStack = 9999;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CritBuff = 0;
            foreach (NPC npc in Main.npc.Where(npc => Vector2.Distance(npc.Center, player.Center) < (81.25 * 16)))
            {
                if(npc.CanBeChasedBy())
                {
                    CritBuff += Constants.EndlessFury_CritBuff;
                }
                if(CritBuff > Constants.EndlessFury_MaxBuff)
                {
                    CritBuff = Constants.EndlessFury_MaxBuff;
                    break;
                }
            }
            player.GetCritChance(DamageClass.Melee) += CritBuff;
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "x", "Increases melee critical strike chance by " + (Constants.EndlessFury_CritBuff) +  "% for each nearby enemy, up to a maximum of " + (Constants.EndlessFury_MaxBuff)  + "%");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "x", "Current bonus: " + CritBuff + "%");
            tooltips.Add(line);
        }

        //Prefixes arent allowed for this item
        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<GreaterRedMutagen>(3)
                .AddTile(412) //Ancient Manipulator
                .DisableDecraft()
                .Register();
        }
    }
}