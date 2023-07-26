using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Raichu : Pokemon
    {
        public Raichu(int level = 18)
        {
            this.Name = "Raichu";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\raichu.png");

            this.Level = level;

            this.Type = Type.GetInstance("Electric");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new ThunderVolt();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 4 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 25 * level;
            this.XpEvolve = 280 * level;
        }
    }
}
