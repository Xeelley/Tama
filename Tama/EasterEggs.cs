using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama
{
    class EasterEggs
    {
        string currentInputString;

        public EasterEggs() {
            currentInputString = "";

        }

        public void New() {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) currentInputString += "a";
            if (Keyboard.IsKeyPressed(Keyboard.Key.B)) currentInputString += "b";
            if (Keyboard.IsKeyPressed(Keyboard.Key.C)) currentInputString += "c";
        }

        public void Check() {
            if (currentInputString == "asddsa") {
                Program.Game.isGameOver = true;
            }
        }



    }
}
