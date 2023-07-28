using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Feraligatr : Pokemon
    {
        public Feraligatr(int level = 18)
        {
            this.Name = "Feraligatr";
            this.Sprite = new Bitmap(@"assets\pokemons\feraligatr.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 3;

            this.minLevel = 7;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
        }
    }
}
