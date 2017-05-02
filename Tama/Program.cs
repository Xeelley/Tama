using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Tama
{
    class Program
    {
        private static RenderWindow gameWindow;
        private static RenderWindow menuWindow;

        public static RenderWindow MenuWindow { get { return menuWindow; } }
        public static RenderWindow GameWindow { get { return gameWindow; } }

        public static Game Game { private set; get; }
        public static Menu Menu { private set; get; }

        public static bool isGameWindowVisible;
        public static bool isMenuWindowVisible;

        static void Main(string[] args)
        {
            menuWindow = new RenderWindow(new SFML.Window.VideoMode(400, 650), "Tamagochi by_XLY");
            gameWindow = new RenderWindow(new SFML.Window.VideoMode(1200, 800), "Tamagochi by_XLY");
            menuWindow.SetVerticalSyncEnabled(true);
            gameWindow.SetVerticalSyncEnabled(true);

            menuWindow.Closed += menuWindowClosed;
            menuWindow.Resized += menuWindowResized;
            gameWindow.Closed += gameWindowClosed;
            GameWindow.Resized += gameWindowResized;

            gameWindow.SetVisible(false);
            isGameWindowVisible = false;
            isMenuWindowVisible = true;
            
            

            Content.Load();

            Menu = new Menu();
            Game = new Game();

            while (menuWindow.IsOpen) {

                if (isMenuWindowVisible) {

                    menuWindow.DispatchEvents();

                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {

                        Menu.Click();
                    }

                    Menu.Update();
                    menuWindow.Clear(Color.White);
                    Menu.Draw();

                    menuWindow.Display();
                }

                if (isGameWindowVisible) {

                    gameWindow.DispatchEvents();

                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        Game.Click();
                    }

                    Game.Update();
                    gameWindow.Clear(Color.White);
                    Game.Draw();

                    gameWindow.Display();
                }
            }
        }

        private static void gameWindowResized(object sender, SizeEventArgs e)
        {
            gameWindow.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void gameWindowClosed(object sender, EventArgs e)
        {
            gameWindow.Close();
        }

        private static void menuWindowResized(object sender, SizeEventArgs e)
        {
            menuWindow.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void menuWindowClosed(object sender, EventArgs e)
        {
            menuWindow.Close();
        }
    }
}
