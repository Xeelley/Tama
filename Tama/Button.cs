using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama
{
    class Button : Transformable, Drawable
    {
        public Sprite sprite;

        public Button(Texture texture, int posX, int posY, int width, int height, int RectX = 0, int RectY = 0)
        {
            sprite = new Sprite();
            sprite.Texture = texture;
            sprite.TextureRect = new IntRect(RectX, RectY, width, height);
            sprite.Position = new SFML.System.Vector2f(posX, posY);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            sprite.Draw(target, states);
        }

        public bool isContainMouse(RenderWindow win) {
            Vector2i MousePos = Mouse.GetPosition(win);
            Vector2f SpritePos = sprite.Position; 
            if (MousePos.X >= SpritePos.X && MousePos.X <= SpritePos.X + sprite.TextureRect.Width &&
                MousePos.Y >= SpritePos.Y && MousePos.Y <= SpritePos.Y + sprite.TextureRect.Height)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
