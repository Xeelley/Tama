using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama
{
    struct CreatureSpeedBreakets {

        public float HappinessIndex, PurityIndex, EnergyIndex;

        public CreatureSpeedBreakets(float HappinessIndex, float PurityIndex, float EnergyIndex) {
            this.HappinessIndex = HappinessIndex;
            this.PurityIndex = PurityIndex;
            this.EnergyIndex = EnergyIndex;
        }
    }

    struct CreatureRandomBreackets {

        public int feedStart, feedLimit, walkStart, walkLimit, sleepStart, sleepLimit, washStart, washLimit;

        public CreatureRandomBreackets(int feedStart, int feedLimit, int walkStart, int walkLimit, int sleepStart, int sleepLimit, 
                                       int washStart, int washLimit) {
            this.feedStart = feedStart;
            this.feedLimit = feedLimit;
            this.walkStart = walkStart;
            this.walkLimit = walkLimit;
            this.sleepStart = sleepStart;
            this.sleepLimit = sleepLimit;
            this.washStart = washStart;
            this.washLimit = washLimit;
        }
    }

    class Creature 
    {
        RenderWindow TARGET_WONDOW = Program.GameWindow;

        public Sprite sprite;

        public string name; 

        public float Happiness, Purity, Energy;
        public CreatureRandomBreackets creatureRandomBreackets = new CreatureRandomBreackets(6, 2, 4, 1, 5, 2, 6, 2);
        public CreatureSpeedBreakets creatureSpeedBreakets = new CreatureSpeedBreakets(1f, 1.2f, 1.1f);

        public Creature(string name, int posX, int posY, float Happiness, float Purity, float Energy) {
            this.name = name;
            sprite = new Sprite();
            sprite.Texture = Content.CMonsterCat.texture;
            sprite.TextureRect = new IntRect(0, 0, Content.CMonsterCat.width, Content.CMonsterCat.height);
            sprite.Position = new SFML.System.Vector2f(posX, posY);

            this.Happiness = Happiness;
            this.Purity = Purity;
            this.Energy = Energy;
        }

        public void Update() {

            float elapsedTime = Program.elapsedTime;

            if (Happiness >= 0) Happiness -= elapsedTime * 0.001f * this.creatureSpeedBreakets.HappinessIndex;
            else Happiness = 0;
            if (Purity >= 0) Purity -= elapsedTime * 0.001f * this.creatureSpeedBreakets.PurityIndex;
            else Purity = 0;
            if (Energy >= 0) Energy -= elapsedTime * 0.001f * this.creatureSpeedBreakets.EnergyIndex;
            else Energy = 0;
        }

        public void Draw()
        {
            TARGET_WONDOW.Draw(sprite);
        }
    }
}
