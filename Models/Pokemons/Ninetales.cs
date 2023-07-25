using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Ninetales : Pokemon
    {
        public Ninetales(int level = 14)
        {
            this.Name = "Ninetales";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\ninetales.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 1;

            this.minLevel = 14;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 6;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.XpDrop = 60;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }
        }
    }
}
