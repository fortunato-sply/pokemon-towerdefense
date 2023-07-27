using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Sandslash : Pokemon
    {
        public Sandslash(int level = 15)
        {
            this.Name = "Sandslash";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\sandslash.png");

            this.Level = level;

            this.Type = Type.GetInstance("Ground");
            this.Tier = 3;

            this.minLevel = 15;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 20 * level;
            this.XpEvolve = 250 * level;
        }
    }
}
