using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Charmander : Pokemon
    {
        public Charmander(int level = 1)
        {
            this.Name = "Charmander";
            this.Sprite = new Bitmap(@"assets\pokemons\charmander.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
            this.Evolution = new Charmeleon();
        }
    }
}
