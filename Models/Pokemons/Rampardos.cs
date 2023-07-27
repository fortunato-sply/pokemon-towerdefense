using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Rampardos : Pokemon
    {
        public Rampardos(int level = 15)
        {
            this.Name = "Rampardos";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\rampardos.png");

            this.Level = level;

            this.Type = Type.GetInstance("Rock");
            this.Tier = 3;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 2 * Level;
            this.Life += 3 * level;
            this.ActualLife = Life;
            this.XpDrop = 25 + (12 * level);
            this.XpEvolve = 300 * level;
        }
    }
}
