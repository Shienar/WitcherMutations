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
    public class HarmonicSummons : ModItem
    {
        private static float DMGBuff;
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.rare = -13; //Fiery Red
            Item.maxStack = 9999;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            DMGBuff = 0f;
            IEnumerable<Projectile> playerProjectiles =  Main.projectile.Take(Main.maxProjectiles).Where(p => p.active && p.owner == player.whoAmI);
            int[] summonTypes = new int[10];
            int index = 0;
            foreach(Projectile proj in playerProjectiles)
            {
                if(proj.minion && !summonTypes.Contains(proj.type) && DMGBuff < Constants.HarmonicSummons_MaxBuff)
                {
                    summonTypes[index] = proj.type;
                    index++;
                    DMGBuff += Constants.HarmonicSummons_DMGBuff;
                }
            }
            player.GetDamage(DamageClass.Summon) += DMGBuff;
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "x", "Increases summon damage done by " + (Constants.HarmonicSummons_DMGBuff*100) +  "%, up to a maximum of " + (Constants.HarmonicSummons_MaxBuff * 100)  + "%");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "x", "Current bonus: " + DMGBuff*100 + "%");
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
                .AddIngredient<GreaterWhiteMutagen>(3)
                .AddTile(412) //Ancient Manipulator
                .DisableDecraft()
                .Register();
        }
    }
}