using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Ivysaur : Pokemon
    {
        public Ivysaur(int level = 7)
        {
            this.Name = "Ivysaur";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\ivysaur.png");

            this.Level = level;

            this.Type = Type.GetInstance("Grass");
            this.Tier = 2;

            this.minLevel = 7;
            this.SelectedAttack = new RazorLeaf();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.XpDrop = 60;
            this.ActualLife = Life;
            this.XpDrop = 24 * level;
            this.XpEvolve = 250 * level;
            this.Evolution = new Venusaur();
        }
    }
}
