using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Aron : Pokemon
    {
        public Aron(int level = 1)
        {
            this.Name = "Aron";
            this.Sprite = new Bitmap(@"assets\pokemons\aron.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 12;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 170 * level;
            this.Evolution = new Lairon();
        }
    }
}
