using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Totodile : Pokemon
    {
        public Totodile(int level = 1)
        {
            this.Name = "Totodile";
            this.Sprite = new Bitmap(@"assets\pokemons\totodile.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
            this.Evolution = new Croconaw();
        }
    }
}
