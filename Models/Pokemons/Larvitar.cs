using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Larvitar : Pokemon
    {
        public Larvitar(int level = 1)
        {
            this.Name = "Larvitar";
            this.Sprite = new Bitmap(@"assets\pokemons\larvitar.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;

            this.Evolution = new Pupitar();
        }
    }
}
