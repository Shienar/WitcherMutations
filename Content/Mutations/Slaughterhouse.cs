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
    public class Slaughterhouse : ModItem
    {
        public static float DMGBuff = 0f;

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = -13; //Fiery Red
            Item.maxStack = 9999;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //All of the work is done in slaughterhouse_buff and moddedplayer
            //This file just stores the item and the varying DMGBuff value
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "x", "Killing an enemy increases damage done by " + (Constants.Slaughterhouse_KillBuff*100) +  "% for 15 seconds, up to a maximum of " + (Constants.Slaughterhouse_MaxBuff * 100)  + "%");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "x", "Current bonus: " + DMGBuff*100 + "%");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "x", "Taking damage from an enemy resets this bonus");
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
                .AddIngredient<GreaterOrangeMutagen>(3)
                .AddTile(412) //Ancient Manipulator
                .DisableDecraft()
                .Register();
        }
    }
}