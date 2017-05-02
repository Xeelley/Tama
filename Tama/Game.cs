using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama
{
    class Game
    {
        RenderWindow BINDED_WINDOW = Program.GameWindow;

        List<Button> systemButtons;
        List<Button> actionButtons;

        public Game() {
            systemButtons = new List<Button>();
            systemButtons.Add(new Button(Content.GameButtons.texture, 20, 20, 50, 50, 0, 0)); //Back to menu
            systemButtons.Add(new Button(Content.GameButtons.texture, 90, 20, 50, 50, 50, 0)); //Creatures collection
            actionButtons = new List<Button>();
        }

        public void Update() { }

        public void Draw()
        {
            foreach (Button button in systemButtons)
            {
                BINDED_WINDOW.Draw(button);
            }
            foreach (Button button in actionButtons)
            {
                BINDED_WINDOW.Draw(button);
            }
        }

        //********************
        //** SYSTEM BUTTONS **
        //********************

        public delegate void buttonEvent();

        public void Click()
        {

            List<buttonEvent> events = new List<buttonEvent>() { new buttonEvent(BackToMenuButtonEvent), new buttonEvent(CreaturesCollectionButtonEvent)};
            for (int i = 0; i < systemButtons.Count; i++)
            {
                if (systemButtons[i].isContainMouse(BINDED_WINDOW))
                {
                    events[i]();
                }
            }
        }

        private void BackToMenuButtonEvent() {
            Program.isMenuWindowVisible = true;
            Program.MenuWindow.SetVisible(true);
            Program.isGameWindowVisible = false;
            Program.GameWindow.SetVisible(false);
        }

        private void CreaturesCollectionButtonEvent() { }
    }
}
