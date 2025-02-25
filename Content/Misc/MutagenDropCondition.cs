using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;

namespace WitcherMutations.Content.Misc
{
    public class MutagenDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        /*
         * 1 = blue = magic = mushroom biome
         * 2 = yellow = ranged = desert
         * 3 = white = summon = ice biome
         * 4 = red = melee = crimson/corruption
         * 5 = orange = generic damage = hell
         * 6 = pink = speed = hallow
         * 7 = green = health = jungle
         * 8 = gray = damage mitigation = cavern
         */
        private int type;

        //1 = lesser
        //2 = regular
        //3 = greater
        private int strength;

        public MutagenDropCondition(int mutagenType, int strength)
        {            
            this.type = mutagenType;
            this.strength = strength;
            Description ??= Language.GetOrRegister("Mods.WitcherMutations.Content.Misc.MutagenDropCondition");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            /*
             * Biome List
             * player.ZoneBeach 
             * player.ZoneCorrupt 
             * player.ZoneCrimson 
             * player.ZoneDesert 
             * player.ZoneDungeon
             * player.ZoneGemCave
             * player.ZoneGlowshroom 
             * player.ZoneGranite 
             * player.ZoneGraveyard 
             * player.ZoneHallow 
             * player.ZoneHive 
             * player.ZoneJungle
             * player.ZoneLihzhardTemple 
             * player.ZoneMarble 
             * player.ZoneMeteor 
             * player.ZoneSnow 
             * player.ZoneUnderworldHeight;
             * player.ZoneRockLayerHeight
             * player.ZoneForest
             */
            bool biomeCondition = false;
            bool progressionCondition = false;
            switch (this.type)
            {
                case 1:
                    if (info.player.ZoneGlowshroom) biomeCondition = true;
                    break;
                case 2:
                    if (info.player.ZoneDesert) biomeCondition = true;
                    break;
                case 3:
                    if (info.player.ZoneSnow) biomeCondition = true;
                    break;
                case 4:
                    if (info.player.ZoneCrimson || info.player.ZoneCorrupt) biomeCondition = true;
                    break;
                case 5:
                    if (info.player.ZoneUnderworldHeight) biomeCondition = true;
                    break;
                case 6:
                    if (info.player.ZoneHallow) biomeCondition = true;
                    break;
                case 7:
                    if (info.player.ZoneJungle) biomeCondition = true;
                    break;
                case 8:
                    if (info.player.ZoneRockLayerHeight) biomeCondition = true;
                    break;
                default:
                    return false;
                    break;
            }

            if (this.strength == 1)
            {
                progressionCondition = true;
            }
            else if (this.strength == 2 && Main.hardMode)
            {
                progressionCondition = true;
            }
            else if (this.strength == 3 && NPC.downedGolemBoss)
            {
                progressionCondition = true;
            }

            //Debugging
            //Main.NewText("Type:" + this.type + " | Strength: " + this.strength + " | biomeCondition: " + biomeCondition + " | progressionCondition: " + progressionCondition);

            return biomeCondition && progressionCondition;
            
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
}