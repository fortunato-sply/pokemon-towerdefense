using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Arcanine : Pokemon
    {
        public Arcanine(int level = 18)
        {
            this.Name = "Arcanine";
            this.Sprite = new Bitmap(@"assets\pokemons\arcanine.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 4;

            this.minLevel = 18;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 8;
            this.Power += 4 * Level;
            this.Life += 4 * level;
            this.ActualLife = Life;
            this.XpDrop = 12 + (6 * level);
            this.XpEvolve = 180 * level;
        }
    }
}
