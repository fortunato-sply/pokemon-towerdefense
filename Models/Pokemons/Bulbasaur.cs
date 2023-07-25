using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Bulbasaur : Pokemon
    {
        public Bulbasaur(int level = 1)
        {
            this.Name = "Bulbasaur";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\bulbasaur.png");

            this.Level = level;

            this.minLevel = 1;
            this.SelectedAttack = new RazorLeaf();
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

            this.Evolution = new Ivysaur();
        }
    }
}
