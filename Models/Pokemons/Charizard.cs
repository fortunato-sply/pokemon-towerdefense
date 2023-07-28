using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Charizard : Pokemon
    {
        public Charizard(int level = 18)
        {
            this.Name = "Charizard";
            this.Sprite = new Bitmap(@"assets\pokemons\charizard.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 7;
            this.Power += 4 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 35 + (17 * level);
            this.XpEvolve = 370 * level;
        }
    }
}
