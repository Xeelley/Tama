using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama.Options
{
    static class SettingList {

        static public bool Sounds = false;
        static public int games = 0;
        static public int HighScore = 0;

        static public void DownloadSettings() {

            using (System.IO.StreamReader reader = new System.IO.StreamReader(Content.settingFile))
            {
                short count = 0;
                while (!reader.EndOfStream)
                {
                    string[] ReaderString = reader.ReadLine().Split('=');

                    switch (count) {
                        case 0: Sounds = Convert.ToBoolean(ReaderString[1]); break;
                        case 1: games = Convert.ToInt32(ReaderString[1]); break;
                        case 2: HighScore = Convert.ToInt32(ReaderString[1]); break;
                    }

                    count++;
                }
            }
        }

        static public void UpdateSettings() {

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Content.settingFile, false)) {

                writer.WriteLine("[SOUND]=" + Sounds);
                writer.WriteLine("[GAMES]=" + games);
                writer.WriteLine("[HIGHSCORE]=" + HighScore);

            }
        }

        static public void SaveGame(int score)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Content.saveFile, false))
            {
                writer.WriteLine("Score=" + score);

                List<Creature> creatures = new List<Creature> { CurrentCreature.Begemoth,  CurrentCreature.Elephant,
                CurrentCreature.Elk, CurrentCreature.Owl, CurrentCreature.Pig, CurrentCreature.Pinguin,
                CurrentCreature.Sheep, CurrentCreature.Zebra };

                foreach (Creature cr in creatures) {

                    writer.WriteLine("[" + cr.name + "]");
                    writer.WriteLine("Happiness=" + cr.Happiness);
                    writer.WriteLine("Energy=" + cr.Energy);
                    writer.WriteLine("Purity=" + cr.Purity);
                }
            }
        }

        static public void LoadGame() {

            using (System.IO.StreamReader reader = new System.IO.StreamReader(Content.saveFile))
            {
                int Score;
                string[] ReaderString;

                ReaderString = reader.ReadLine().Split('=');
                Score = Convert.ToInt32(ReaderString[1]);

                List<Creature> creatures = new List<Creature> { CurrentCreature.Begemoth,  CurrentCreature.Elephant,
                CurrentCreature.Elk, CurrentCreature.Owl, CurrentCreature.Pig, CurrentCreature.Pinguin,
                CurrentCreature.Sheep, CurrentCreature.Zebra };

                foreach (Creature cr in creatures) {

                    ReaderString = reader.ReadLine().Split('=');
                    ReaderString = reader.ReadLine().Split('=');
                    cr.Happiness = (float)(Convert.ToDouble(ReaderString[1]));
                    ReaderString = reader.ReadLine().Split('=');
                    cr.Energy = (float)(Convert.ToDouble(ReaderString[1]));
                    ReaderString = reader.ReadLine().Split('=');
                    cr.Purity = (float)(Convert.ToDouble(ReaderString[1]));
                }

                reader.Close();

                Program.Game.TotalScore = Score;
            }
        }

        static public void NewGame()
        {
            CurrentCreature.Begemoth.SetStats(120, 60, 70);
            CurrentCreature.Elephant.SetStats(110, 60, 70);
            CurrentCreature.Elk.SetStats(80, 100, 80);
            CurrentCreature.Owl.SetStats(110, 120, 110);
            CurrentCreature.Pig.SetStats(140, 30, 100);
            CurrentCreature.Pinguin.SetStats(100, 110, 90);
            CurrentCreature.Sheep.SetStats(80, 60, 120);
            CurrentCreature.Zebra.SetStats(100, 100, 100);

            Program.Game.TotalScore = 0;
        }
    }

    class Settings : WindowElement
    {
        RenderWindow TARGET_WIN = Program.SettingsWindow;

        List<Button> buttons;
        Text soundText, gamesText, highScoreText;

        public Settings() {

            buttons = new List<Button>(); 
            buttons.Add(new Button(Content.GameButtons.texture, 30, 30, 50, 50, 0, 100));       //Return to menu
            buttons.Add(new Button(Content.GameButtons.texture, 200, 120, 50, 50, 50, 100));      //Sound on
            buttons.Add(new Button(Content.GameButtons.texture, 280, 120, 50, 50, 100, 100));     //Sound off
            buttons.Add(new Button(Content.GameButtons.texture, 110, 30, 50, 50, 150, 100));    //Reset stats

            gamesText = new Text("Games: " + SettingList.games.ToString(), Content.MontserratFont, 36);
            highScoreText = new Text("HighScore: " + SettingList.HighScore.ToString(), Content.MontserratFont, 36);
            soundText = new Text("Sounds: ", Content.MontserratFont, 36);
            soundText.Color = gamesText.Color = highScoreText.Color = Color.Black;
            soundText.Position = new SFML.System.Vector2f(50, 120);
            gamesText.Position = new SFML.System.Vector2f(80, 200);
            highScoreText.Position = new SFML.System.Vector2f(20, 250);
        }

        delegate void buttonEvent(); 

        public void Click() {

            List<buttonEvent> events = new List<buttonEvent>() { new buttonEvent(BackToMenu),  new buttonEvent(TurnSoundOn),
                                                                 new buttonEvent(TurnSounOff), new buttonEvent(ResetStats) };
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].isContainMouse(TARGET_WIN))
                {
                    events[i]();
                }
            }
        }

        public void Update() {

            gamesText.DisplayedString = "Games: " + SettingList.games.ToString();
            highScoreText.DisplayedString = "HighScore: " + SettingList.HighScore.ToString();

        }

        public void Draw() {

            foreach (Button button in buttons) {
                TARGET_WIN.Draw(button);
            }

            TARGET_WIN.Draw(soundText);
            TARGET_WIN.Draw(gamesText);
            TARGET_WIN.Draw(highScoreText);

        }

        private void BackToMenu() {

            Program.SettingsWindow.SetVisible(false);
            Program.isSettingWindowVisible = false;
            Program.MenuWindow.SetVisible(true);
            Program.isMenuWindowVisible = true;
        }

        private void TurnSoundOn() {

            SettingList.Sounds = true;
            SettingList.UpdateSettings();
        }

        private void TurnSounOff() {

            SettingList.Sounds = false;
            SettingList.UpdateSettings();
        }

        private void ResetStats() {

            SettingList.Sounds = false;
            SettingList.games = 0;
            SettingList.HighScore = 0;
            SettingList.UpdateSettings();
        }
    }
}
