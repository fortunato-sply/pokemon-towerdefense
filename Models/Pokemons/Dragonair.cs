using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Dragonair : Pokemon
    {
        public Dragonair(int level = 12)
        {
            this.Name = "Dragonair";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\dragonair.png");

            this.Level = level;

            this.Type = Type.GetInstance("Dragon");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new IcyWind();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 20 + (10 * level);
            this.XpEvolve = 250 * level;
            this.Evolution = new Dragonite();
        }
    }
}
