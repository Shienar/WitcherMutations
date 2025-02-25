using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using WitcherMutations.Content.Mutagens;

namespace WitcherMutations.Content.Misc
{
    public class DropChances : GlobalNPC
    {
        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            //Conditions:
            /*
             * 1 = blue = magic = mushroom biome
             * 2 = yellow = ranged = desert
             * 3 = white = summon = ice biome
             * 4 = red = melee = crimson/corruption
             * 5 = orange = generic damage = hell
             * 6 = pink = speed = hallow
             * 7 = green = health = jungle
             * 8 = gray = damage mitigation = cavern
             * 
             * 1 == lesser
             * 2 == regular
             * 3 == greater
             */
            //public static IItemDropRule ByCondition(IItemDropRuleCondition condition, int itemId, int chanceDenominator = 1, int minimumDropped = 1, int maximumDropped = 1, int chanceNumerator = 1)
            
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(1, 1), ModContent.ItemType<LesserBlueMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(1, 2), ModContent.ItemType<BlueMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(1, 3), ModContent.ItemType<GreaterBlueMutagen>(), 100, 1, 1, 1));

            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(2, 1), ModContent.ItemType<LesserYellowMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(2, 2), ModContent.ItemType<YellowMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(2, 3), ModContent.ItemType<GreaterYellowMutagen>(), 100, 1, 1, 1));

            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(3, 1), ModContent.ItemType<LesserWhiteMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(3, 2), ModContent.ItemType<WhiteMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(3, 3), ModContent.ItemType<GreaterWhiteMutagen>(), 100, 1, 1, 1));

            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(4, 1), ModContent.ItemType<LesserRedMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(4, 2), ModContent.ItemType<RedMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(4, 3), ModContent.ItemType<GreaterRedMutagen>(), 100, 1, 1, 1));

            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(5, 1), ModContent.ItemType<LesserOrangeMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(5, 2), ModContent.ItemType<OrangeMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(5, 3), ModContent.ItemType<GreaterOrangeMutagen>(), 100, 1, 1, 1));

            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(6, 1), ModContent.ItemType<LesserPinkMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(6, 2), ModContent.ItemType<PinkMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(6, 3), ModContent.ItemType<GreaterPinkMutagen>(), 100, 1, 1, 1));

            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(7, 1), ModContent.ItemType<LesserGreenMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(7, 2), ModContent.ItemType<GreenMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(7, 3), ModContent.ItemType<GreaterGreenMutagen>(), 100, 1, 1, 1));

            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(8, 1), ModContent.ItemType<LesserGrayMutagen>(), 100, 1, 1, 5));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(8, 2), ModContent.ItemType<GrayMutagen>(), 100, 1, 1, 3));
            globalLoot.Add(ItemDropRule.ByCondition(new MutagenDropCondition(8, 3), ModContent.ItemType<GreaterGrayMutagen>(), 100, 1, 1, 1));
        }
    }
}