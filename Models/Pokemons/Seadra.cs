using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Seadra : Pokemon
    {
        public Seadra(int level = 7)
        {
            this.Name = "Seadra";
            this.Sprite = new Bitmap(@"assets\pokemons\seadra.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 2;

            this.minLevel = 7;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 1 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
            this.Evolution = new Kingdra();
        }
    }
}
