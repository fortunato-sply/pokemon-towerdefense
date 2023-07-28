using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Golduck : Pokemon
    {
        public Golduck(int level = 15)
        {
            this.Name = "Golduck";
            this.Sprite = new Bitmap(@"assets\pokemons\golduck.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 3;

            this.minLevel = 15;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
        }
    }
}
