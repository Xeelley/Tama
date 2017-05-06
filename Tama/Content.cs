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

    struct CreaturesStruct {
        public Texture Begemoth;
        public Texture Elephant;
        public Texture Elk;
        public Texture Owl;
        public Texture Pig;
        public Texture Pinguin;
        public Texture Sheep;
        public Texture Zebra;

        public CreaturesStruct(Texture Begemoth, Texture Elephant, Texture Elk, Texture Owl, Texture Pig, Texture Pinguin, Texture Sheep, Texture Zebra) {
            this.Begemoth = Begemoth;
            this.Elephant = Elephant;
            this.Elk = Elk;
            this.Owl = Owl;
            this.Pig = Pig;
            this.Pinguin = Pinguin;
            this.Sheep = Sheep;
            this.Zebra = Zebra;
        }
    }

    class Content
    {
        public const string TEXTURES_DIR = "..\\Content\\Textures\\";
        public const string FONTS_DIR = "..\\Content\\Fonts\\";

        //Fonts
        public static Font MontserratFont;

        //Buttons
        public static textureInfo MenuButtons, GameButtons, StatusIcons;

        //Creatures
        public static textureInfo CMonsterCat;
        public static CreaturesStruct ShowcaseCreatureTextures;
        public static CreaturesStruct MinCreatureTextures;

        public static textureInfo CollectionBackGround, GameOverBackGround;
        public static Texture UnavailableSprite, UnavailableMinSprite;

        //Setting files
        public static string settingFile;

        public static void Load() {

            MontserratFont = new Font(FONTS_DIR + "\\Montserrat-Regular.ttf");

            MenuButtons = new textureInfo(new Texture(TEXTURES_DIR + "\\MenuButtonsSprite.png"), 400, 300);
            GameButtons = new textureInfo(new Texture(TEXTURES_DIR + "\\GameButtonsSprite.png"), 400, 300);
            StatusIcons = new textureInfo(new Texture(TEXTURES_DIR + "\\StatusIcons.png"), 30, 200);

            CMonsterCat = new textureInfo(new Texture(TEXTURES_DIR + "\\MonsterCat.png"), 400, 400);

            ShowcaseCreatureTextures = new CreaturesStruct(new Texture(TEXTURES_DIR + "\\BegemothSprite.png"),
                                                           new Texture(TEXTURES_DIR + "\\ElephantSprite.png"),
                                                           new Texture(TEXTURES_DIR + "\\ElkSprite.png"),
                                                           new Texture(TEXTURES_DIR + "\\OwlSprite.png"),
                                                           new Texture(TEXTURES_DIR + "\\PigSprite.png"),
                                                           new Texture(TEXTURES_DIR + "\\PinguinSprite.png"),
                                                           new Texture(TEXTURES_DIR + "\\SheepSprite.png"),
                                                           new Texture(TEXTURES_DIR + "\\ZebraSprite.png"));
            MinCreatureTextures = new CreaturesStruct(new Texture(TEXTURES_DIR + "\\BegemothMinSprite.png"),
                                                      new Texture(TEXTURES_DIR + "\\ElephantMinSprite.png"),
                                                      new Texture(TEXTURES_DIR + "\\ElkMinSprite.png"),
                                                      new Texture(TEXTURES_DIR + "\\OwlMinSprite.png"),
                                                      new Texture(TEXTURES_DIR + "\\PigMinSprite.png"),
                                                      new Texture(TEXTURES_DIR + "\\PinguinMinSprite.png"),
                                                      new Texture(TEXTURES_DIR + "\\SheepMinSprite.png"),
                                                      new Texture(TEXTURES_DIR + "\\ZebraMinSprite.png"));

            CollectionBackGround = new textureInfo(new Texture(TEXTURES_DIR + "\\CollectionBackGround.png"), 200, 340);
            GameOverBackGround = new textureInfo(new Texture(TEXTURES_DIR + "\\GameOverBackGround.png"), 300, 510);

            UnavailableSprite = new Texture(TEXTURES_DIR + "\\UnavailableSprite.png");
            UnavailableMinSprite = new Texture(TEXTURES_DIR + "\\UnavailableMinSprite.png");


            settingFile = "..\\Content\\Settings.txt";
        }

    }
}
