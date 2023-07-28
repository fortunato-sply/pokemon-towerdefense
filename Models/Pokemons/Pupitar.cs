using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Pupitar : Pokemon
    {
        public Pupitar(int level = 8)
        {
            this.Name = "Pupitar";
            this.Sprite = new Bitmap(@"assets\pokemons\pupitar.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 2;

            this.minLevel = 8;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;

            this.Evolution = new Tyranitar();
        }
    }
}
