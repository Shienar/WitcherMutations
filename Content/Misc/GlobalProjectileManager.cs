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
using WitcherMutations.Content.UI;
using WitcherMutations.Content.Mutations;
using Terraria.DataStructures;

namespace WitcherMutations.Content.Misc
{
    class GlobalProjectileManager: GlobalProjectile
    {

        //Credit: https://forums.terraria.org/index.php?threads/tutorial-tmodloader-projectile-help.68337/
        public override void AI(Projectile projectile)
        {
            if (WitcherMutationUI.mutationSlot.Item.Name.Equals("Perfect Shot") && !projectile.hostile && projectile.friendly && projectile.damage > 0)
            {
                float num132 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
                float num133 = projectile.localAI[0];
                if (num133 == 0f)
                {
                    projectile.localAI[0] = num132;
                    num133 = num132;
                }
                float num134 = projectile.position.X;
                float num135 = projectile.position.Y;
                float num136 = 300f;
                bool flag3 = false;
                int num137 = 0;
                if (projectile.ai[1] == 0f)
                {
                    for (int num138 = 0; num138 < 200; num138++)
                    {
                        if (Main.npc[num138].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num138 + 1)))
                        {
                            float num139 = Main.npc[num138].position.X + (float)(Main.npc[num138].width / 2);
                            float num140 = Main.npc[num138].position.Y + (float)(Main.npc[num138].height / 2);
                            float num141 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num139) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num140);
                            if (num141 < num136 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
                            {
                                num136 = num141;
                                num134 = num139;
                                num135 = num140;
                                flag3 = true;
                                num137 = num138;
                            }
                        }
                    }
                    if (flag3)
                    {
                        projectile.ai[1] = (float)(num137 + 1);
                    }
                    flag3 = false;
                }
                if (projectile.ai[1] > 0f)
                {
                    int num142 = (int)(projectile.ai[1] - 1f);
                    if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
                    {
                        float num143 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                        float num144 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                        if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num143) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num144) < 1000f)
                        {
                            flag3 = true;
                            num134 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
                            num135 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
                        }
                    }
                    else
                    {
                        projectile.ai[1] = 0f;
                    }
                }
                if (!projectile.friendly)
                {
                    flag3 = false;
                }
                if (flag3)
                {
                    float num145 = num133;
                    Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num146 = num134 - vector10.X;
                    float num147 = num135 - vector10.Y;
                    float num148 = (float)Math.Sqrt((double)(num146 * num146 + num147 * num147));
                    num148 = num145 / num148;
                    num146 *= num148;
                    num147 *= num148;
                    int num149 = 8;
                    projectile.velocity.X = (projectile.velocity.X * (float)(num149 - 1) + num146) / (float)num149;
                    projectile.velocity.Y = (projectile.velocity.Y * (float)(num149 - 1) + num147) / (float)num149;
                }
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (WitcherMutationUI.mutationSlot.Item.Name.Equals("Lightning Reflexes") && projectile.hostile)
            {
                Vector2 slowPos = projectile.position - projectile.oldPosition;
                projectile.position.X -= ((slowPos.X) * (1 - Constants.LightningReflexes));
                projectile.position.Y -= ((slowPos.Y) * (1 - Constants.LightningReflexes));

            }
        }
    }
}
