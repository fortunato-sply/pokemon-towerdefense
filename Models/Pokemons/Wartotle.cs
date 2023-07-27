using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Wartotle : Pokemon
    {
        public Wartotle(int level = 7)
        {
            this.Name = "Wartotle";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\wartotle.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 2;

            this.minLevel = 7;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 20 + (10 * level);
            this.XpEvolve = 240 * level;
            this.Evolution = new Blastoise();
        }
    }
}
