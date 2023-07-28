using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Weedle : Pokemon
    {
        public Weedle(int level = 1)
        {
            this.Name = "Weedle";
            this.Sprite = new Bitmap(@"assets\pokemons\weedle.png");

            this.Level = level;

            this.Type = Type.GetInstance("Bug");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 8 + (4 * level);
            this.XpEvolve = 150 * level;
            this.Evolution = new Kakuna();
        }
    }
}
