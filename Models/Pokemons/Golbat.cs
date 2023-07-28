using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Golbat : Pokemon
    {
        public Golbat(int level = 7)
        {
            this.Name = "Golbat";
            this.Sprite = new Bitmap(@"assets\pokemons\golbat.png");

            this.Level = level;

            this.Type = Type.GetInstance("Flying");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 170 * level;
        }
    }
}
