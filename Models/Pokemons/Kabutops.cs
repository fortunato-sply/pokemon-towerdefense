using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Kabutops : Pokemon
    {
        public Kabutops(int level = 18)
        {
            this.Name = "Kabutops";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\kabutops.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 20 * level;
            this.XpEvolve = 280 * level;
        }
    }
}
