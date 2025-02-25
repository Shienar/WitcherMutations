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
    public class OrangeMutagen : ModItem
    {
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 9999;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += Constants.DMGBuff_Regular;
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "x", "Increases all damage by " + (Constants.DMGBuff_Regular * 100) + "%");
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
                .AddIngredient<LesserOrangeMutagen>(3)
                .AddTile(134) //Orichalcum/Mithril anvil
                .DisableDecraft()
                .Register();
        }
    }
}