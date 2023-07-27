using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Kingdra : Pokemon
    {
        public Kingdra(int level = 18)
        {
            this.Name = "Kingdra";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\kingdra.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 4;

            this.minLevel = 18;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 7;
            this.Power += 4 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
        }
    }
}
