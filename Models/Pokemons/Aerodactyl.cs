using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Aerodactyl : Pokemon
    {
        public Aerodactyl(int level = 20)
        {
            this.Name = "Aerodactyl";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\aerodactyl.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 5;

            this.minLevel = 20;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 10;
            this.Power += 5 * Level;
            this.Life += 4 * level;
            this.ActualLife = Life;
            this.XpDrop = 30 + (15 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
