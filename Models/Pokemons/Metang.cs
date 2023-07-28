using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Metang : Pokemon
    {
        public Metang(int level = 10)
        {
            this.Name = "Metang";
            this.Sprite = new Bitmap(@"assets\pokemons\metang.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 2;

            this.minLevel = 10;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 18 + (9 * level);
            this.XpEvolve = 200 * level;
            this.Evolution = new Metagross();
        }
    }
}
