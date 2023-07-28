using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Ludicolo : Pokemon
    {
        public Ludicolo(int level = 18)
        {
            this.Name = "Ludicolo";
            this.Sprite = new Bitmap(@"assets\pokemons\ludicolo.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 3 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
        }
    }
}
