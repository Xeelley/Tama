using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tama.Parents;

namespace Tama.Stats
{
    class StatusBar : GameBar
    {
        Vector2f POSIOTION = new Vector2f(210, 35);
        Font font;
        Text happinessValue, purityValue, energyValue, creatureName;
        List<Sprite> icons;

        public StatusBar() {

            font = Content.MontserratFont;
            icons = new List<Sprite>();

            icons.Add(new Sprite(Content.StatusIcons.texture, new IntRect(0, 0, 30, 30)));
            icons.Add(new Sprite(Content.StatusIcons.texture, new IntRect(30, 0, 30, 30)));
            icons.Add(new Sprite(Content.StatusIcons.texture, new IntRect(60, 0, 30, 30)));
            icons[0].Position = new Vector2f(90, 30) + POSIOTION;
            icons[1].Position = new Vector2f(240, 30) + POSIOTION;
            icons[2].Position = new Vector2f(390, 30) + POSIOTION;

            happinessValue = new Text(Math.Round(CurrentCreature.creature.Happiness).ToString(), font, 30);
            purityValue = new Text(Math.Round(CurrentCreature.creature.Energy).ToString(), font, 30);
            energyValue = new Text(Math.Round(CurrentCreature.creature.Purity).ToString(), font, 30);
            creatureName = new Text(CurrentCreature.creature.name, font, 36);
            happinessValue.Color = purityValue.Color = energyValue.Color = creatureName.Color = Color.Black;
            happinessValue.Position = new Vector2f(140, 28) + POSIOTION;
            purityValue.Position = new Vector2f(290, 28) + POSIOTION;
            energyValue.Position = new Vector2f(440, 28) + POSIOTION;
            creatureName.Position = new Vector2f(300, 10);
        }

        public override void Update() {
            happinessValue.DisplayedString = Math.Round(CurrentCreature.creature.Happiness).ToString();
            purityValue.DisplayedString = Math.Round(CurrentCreature.creature.Energy).ToString();
            energyValue.DisplayedString = Math.Round(CurrentCreature.creature.Purity).ToString();
            creatureName.DisplayedString = CurrentCreature.creature.name;
        }

        public override void Draw() {

            foreach (Sprite icon in icons) {
                Program.GameWindow.Draw(icon);
            }

            Program.GameWindow.Draw(happinessValue);
            Program.GameWindow.Draw(purityValue);
            Program.GameWindow.Draw(energyValue);
            Program.GameWindow.Draw(creatureName);

        }

    }
}
