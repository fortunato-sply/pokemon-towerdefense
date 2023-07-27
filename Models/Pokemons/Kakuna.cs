using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Kakuna : Pokemon
    {
        public Kakuna(int level = 5)
        {
            this.Name = "Kakuna";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\kakuna.png");

            this.Level = level;

            this.Type = Type.GetInstance("Bug");
            this.Tier = 1;

            this.minLevel = 5;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Defense = 50;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
            this.Evolution = new Beedrill();
        }
    }
}
