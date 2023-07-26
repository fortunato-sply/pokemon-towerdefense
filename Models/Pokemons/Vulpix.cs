using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Vulpix : Pokemon
    {
        public Vulpix(int level = 1)
        {
            this.Name = "Vulpix";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\vulpix.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 15 * level;
            this.XpEvolve = 220 * level;
            this.Evolution = new Ninetales();
        }
    }
}
