using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Magikarp : Pokemon
    {
        public Magikarp(int level = 1)
        {
            this.Name = "Magikarp";
            this.Sprite = new Bitmap(@"assets\pokemons\magikarp.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 1 * Level;
            this.Life += 1 * level;
            this.ActualLife = Life;
            this.XpDrop = 5 + (2 * level);
            this.XpEvolve = 180 * level;
            this.Evolution = new Gyarados();
        }
    }
}
