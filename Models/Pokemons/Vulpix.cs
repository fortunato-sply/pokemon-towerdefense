using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Vulpix : Pokemon
    {
        public Vulpix(int level = 1)
        {
            this.Name = "Vulpix";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\vulpix.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.XpDrop = 60;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }

            this.Evolution = new Ninetales();
        }
    }
}
