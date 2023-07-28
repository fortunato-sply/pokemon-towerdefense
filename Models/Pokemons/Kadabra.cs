using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Kadabra : Pokemon
    {
        public Kadabra(int level = 7)
        {
            this.Name = "Kadabra";
            this.Sprite = new Bitmap(@"assets\pokemons\kadabra.png");

            this.Level = level;

            this.Type = Type.GetInstance("Psychic");
            this.Tier = 2;

            this.minLevel = 7;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 22 + (11 * level);
            this.XpEvolve = 250 * level;
            this.Evolution = new Alakazam();
        }
    }
}
