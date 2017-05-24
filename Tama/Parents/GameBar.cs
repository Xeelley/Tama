using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama.Parents
{
    class GameBar : WindowElement
    {
        public virtual void Click() {

            Vector2i positon = Mouse.GetPosition(Program.GameWindow);
            Console.WriteLine(positon.ToString());
            if (positon.X < 0 || positon.Y < 0) {
                Console.WriteLine("OUTSIDE!");
            }
        }

        public virtual void Update() {

            Console.WriteLine(Mouse.GetPosition(Program.GameWindow).ToString());
        }

        public virtual void Draw() { }
    }
}
