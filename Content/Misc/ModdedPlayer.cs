using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.ModLoader;
using Terraria.DataStructures;
using WitcherMutations.Content.UI;
using WitcherMutations.Content.Mutations;

namespace WitcherMutations.Content.Misc
{
    class ModdedPlayer: ModPlayer
    {
        public override void UpdateEquips()
        {
            for(int i = 0; i < 4; i++)
            {
                Item item = WitcherMutationUI.mutagens[i].Item;
                if (!item.IsAir)
                {
                    Main.LocalPlayer.GrantPrefixBenefits(item);
                    Main.LocalPlayer.ApplyEquipFunctional(item, true);
                }
            }

            Main.LocalPlayer.GrantPrefixBenefits(WitcherMutationUI.mutationSlot.Item);
            Main.LocalPlayer.ApplyEquipFunctional(WitcherMutationUI.mutationSlot.Item, true);
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (WitcherMutationUI.mutationSlot.Item.Name.Equals("Retribution"))
            {
                modifiers.FinalDamage*= (1 - (1 / Constants.Retribution_Ratio));
            }
            else if (WitcherMutationUI.mutationSlot.Item.Name.Equals("Unstoppable") 
                && !Main.LocalPlayer.HasBuff(ModContent.BuffType<Unstoppable_Cooldown>()))
            {
                if (Main.LocalPlayer.HasBuff(ModContent.BuffType<Unstoppable_Buff>()))
                {
                    modifiers.Cancel();
                }
            }
        }
        public override void OnHurt(Player.HurtInfo info)
        {
            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<Slaughterhouse_Buff>()))
            {
                Main.LocalPlayer.ClearBuff(ModContent.BuffType<Slaughterhouse_Buff>());
            }
            else if (WitcherMutationUI.mutationSlot.Item.Name.Equals("Retribution"))
            {
                //Deal DMG to npc
                info.DamageSource.TryGetCausingEntity(out var entity);
                if(entity is NPC npc)
                {
                    npc.SimpleStrikeNPC(info.SourceDamage/Constants.Retribution_Ratio + npc.defense/2, 0);
                }
            }
            else if (WitcherMutationUI.mutationSlot.Item.Name.Equals("Unstoppable")
                && !Main.LocalPlayer.HasBuff(ModContent.BuffType<Unstoppable_Cooldown>()) 
                && info.Damage >= Main.LocalPlayer.statLife)
            {
                Main.LocalPlayer.statLife = (int)(Main.LocalPlayer.statLifeMax2 * Constants.Unstoppable_RestorePercentage);
                Main.LocalPlayer.AddBuff(ModContent.BuffType<Unstoppable_Buff>(), 60 * Constants.Unstoppable_Duration, true, false);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(target.life <= 0 && WitcherMutationUI.mutationSlot.Item.Name.Equals("Slaughterhouse"))
            {
                if(!Main.LocalPlayer.HasBuff(ModContent.BuffType<Slaughterhouse_Buff>()))
                {
                    Slaughterhouse.DMGBuff = 0f;
                }
                if (Slaughterhouse.DMGBuff < Constants.Slaughterhouse_MaxBuff)
                {
                    Slaughterhouse.DMGBuff += Constants.Slaughterhouse_KillBuff;
                }
                Main.LocalPlayer.AddBuff(ModContent.BuffType<Slaughterhouse_Buff>(), 900, true, false);
            }
            else if(WitcherMutationUI.mutationSlot.Item.Name.Equals("Sorcerer's Wrath") && hit.DamageType == DamageClass.Magic)
            {
                Random rand = new Random(DateTime.Now.Nanosecond);
                if (rand.NextSingle() <= Constants.SorcerersWrath_Chance)
                {
                    foreach (NPC npc in Main.npc)
                    {
                        if (!npc.friendly && Vector2.Distance(npc.position, target.position) <= (16 * Constants.SorcerersWrath_Range))
                        {
                            npc.StrikeNPC(new NPC.HitInfo
                            {
                                Damage = (int) (damageDone * Constants.SorcerersWrath_DMG),
                                Knockback = 5f,
                                HitDirection = npc.direction
                            });
                        }
                    }
                }
            }
        }
    }
}