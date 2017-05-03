using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tama.Actions;
using Tama.Creatures;
using Tama.Log;
using Tama.Stats;

namespace Tama
{
    static class CurrentCreature {

        static public Creature creature = new Creature("MonsterCat", 0, 0, 100, 100, 100);
    }

    class Game
    {
        RenderWindow BINDED_WINDOW = Program.GameWindow;
        ActionBar actionBar;
        Showcase showcase;
        StatusBar statusBar;
        public Logger logger;

        List<Button> systemButtons;
        List<Button> actionButtons;

        public Game() {

            systemButtons = new List<Button>();
            systemButtons.Add(new Button(Content.GameButtons.texture, 20, 20, 50, 50, 0, 0)); //Back to menu
            systemButtons.Add(new Button(Content.GameButtons.texture, 90, 20, 50, 50, 50, 0)); //Creatures collection
            systemButtons.Add(new Button(Content.GameButtons.texture, 160, 20, 50, 50, 100, 0)); //Save
            actionButtons = new List<Button>();

            actionBar = new ActionBar();
            showcase = new Showcase();
            statusBar = new StatusBar();
            logger = new Logger();
        }

        public void Update() {

            CurrentCreature.creature.Update();

            statusBar.Update();
            logger.Update();

        }

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

            actionBar.Draw();
            showcase.Draw();
            statusBar.Draw();
            logger.Draw();
        }

        //********************
        //** SYSTEM BUTTONS **
        //********************

        public delegate void buttonEvent();

        public void Click()
        {

            actionBar.Click();

            List<buttonEvent> events = new List<buttonEvent>() { new buttonEvent(BackToMenuButtonEvent), new buttonEvent(CreaturesCollectionButtonEvent), new buttonEvent(Save)};
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

        private void Save() { }
    }
}
