using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Lapras : Pokemon
    {
        public Lapras(int level = 15)
        {
            this.Name = "Lapras";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\lapras.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 4;

            this.minLevel = 15;
            this.SelectedAttack = new IcyWind();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 4 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 30 + (15 * level);
            this.XpEvolve = 350 * level;
        }
    }
}