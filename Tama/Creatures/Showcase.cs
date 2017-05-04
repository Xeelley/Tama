using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama.Creatures
{
    class Showcase
    {
        Vector2i POSIOTION = new Vector2i(240, 90), MARGIN = new Vector2i(70, 20);

        public Showcase() {

            
        }

        public void Draw() {

            CurrentCreature.creature.sprite.Position = new Vector2f(POSIOTION.X + MARGIN.X, POSIOTION.Y + MARGIN.Y);
            CurrentCreature.creature.Draw();
        }
    }
}
