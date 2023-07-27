using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Tyranitar : Pokemon
    {
        public Tyranitar(int level = 18)
        {
            this.Name = "Tyranitar";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\tyranitar.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 4;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 3 * Level;
            this.Life += 6 * level;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
