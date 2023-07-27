using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class AlolaNinetales : Pokemon
    {
        public AlolaNinetales(int level = 14)
        {
            this.Name = "Ninetales";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\alola-ninetales.png");

            this.Level = level;

            this.Type = Type.GetInstance("Ice");
            this.Tier = 4;

            this.minLevel = 14;
            this.SelectedAttack = new IcyWind();
            this.Attacks = new List<Attack>();
            this.Speed = 10;
            this.Power += 3 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 34 + (17 * level);
            this.XpEvolve = 340 * level;
        }
    }
}
