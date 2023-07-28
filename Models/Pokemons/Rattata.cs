using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Rattata : Pokemon
    {
        public Rattata(int level = 1)
        {
            this.Name = "Rattata";
            this.Sprite = new Bitmap(@"assets\pokemons\rattata.png");

            this.Level = level;

            this.Type = Type.GetInstance("Normal");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Bite();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 10 + (5 * level);
            this.XpEvolve = 220 * level;
            this.Evolution = null;
        }
    }
}
