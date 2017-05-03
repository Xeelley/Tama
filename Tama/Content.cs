using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama
{
    struct textureInfo {
        public Texture texture;
        public int height;
        public int width;

        public textureInfo(Texture texture, int height, int width) {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
    }

    class Content
    {
        public const string CONTENT_DIR = "..\\Content\\";

        //Fonts
        public static Font MontserratFont;

        //Buttons
        public static textureInfo MenuButtons, GameButtons, StatusIcons;

        //Creatures
        public static textureInfo CMonsterCat; 

        public static void Load() {

            MontserratFont = new Font(CONTENT_DIR + "\\Fonts\\Montserrat-Regular.ttf");

            MenuButtons = new textureInfo(new Texture(CONTENT_DIR + "\\Textures\\MenuButtonsSprite.png"), 400, 300);
            GameButtons = new textureInfo(new Texture(CONTENT_DIR + "\\Textures\\GameButtonsSprite.png"), 400, 300);
            StatusIcons = new textureInfo(new Texture(CONTENT_DIR + "\\Textures\\StatusIcons.png"), 30, 200);

            CMonsterCat = new textureInfo(new Texture(CONTENT_DIR + "\\Textures\\MonsterCat.png"), 400, 400);
        }

    }
}
