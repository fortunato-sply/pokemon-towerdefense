using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Marowak : Pokemon
    {
        public Marowak(int level = 12)
        {
            this.Name = "Marowak";
            this.Sprite = new Bitmap(@"assets\pokemons\marowak.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 2;

            this.minLevel = 12;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 8 * level;
            this.XpEvolve = 160 * level;
        }
    }
}
