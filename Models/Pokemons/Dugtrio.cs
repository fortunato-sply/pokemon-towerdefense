using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Dugtrio : Pokemon
    {
        public Dugtrio(int level = 12)
        {
            this.Name = "Dugtrio";
            this.Sprite = new Bitmap(@"assets\pokemons\Dugtrio.png");

            this.Level = level;

            this.Type = Type.GetInstance("Ground");
            this.Tier = 3;

            this.minLevel = 12;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 20 * level;
            this.XpEvolve = 250 * level;
        }
    }
}
