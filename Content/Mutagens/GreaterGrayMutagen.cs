using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Collections.Generic;
using WitcherMutations.Content.UI;
using Microsoft.Xna.Framework;

namespace WitcherMutations.Content.Mutagens
{
    public class GreaterGrayMutagen : ModItem
    {

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Gray;
            Item.maxStack = 9999;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += Constants.EnduranceBuff_Greater;
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "x", "Reduces damage taken by " + (Constants.EnduranceBuff_Greater*100) + "%");
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
                .AddIngredient<GrayMutagen>(3)
                .AddTile(412) //Ancient Manipulator
                .DisableDecraft()
                .Register();
        }
    }
}