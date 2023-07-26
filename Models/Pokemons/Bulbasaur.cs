using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Bulbasaur : Pokemon
    {
        public Bulbasaur(int level = 1)
        {
            this.Name = "Bulbasaur";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\bulbasaur.png");

            this.Level = level;

            this.Type = Type.GetInstance("Grass");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new RazorLeaf();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 * level;
            this.XpEvolve = 180 * level;
            this.Evolution = new Ivysaur();
        }
    }
}
