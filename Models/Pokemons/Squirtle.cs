using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Squirtle : Pokemon
    {
        public Squirtle(int level = 1)
        {
            this.Name = "Squirtle";
            this.Sprite = new Bitmap(@"assets\pokemons\squirtle.png");

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
            this.Evolution = new Wartotle();
        }
    }
}
