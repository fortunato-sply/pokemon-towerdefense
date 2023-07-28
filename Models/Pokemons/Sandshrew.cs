using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Sandshrew : Pokemon
    {
        public Sandshrew(int level = 1)
        {
            this.Name = "Sandshrew";
            this.Sprite = new Bitmap(@"assets\pokemons\sandshrew.png");

            this.Level = level;

            this.Type = Type.GetInstance("Ground");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 20 * level;
            this.XpEvolve = 250 * level;

            this.Evolution = new Sandslash();
        }
    }
}
