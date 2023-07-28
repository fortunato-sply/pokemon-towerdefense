using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Glalie : Pokemon
    {
        public Glalie(int level = 15)
        {
            this.Name = "Glalie";
            this.Sprite = new Bitmap(@"assets\pokemons\glalie.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 3;

            this.minLevel = 15;
            this.SelectedAttack = new IcyWind();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 30 + (15 * level);
            this.XpEvolve = 350 * level;
        }
    }
}