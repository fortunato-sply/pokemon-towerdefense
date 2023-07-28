using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Venusaur : Pokemon
    {
        public Venusaur(int level = 18)
        {
            this.Name = "Venusaur";
            this.Sprite = new Bitmap(@"assets\pokemons\venusaur.png");

            this.Level = level;

            this.Type = Type.GetInstance("Grass");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new RazorLeaf();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 30 + (15 * level);
            this.XpEvolve = 320 * level;
        }
    }
}
