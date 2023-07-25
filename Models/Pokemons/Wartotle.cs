using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Wartotle : Pokemon
    {
        public Wartotle(int level = 7)
        {
            this.Name = "Ivysaur";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\wartotle.png");

            this.Level = level;

            this.minLevel = 7;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.XpDrop = 60;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }

            this.Evolution = new Blastoise();
        }
    }
}
