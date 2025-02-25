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
    public class BlueMutagen : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 9999;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += Constants.ClassDMGBuff_Regular;
            player.statManaMax2 += Constants.ManaBuff_Regular;
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "x", "Increases magic damage by " + (Constants.ClassDMGBuff_Regular * 100) + "%");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "x", "Increases max mana by " + Constants.ManaBuff_Regular);
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
                .AddIngredient<LesserBlueMutagen>(3)
                .AddTile(134) //Orichalcum/Mithril anvil
                .DisableDecraft()
                .Register();
        }
    }
}