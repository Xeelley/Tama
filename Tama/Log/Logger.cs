using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama.Log
{
    class Logger
    {
        Vector2f POSITON = new Vector2f(10, 90);
        int one;
        List<string> messages = new List<string>();
        
        public void NewMessage(string message) {

            if (messages.Count >= 4) messages.RemoveRange(0, 1);
            messages.Add(message);
        }

        public void Update() { }

        public void Draw() {

            Text text = new Text(getString(), Content.MontserratFont, 18);
            text.Color = Color.Black;
            text.Position = POSITON;

            Program.GameWindow.Draw(text);
        }

        private string getString() {

            string result = "";
            foreach (string message in messages) {
                result += (message + "\n");
            }

            return result;
        }

    }
}
