using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Caterpie : Pokemon
    {
        public Caterpie(int level = 1)
        {
            this.Name = "Caterpie";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\caterpie.png");

            this.Level = level;

            this.Type = Type.GetInstance("Bug");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += 1 * level; 
            this.ActualLife = Life;
            this.XpDrop = 8 + (4 * level);
            this.XpEvolve = 160 * level;
            this.Evolution = null;
        }
    }
}
