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
    public class Unstoppable : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = -13; //Fiery Red
            Item.maxStack = 9999;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //All of the work is done in slaughterhouse_buff and moddedplayer
            //This file just stores the item 
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "x", "Taking fatal damage will instead restore " + (Constants.Unstoppable_RestorePercentage * 100) + "% health and grant invulnerability for " + Constants.Unstoppable_Duration + " seconds");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "x", "Cooldown: " + Constants.Unstoppable_Cooldown + " seconds");
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
                .AddIngredient<GreaterGreenMutagen>(3)
                .AddTile(412) //Ancient Manipulator
                .DisableDecraft()
                .Register();
        }
    }
}