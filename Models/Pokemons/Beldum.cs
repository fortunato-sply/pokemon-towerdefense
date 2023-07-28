using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Beldum : Pokemon
    {
        public Beldum(int level = 1)
        {
            this.Name = "Beldum";
            this.Sprite = new Bitmap(@"assets\pokemons\beldum.png");

            this.Level = level;

            this.Type = Type.GetInstance("Steel");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 2;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 18 + (9 * level);
            this.XpEvolve = 200 * level;
            this.Evolution = new Metang();
        }
    }
}
