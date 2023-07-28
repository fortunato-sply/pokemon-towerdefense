using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Metagross : Pokemon
    {
        public Metagross(int level = 20)
        {
            this.Name = "Metagross";
            this.Sprite = new Bitmap(@"assets\pokemons\metagross.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 4;

            this.minLevel = 20;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 5 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 18 + (9 * level);
            this.XpEvolve = 200 * level;
        }
    }
}
