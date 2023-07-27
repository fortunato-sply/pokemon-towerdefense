using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Mawile : Pokemon
    {
        public Mawile(int level = 15)
        {
            this.Name = "Mawile";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\mawile.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 3;

            this.minLevel = 15;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += 4 * level;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
