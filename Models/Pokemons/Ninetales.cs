using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Ninetales : Pokemon
    {
        public Ninetales(int level = 14)
        {
            this.Name = "Ninetales";
            this.Sprite = new Bitmap(@"assets\pokemons\ninetales.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 2;

            this.minLevel = 14;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 6;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 34 + (17 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
