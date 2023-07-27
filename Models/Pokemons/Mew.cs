using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Mew : Pokemon
    {
        public Mew(int level = 40)
        {
            this.Name = "Mew";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\mew.png");

            this.Level = level;

            this.Type = Type.GetInstance("All");
            this.Tier = 5;

            this.minLevel = 40;
            this.SelectedAttack = new ShadowBall();
            this.Attacks = new List<Attack>();
            this.Speed = 10;
            this.Defense = 10;
            this.Power += 10 * Level;
            this.Life += 10 * level;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
