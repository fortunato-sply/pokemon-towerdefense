using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Gyarados : Pokemon
    {
        public Gyarados(int level = 15)
        {
            this.Name = "Gyarados";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\gyarados.png");

            this.Level = level;

            this.minLevel = 15;
            this.SelectedAttack = new Bite();
            this.Attacks = new List<Attack>();
            this.Speed = 6;
            this.Power += 4 * Level;
            this.Life += 3 * level;
            this.XpDrop = 55;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }
        }
    }
}