using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Pidgeot : Pokemon
    {
        public Pidgeot(int level = 18)
        {
            this.Name = "Pidgeot";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\pidgeot.png");

            this.Level = level;

            this.Type = Type.GetInstance("Flying");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 8;
            this.Power += 3 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 30 * level;
            this.XpEvolve = 320 * level;
        }
    }
}
