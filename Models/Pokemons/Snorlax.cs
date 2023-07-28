using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Snorlax : Pokemon
    {
        public Snorlax(int level = 18)
        {
            this.Name = "Snorlax";
            this.Sprite = new Bitmap(@"assets\pokemons\snorlax.png");

            this.Level = level;

            this.Type = Type.GetInstance("Normal");
            this.Tier = 4;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 3 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.Defense = 90;
            this.ActualLife = Life;
            this.XpDrop = 40 + (20 * level);
            this.XpEvolve = 350 * level;
        }
    }
}
