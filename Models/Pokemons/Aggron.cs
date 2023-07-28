using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Aggron : Pokemon
    {
        public Aggron(int level = 18)
        {
            this.Name = "Aggron";
            this.Sprite = new Bitmap(@"assets\pokemons\aggron.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 5 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
