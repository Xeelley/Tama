using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tama.Parents;

namespace Tama.Actions
{
    class ActionBar : GameBar
    {
        private Vector2f ACTION_BAR_POSITION = new Vector2f(280, 510);

        private List<Button> actionButtons;

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

        public override void Draw() {

            foreach (Button button in actionButtons)
            {
                Program.GameWindow.Draw(button);
            }
        }

        private delegate void buttonEvent();

        public override void Click()
        {
            if (CurrentCreature.creature.isAlive)
            {

                List<buttonEvent> events = new List<buttonEvent>() { new buttonEvent(Feed), new buttonEvent(Walk),
                                                                     new buttonEvent(Sleep), new buttonEvent(Wash),
                                                                     new buttonEvent(Special1), new buttonEvent(Special2)};
                for (int i = 0; i < actionButtons.Count; i++)
                {
                    if (actionButtons[i].isContainMouse(Program.GameWindow))
                    {
                        events[i]();
                    }
                }
            }
            else {
                Program.Game.logger.NewMessage(CurrentCreature.creature.name + " unavailable!");
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

            Program.Game.TotalScore += (int)(happinessChange + energyChange);
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

            Program.Game.TotalScore += (int)(happinessChange - 0.5f * energyChange - 0.5f * purifyChange);
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

            Program.Game.TotalScore += (int)(happinessChange + energyChange - 0.5f * purifyChange);
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

            Program.Game.TotalScore += (int)(purifyChange - 0.2f * energyChange);
        }

        private void Special1() {

            switch (CurrentCreature.creature.name) {

                case "Begemoth":
                    {
                        CurrentCreature.creature.Energy += 10;
                        CurrentCreature.creature.Purity -= 7;
                        Program.Game.logger.NewMessage(CurrentCreature.creature.name + " eats a huge\n" +
                                                       "barrel of honey!\n" + 
                                                       "-7 Purity\n" +
                                                       "+10 Energy");
                        Program.Game.TotalScore += 5;
                        break;
                    };
                case "Elephant":
                    {
                        CurrentCreature.creature.Happiness += 5;
                        CurrentCreature.creature.Purity += 5;
                        CurrentCreature.creature.Energy += 5;
                        Program.Game.logger.NewMessage(CurrentCreature.creature.name + " is big. Realy big.\n" +
                                                       "+5 to all stats");
                        Program.Game.TotalScore += 15;
                        break;
                    };
                case "Elk":
                    {
                        CurrentCreature.creature.Happiness += 7;
                        Program.Game.logger.NewMessage("Look at those horhs!\n" +
                                                       CurrentCreature.creature.name + " is exactly happy!\n" + 
                                                       "+7 Happiness");
                        Program.Game.TotalScore += 7;
                        break;
                    };
                case "Owl":
                    {
                        CurrentCreature.creature.Energy += 5;
                        Program.Game.logger.NewMessage("Night without sleep?\n" + 
                                                       "It's not a problem for " + CurrentCreature.creature.name + "!\n" +
                                                       "+5 Enegry");
                        Program.Game.TotalScore += 5;
                        break;
                    };
                case "Pig":
                    {
                        CurrentCreature.creature.Purity -= 15;
                        CurrentCreature.creature.Happiness += 20;
                        Program.Game.logger.NewMessage(CurrentCreature.creature.name + " finds an apple in a puddle!\n" +
                                                       "-15 Purity\n" +
                                                       "+20 Happiness");
                        Program.Game.TotalScore += 9;
                        break;
                    };
                case "Pinguin":
                    {
                        CurrentCreature.creature.Purity += 10;
                        Program.Game.logger.NewMessage(CurrentCreature.creature.name + " dives into the water!\n" +
                                                       "+10 Purity");
                        Program.Game.TotalScore += 10;
                        break;
                    };
                case "Sheep":
                    {
                        Program.Game.logger.NewMessage(CurrentCreature.creature.name + "^^\n" +
                                                       "Pretty but useless.\n" +
                                                       "Just +10 points");
                        Program.Game.TotalScore += 10;
                        break;
                    };
                case "Zebra":
                    {
                        CurrentCreature.creature.Happiness += 3;
                        CurrentCreature.creature.Energy += 4;
                        Program.Game.logger.NewMessage("The perfect combination\n" +
                                                       "of white & black.\n" +
                                                       "+3 Happiness\n" +
                                                       "+4 Energy");
                        Program.Game.TotalScore += 7;
                        break;
                    };
            }
        }

        private void Special2() {

            Random rand = new Random();

            if (rand.Next(0, 10) == 3)
            {

                switch (CurrentCreature.creature.name)
                {

                    case "Begemoth":
                        {
                            CurrentCreature.creature.Energy += 30;
                            CurrentCreature.creature.Purity -= 10;
                            Program.Game.logger.NewMessage(CurrentCreature.creature.name + " eats a huge\n" +
                                                           "watermelon!\n" +
                                                           "-10 Purity\n" +
                                                           "+30 Energy");
                            Program.Game.TotalScore += 25;
                            break;
                        };
                    case "Elephant":
                        {
                            CurrentCreature.creature.Happiness += 20;
                            CurrentCreature.creature.Purity += 20;
                            CurrentCreature.creature.Energy += 20;
                            Program.Game.logger.NewMessage(CurrentCreature.creature.name + " is the biggest!.\n" +
                                                           "+20 to all stats");
                            Program.Game.TotalScore += 60;
                            break;
                        };
                    case "Elk":
                        {
                            CurrentCreature.creature.Happiness += 45;
                            Program.Game.logger.NewMessage("*AMAZING HORNS*!\n" +
                                                           CurrentCreature.creature.name + " is exactly happy!\n" +
                                                           "+45 Happiness");
                            Program.Game.TotalScore += 45;
                            break;
                        };
                    case "Owl":
                        {
                            CurrentCreature.creature.Energy += 50;
                            Program.Game.logger.NewMessage("Week without sleep maybe?\n" +
                                                           "It's not a problem for " + CurrentCreature.creature.name + "!\n" +
                                                           "+50 Enegry");
                            Program.Game.TotalScore += 50;
                            break;
                        };
                    case "Pig":
                        {
                            CurrentCreature.creature.Purity -= 15;
                            CurrentCreature.creature.Happiness += 70;
                            Program.Game.logger.NewMessage(CurrentCreature.creature.name + " finds a diamond in a puddle!\n" +
                                                           "-15 Purity\n" +
                                                           "+70 Happiness");
                            Program.Game.TotalScore += 62;
                            break;
                        };
                    case "Pinguin":
                        {
                            CurrentCreature.creature.Purity += 20;
                            CurrentCreature.creature.Happiness += 20;
                            Program.Game.logger.NewMessage(CurrentCreature.creature.name + " dives into the water!\n" +
                                                           "+20 Purity\n" +
                                                           "+20 Happiness");
                            Program.Game.TotalScore += 40;
                            break;
                        };
                    case "Sheep":
                        {
                            Program.Game.logger.NewMessage(CurrentCreature.creature.name + "^^\n" +
                                                           "Just pretty.\n" +
                                                           "+100 points");
                            Program.Game.TotalScore += 100;
                            break;
                        };
                    case "Zebra":
                        {
                            CurrentCreature.creature.Happiness += 22;
                            CurrentCreature.creature.Energy += 22;
                            Program.Game.logger.NewMessage("The perfect creature.\n" +
                                                           "+22 Happiness\n" +
                                                           "+22 Energy");
                            Program.Game.TotalScore += 44;
                            break;
                        };
                }
            }
            else {
                Program.Game.logger.NewMessage("Bad luck :(");
            }
            
        }
    }
}
