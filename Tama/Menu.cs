using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tama.Options;

namespace Tama
{
    class Menu : WindowElement
    {
        const int ButtonMargin = 50, ButtonHeight = 100, ButtonWidth = 300, ButtonsAmount = 4;
        RenderWindow BINDED_WINDOW = Program.MenuWindow;
        
        List<Button> buttons;

        public Menu() {
            buttons = new List<Button>();
            for (int i = 0; i < ButtonsAmount; i++) {
                buttons.Add(new Button(Content.MenuButtons.texture, ButtonMargin, (ButtonMargin + ButtonHeight) * 
                i + ButtonMargin, ButtonWidth,  ButtonHeight, 0, ButtonHeight * i));
            }
        }

        public void Update() { }

        public void Draw()
        {
            foreach (Button button in buttons) {
                BINDED_WINDOW.Draw(button);
            }
        }

        public delegate void buttonEvent();
        
        public void Click() {

            List<buttonEvent> events = new List<buttonEvent>() { new buttonEvent(LoadGameButtonEvent), new buttonEvent(StartGameButtonEvent), new buttonEvent(OptionsButtonEvent), new buttonEvent(ExitButtonEvent) };
            for (int i = 0; i < buttons.Count; i++) {
                if (buttons[i].isContainMouse(BINDED_WINDOW)) {
                    events[i]();
                }
            }
        }

        private void LoadGameButtonEvent() {

            Program.GameWindow.SetVisible(true);
            Program.isGameWindowVisible = true;
            Program.MenuWindow.SetVisible(false);
            Program.isMenuWindowVisible = false;
            SettingList.LoadGame();
        }

        private void StartGameButtonEvent() {

            Program.GameWindow.SetVisible(true);
            Program.isGameWindowVisible = true;
            Program.MenuWindow.SetVisible(false);
            Program.isMenuWindowVisible = false;
            SettingList.NewGame();
        }

        private void OptionsButtonEvent() {

            Program.SettingsWindow.SetVisible(true);
            Program.isSettingWindowVisible = true;
            Program.MenuWindow.SetVisible(false);
            Program.isMenuWindowVisible = false;
        }

        private void ExitButtonEvent() {

            Program.MenuWindow.Close();
            
        }
    }
}
