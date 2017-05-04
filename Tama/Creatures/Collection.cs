using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama.Creatures
{
    class Collection
    {
        Vector2i POSITION = new Vector2i(100, 100);

        Sprite CollectionBackGround;

        List<Button> CreatureButtons; 


        public Collection() {

            CollectionBackGround = new Sprite(Content.CollectionBackGround.texture,
                                   new IntRect(0, 0, Content.CollectionBackGround.width, Content.CollectionBackGround.height));
            CollectionBackGround.Position = (Vector2f)POSITION;

            CreatureButtons = new List<Button>();
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Begemoth, POSITION.X + 40,  POSITION.Y + 40,  50, 50));
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Elephant, POSITION.X + 110, POSITION.Y + 40,  50, 50));
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Elk,      POSITION.X + 180, POSITION.Y + 40,  50, 50));
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Owl,      POSITION.X + 250, POSITION.Y + 40,  50, 50));
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Pig,      POSITION.X + 40,  POSITION.Y + 110, 50, 50));
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Pinguin,  POSITION.X + 110, POSITION.Y + 110, 50, 50));
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Sheep,    POSITION.X + 180, POSITION.Y + 110, 50, 50));
            CreatureButtons.Add(new Button(Content.MinCreatureTextures.Zebra,    POSITION.X + 250, POSITION.Y + 110, 50, 50));

        }

        public void Update() {

            if (!CurrentCreature.creature.isAlive) {
                CreatureButtons[CurrentCreature.index].sprite.Texture = Content.UnavailableMinSprite;
            }
        }

        public void Draw() {

            Program.GameWindow.Draw(CollectionBackGround);
            foreach (Button button in CreatureButtons) {
                Program.GameWindow.Draw(button);
            }
        }

        public void Click() {

            for (int i = 0; i < CreatureButtons.Count; i++)
            {
                if (CreatureButtons[i].isContainMouse(Program.GameWindow))
                {
                    switch (i) {
                        case 0: CurrentCreature.creature = CurrentCreature.Begemoth; CurrentCreature.index = 0; break;
                        case 1: CurrentCreature.creature = CurrentCreature.Elephant; CurrentCreature.index = 1; break;
                        case 2: CurrentCreature.creature = CurrentCreature.Elk;      CurrentCreature.index = 2; break;
                        case 3: CurrentCreature.creature = CurrentCreature.Owl;      CurrentCreature.index = 3; break;
                        case 4: CurrentCreature.creature = CurrentCreature.Pig;      CurrentCreature.index = 4; break;
                        case 5: CurrentCreature.creature = CurrentCreature.Pinguin;  CurrentCreature.index = 5; break;
                        case 6: CurrentCreature.creature = CurrentCreature.Sheep;    CurrentCreature.index = 6; break;
                        case 7: CurrentCreature.creature = CurrentCreature.Zebra;    CurrentCreature.index = 7; break;
                    }
                    Program.Game.isCollectionOpen = false;
                }
            }
        }
    }
}
