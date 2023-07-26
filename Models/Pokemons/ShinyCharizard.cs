using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class ShinyCharizard : Pokemon
    {
        public ShinyCharizard(int level = 24)
        {
            this.Name = "S. Charizard";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\scharizard.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 3;

            this.minLevel = 24;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 10;
            this.Power += 5 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 50 * level;
            this.XpEvolve = 450 * level;
        }
    }
}
