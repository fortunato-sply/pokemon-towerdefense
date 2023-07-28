using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Zubat : Pokemon
    {
        public Zubat(int level = 1)
        {
            this.Name = "Zubat";
            this.Sprite = new Bitmap(@"assets\pokemons\zubat.png");

            this.Level = level;

            this.Type = Type.GetInstance("Flying");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += 1 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 170 * level;

            this.Evolution = new Golbat();
        }
    }
}
