using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Onix : Pokemon
    {
        public Onix(int level = 1)
        {
            this.Name = "Onix";
            this.Sprite = new Bitmap(@"assets\pokemons\onix.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 4;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 7;
            this.Defense = 8;
            this.Power += 3 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 34 + (17 * level);
            this.XpEvolve = 340 * level;
        }
    }
}
