using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tama.Actions;
using Tama.Creatures;
using Tama.Log;
using Tama.Options;
using Tama.Stats;

namespace Tama
{
    static class CurrentCreature {

        static public Creature Begemoth = new Creature("Begemoth", Content.ShowcaseCreatureTextures.Begemoth, 120, 60, 70);
        static public Creature Elephant = new Creature("Elephant", Content.ShowcaseCreatureTextures.Elephant, 110, 60, 70);
        static public Creature Elk =      new Creature("Elk",      Content.ShowcaseCreatureTextures.Elk,      80, 100, 80);
        static public Creature Owl =      new Creature("Owl",      Content.ShowcaseCreatureTextures.Owl,      110, 120, 110);
        static public Creature Pig =      new Creature("Pig",      Content.ShowcaseCreatureTextures.Pig,      140, 30, 100);
        static public Creature Pinguin =  new Creature("Pinguin",  Content.ShowcaseCreatureTextures.Pinguin,  100, 110, 90);
        static public Creature Sheep =    new Creature("Sheep",    Content.ShowcaseCreatureTextures.Sheep,    80, 60, 120);
        static public Creature Zebra =    new Creature("Zebra",    Content.ShowcaseCreatureTextures.Zebra,    100, 100, 100);

        static public Creature creature = Begemoth;
        static public short index = 0;
    }

    class Game : WindowElement
    {
        RenderWindow BINDED_WINDOW = Program.GameWindow;
        ActionBar actionBar;
        Showcase showcase;
        StatusBar statusBar;
        public Logger logger;
        Collection collection;
        public int TotalScore;
        Text TotalScoreText;

        List<Button> systemButtons;
        List<Button> actionButtons;

        public bool isCollectionOpen = false;
        public bool isGameOver = false;
        Clock gameCloseCooldown;

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
            collection = new Collection();

            TotalScore = 0;
            TotalScoreText = new Text("Score: " + TotalScore.ToString(), Content.MontserratFont, 30);
            TotalScoreText.Color = Color.Black;
            TotalScoreText.Position = new SFML.System.Vector2f(20, 530);
        }

        public void Update() {

            TotalScoreText.DisplayedString = "Score: " + TotalScore.ToString();

            if (!CurrentCreature.creature.isAlive) {
                switch(CurrentCreature.index) {
                    case 0: CurrentCreature.Begemoth.isAlive = false; break;
                    case 1: CurrentCreature.Elephant.isAlive = false; break;
                    case 2: CurrentCreature.Elk.isAlive = false; break;
                    case 3: CurrentCreature.Owl.isAlive = false; break;
                    case 4: CurrentCreature.Pig.isAlive = false; break;
                    case 5: CurrentCreature.Pinguin.isAlive = false; break;
                    case 6: CurrentCreature.Sheep.isAlive = false; break;
                    case 7: CurrentCreature.Zebra.isAlive = false; break;
                }
            }

            CurrentCreature.creature.Update();

            statusBar.Update();
            logger.Update();
            collection.Update();

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
            BINDED_WINDOW.Draw(TotalScoreText);

            actionBar.Draw();
            showcase.Draw();
            statusBar.Draw();
            logger.Draw();
            if (isCollectionOpen) collection.Draw();

            if (!CurrentCreature.Begemoth.isAlive && !CurrentCreature.Elephant.isAlive && !CurrentCreature.Elk.isAlive &&
               !CurrentCreature.Owl.isAlive && !CurrentCreature.Pig.isAlive && !CurrentCreature.Pinguin.isAlive &&
               !CurrentCreature.Sheep.isAlive && !CurrentCreature.Zebra.isAlive)
            {
                GameOver();
            }
        }

        //********************
        //** SYSTEM BUTTONS **
        //********************

        public delegate void buttonEvent();

        public void Click()
        {
            if (!isGameOver)
            {

                actionBar.Click();
                if (isCollectionOpen) collection.Click();

                List<buttonEvent> events = new List<buttonEvent>() { new buttonEvent(BackToMenuButtonEvent), new buttonEvent(CreaturesCollectionButtonEvent), new buttonEvent(Save) };
                for (int i = 0; i < systemButtons.Count; i++)
                {
                    if (systemButtons[i].isContainMouse(BINDED_WINDOW))
                    {
                        events[i]();
                    }
                }
            }
            else {
                if (gameCloseCooldown.ElapsedTime.AsSeconds() >= 3) BackToMenuButtonEvent();
            }
        }

        private void BackToMenuButtonEvent() {
            Program.isMenuWindowVisible = true;
            Program.MenuWindow.SetVisible(true);
            Program.isGameWindowVisible = false;
            Program.GameWindow.SetVisible(false);
        }

        private void CreaturesCollectionButtonEvent() {

            isCollectionOpen = !isCollectionOpen;
        }

        private void Save() { }

        private void GameOver() {

            if (!isGameOver) {
                isGameOver = true;
                gameCloseCooldown = new Clock();
            }
            Vector2f POSITION = new Vector2f(145, 150);
            Sprite GameOverBackGround = new Sprite(Content.GameOverBackGround.texture, new IntRect(0, 0, Content.GameOverBackGround.width, Content.GameOverBackGround.height));
            Text GameOverText = new Text("GAME OVER", Content.MontserratFont, 42);
            Text FinalScoreText = new Text(TotalScore.ToString() + " points", Content.MontserratFont, 42);
            GameOverBackGround.Position = POSITION;
            GameOverText.Position = POSITION + new Vector2f(120, 70);
            FinalScoreText.Position = POSITION + new Vector2f(120, 140);
            GameOverText.Color = FinalScoreText.Color = Color.Black;
            BINDED_WINDOW.Draw(GameOverBackGround);
            BINDED_WINDOW.Draw(GameOverText);
            BINDED_WINDOW.Draw(FinalScoreText);

            if (TotalScore > SettingList.HighScore) {
                SettingList.HighScore = TotalScore;
            }
            //SettingList.games++;  
            ///TODO: counted every tick. Need to fix it.
            SettingList.UpdateSettings();
        }

        public void Fake() {
            CurrentCreature.Elephant.isAlive = false;
            CurrentCreature.Elk.isAlive = false;
            CurrentCreature.Owl.isAlive = false;
            CurrentCreature.Pig.isAlive = false;
            CurrentCreature.Pinguin.isAlive = false;
            CurrentCreature.Sheep.isAlive = false;
            CurrentCreature.Zebra.isAlive = false;
        }
    }
}
