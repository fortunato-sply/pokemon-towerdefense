using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Dratini : Pokemon
    {
        public Dratini(int level = 1)
        {
            this.Name = "Dratini";
            this.Sprite = new Bitmap(@"assets\pokemons\dratini.png");

            this.Level = level;

            this.Type = Type.GetInstance("Dragon");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new IcyWind();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.XpDrop = 60;
            this.ActualLife = Life;
            this.XpDrop = 14 + (7 * level);
            this.XpEvolve = 180 * level;
            this.Evolution = new Dragonair();
        }
    }
}
