using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using WitcherMutations.Content.UI;

namespace WitcherMutations.Content.UI
{

    public class WitcherMutationUI : UIState
    {
        public UIPanel panel;
        public static CustomItemSlot_Mutagen[] mutagens = new CustomItemSlot_Mutagen[4];
        public static CustomItemSlot_Mutation mutationSlot;

        public override void OnInitialize()
        { 
            panel = new UIPanel(); 
            panel.Width.Set(300, 0);         
            panel.Height.Set(400, 0);
            panel.HAlign = panel.VAlign = 0.5f;
            Append(panel);

                UIText header = new UIText("Mutations", 0.75f, true);
                header.HAlign = 0.5f;
                header.Top.Set(15, 0);
                panel.Append(header);

                UIPanel exitButton = new UIPanel();
                exitButton.Width.Set(30, 0);
                exitButton.Height.Set(30, 0);
                exitButton.HAlign = 1f;
                exitButton.VAlign = 0f;
                exitButton.OnLeftMouseDown += OnExitButtonClicked;
                panel.Append(exitButton);

                    UIText exitButtonText = new UIText("X");
                    exitButtonText.HAlign = exitButtonText.VAlign = 0.5f;
                    exitButton.Append(exitButtonText);

            //Top left
            mutagens[0] = new CustomItemSlot_Mutagen();
            mutagens[0].HAlign = mutagens[0].VAlign = 0.25f;
            panel.Append(mutagens[0]);

            //Bottom Left
            mutagens[1] = new CustomItemSlot_Mutagen();
            mutagens[1].HAlign = 0.25f;
            mutagens[1].VAlign = 0.75f;
            panel.Append(mutagens[1]);

            //Top Right
            mutagens[2] = new CustomItemSlot_Mutagen();
            mutagens[2].HAlign = 0.75f;
            mutagens[2].VAlign = 0.25f;
            panel.Append(mutagens[2]);

            //Bottom right
            mutagens[3] = new CustomItemSlot_Mutagen();
            mutagens[3].HAlign = mutagens[3].VAlign = 0.75f;
            panel.Append(mutagens[3]);

            //Middle
            mutationSlot = new CustomItemSlot_Mutation();
            mutationSlot.HAlign = mutationSlot.VAlign = 0.5f;
            panel.Append(mutationSlot);



        }

        private void OnExitButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            ModContent.GetInstance<WitcherMutationUISystem>().HideMyUI();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            if (panel.ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

        }
    }
}