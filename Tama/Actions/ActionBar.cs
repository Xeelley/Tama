using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tama.Actions
{
    class ActionBar
    {
        Vector2f ACTION_BAR_POSITION = new Vector2f(280, 510);

        List<Button> actionButtons;

        public ActionBar() {
            actionButtons = new List<Button>();
            actionButtons.Add(new Button(Content.GameButtons.texture, 20, 20, 50, 50, 0, 50));
            actionButtons.Add(new Button(Content.GameButtons.texture, 90, 20, 50, 50, 50, 50));
            actionButtons.Add(new Button(Content.GameButtons.texture, 160, 20, 50, 50, 100, 50));
            actionButtons.Add(new Button(Content.GameButtons.texture, 230, 20, 50, 50, 150, 50));
            actionButtons.Add(new Button(Content.GameButtons.texture, 360, 20, 50, 50, 200, 50));
            actionButtons.Add(new Button(Content.GameButtons.texture, 430, 20, 50, 50, 250, 50));
            foreach (Button button in actionButtons) {
                button.sprite.Position += ACTION_BAR_POSITION;
            }
        }

        public void Draw() {

            foreach (Button button in actionButtons)
            {
                Program.GameWindow.Draw(button);
            }
        }

        private delegate void buttonEvent();

        public void Click()
        {
            //Console.WriteLine(Mouse.GetPosition(Program.GameWindow).ToString());

            List<buttonEvent> events = new List<buttonEvent>() { new buttonEvent(Feed), new buttonEvent(Walk), new buttonEvent(Sleep),
                                                                 new buttonEvent(Wash), new buttonEvent(Special1), new buttonEvent(Special2)};
            for (int i = 0; i < actionButtons.Count; i++)
            {
                if (actionButtons[i].isContainMouse(Program.GameWindow))
                {
                    events[i]();
                }
            }
        }

        private Random random = new Random();

        private void Feed() {

            float happinessChange = 0.5f * CurrentCreature.creature.creatureRandomBreackets.feedStart +
                random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.feedLimit, CurrentCreature.creature.creatureRandomBreackets.feedLimit);
            float energyChange = happinessChange * 2 + random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.feedLimit, CurrentCreature.creature.creatureRandomBreackets.feedLimit);

            CurrentCreature.creature.Happiness += happinessChange;
            CurrentCreature.creature.Energy += energyChange;

            Program.Game.logger.NewMessage(CurrentCreature.creature.name + " was fed:\n" +
                                           "+" + Math.Round(happinessChange) + " Happiness\n" +
                                           "+" + Math.Round(energyChange) + " Energy");
        }

        private void Walk() {

            float happinessChange = CurrentCreature.creature.creatureRandomBreackets.walkStart +
                random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.walkLimit, CurrentCreature.creature.creatureRandomBreackets.walkLimit);
            float energyChange = 0.5f * happinessChange + random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.walkLimit, CurrentCreature.creature.creatureRandomBreackets.walkLimit);
            float purifyChange = 0.5f * happinessChange + random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.walkLimit, CurrentCreature.creature.creatureRandomBreackets.walkLimit);

            CurrentCreature.creature.Happiness += happinessChange;
            CurrentCreature.creature.Energy -= energyChange;
            CurrentCreature.creature.Purity -= purifyChange;

            Program.Game.logger.NewMessage("You walked with " + CurrentCreature.creature.name + ":\n" +
                                           "+" + Math.Round(happinessChange) + " Happiness\n" +
                                           "-" + Math.Round(energyChange) + " Energy\n" + 
                                           "-" + Math.Round(purifyChange) + " Purity");
        }

        private void Sleep() {

            float happinessChange = CurrentCreature.creature.creatureRandomBreackets.sleepStart +
                random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.sleepLimit, CurrentCreature.creature.creatureRandomBreackets.sleepLimit);
            float energyChange = happinessChange + random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.sleepLimit, CurrentCreature.creature.creatureRandomBreackets.sleepLimit);
            float purifyChange = happinessChange + random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.sleepLimit, CurrentCreature.creature.creatureRandomBreackets.sleepLimit);

            CurrentCreature.creature.Happiness += happinessChange;
            CurrentCreature.creature.Energy += energyChange;
            CurrentCreature.creature.Purity -= purifyChange;

            Program.Game.logger.NewMessage(CurrentCreature.creature.name + " slept well:\n" +
                                           "+" + Math.Round(happinessChange) + " Happiness\n" +
                                           "+" + Math.Round(energyChange) + " Energy\n" +
                                           "-" + Math.Round(purifyChange) + " Purity");
        }

        private void Wash() {

            float energyChange = CurrentCreature.creature.creatureRandomBreackets.washStart +
                random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.washLimit, CurrentCreature.creature.creatureRandomBreackets.washLimit);
            float purifyChange = 0.6f * energyChange + random.Next(-1 * CurrentCreature.creature.creatureRandomBreackets.washLimit, CurrentCreature.creature.creatureRandomBreackets.washLimit);

            CurrentCreature.creature.Energy -= energyChange;
            CurrentCreature.creature.Purity += purifyChange;

            Program.Game.logger.NewMessage("You washed " + CurrentCreature.creature.name + ":\n" +
                                           "-" + Math.Round(energyChange) + " Energy\n" +
                                           "+" + Math.Round(purifyChange) + " Purity");
        }

        private void Special1() { }
        private void Special2() { }
    }
}
