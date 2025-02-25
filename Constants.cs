namespace WitcherMutations
{
    //Allows for balancing buffs without going file-by-file.
    //Tooltip information is also based off of these constants.
   public static class Constants
    {
        //Mutagens
        public const float ClassDMGBuff_Lesser = 0.03f;
        public const float ClassDMGBuff_Regular= 0.06f;
        public const float ClassDMGBuff_Greater = 0.09f;

        public const float DMGBuff_Lesser = 0.02f;
        public const float DMGBuff_Regular = 0.04f;
        public const float DMGBuff_Greater = 0.06f;

        public const float SpeedBuff_Lesser = 0.1f;
        public const float SpeedBuff_Regular = 0.25f;
        public const float SpeedBuff_Greater = 0.4f;

        public const int HPBuff_Lesser = 10;
        public const int HPBuff_Regular = 20;
        public const int HPBuff_Greater = 40;

        public const int ManaBuff_Lesser = 10;
        public const int ManaBuff_Regular = 20;
        public const int ManaBuff_Greater = 30;

        public const float EnduranceBuff_Lesser = 0.02f;
        public const float EnduranceBuff_Regular = 0.04f;
        public const float EnduranceBuff_Greater = 0.08f;

        //Mutations
        public const float Slaughterhouse_KillBuff = 0.05f;
        public const float Slaughterhouse_MaxBuff = 0.25f;

        public const float HarmonicSummons_DMGBuff = 0.1f;
        public const float HarmonicSummons_MaxBuff = 0.5f;

        public const int EndlessFury_CritBuff = 3;
        public const int EndlessFury_MaxBuff = 30;

        public const int Retribution_Ratio = 4; //Mitigation = 1/Retribution_Ratio. A certain function doesn't like floats.

        public const float LightningReflexes = 0.15f;

        public const int Unstoppable_Cooldown = 180; //seconds
        public const int Unstoppable_Duration = 4; //seconds
        public const float Unstoppable_RestorePercentage = 0.2f;

        public const float SorcerersWrath_Chance = 0.25f; //IF a random number between 0 and 1 is less than this, then stuff happens
        public const float SorcerersWrath_DMG = 2f; // Multiplied by original damage and dealt in area
        public const float SorcerersWrath_Range = 5f; //Tiles
    }
}