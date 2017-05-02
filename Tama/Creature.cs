using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama
{
    class Creature : Transformable, Drawable
    {
        private Model model;

        public Creature() {
            model = new Model();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(model, states);
        }
    }
}
