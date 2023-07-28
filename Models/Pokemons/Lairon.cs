using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Lairon : Pokemon
    {
        public Lairon(int level = 12)
        {
            this.Name = "Lairon";
            this.Sprite = new Bitmap(@"assets\pokemons\lairon.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 2;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 2;
            this.Power += 3 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 18 + (9 * level);
            this.XpEvolve = 200 * level;
            this.Evolution = new Aggron();
        }
    }
}
