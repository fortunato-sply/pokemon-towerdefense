using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Scizor : Pokemon
    {
        public Scizor(int level = 18)
        {
            this.Name = "Scizor";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\scizor.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 7;
            this.Power += 4 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
