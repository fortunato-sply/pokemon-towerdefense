using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Cubone : Pokemon
    {
        public Cubone(int level = 1)
        {
            this.Name = "Cubnone";
            this.Sprite = new Bitmap(@"assets\pokemons\cubone.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 2;
            this.Power += 1 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 8 * level;
            this.XpEvolve = 160 * level;
            this.Evolution = new Marowak();
        }
    }
}
