using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Gyarados : Pokemon
    {
        public Gyarados(int level = 15)
        {
            this.Name = "Gyarados";
            this.Sprite = new Bitmap(@"assets\pokemons\gyarados.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 4;

            this.minLevel = 15;
            this.SelectedAttack = new Bite();
            this.Attacks = new List<Attack>();
            this.Speed = 6;
            this.Power += 4 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 30 + (15 * level);
            this.XpEvolve = 350 * level;
        }
    }
}