using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Dragonite : Pokemon
    {
        public Dragonite(int level = 18)
        {
            this.Name = "Dragonite";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\dragonite.png");

            this.Level = level;

            this.Type = Type.GetInstance("Dragon");
            this.Tier = 4;

            this.minLevel = 18;
            this.SelectedAttack = new IcyWind();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 5 * Level;
            this.Life += 5 * level;
            this.ActualLife = Life;
            this.XpDrop = 35 + (17 * level);
            this.XpEvolve = 350 * level;
        }
    }
}
