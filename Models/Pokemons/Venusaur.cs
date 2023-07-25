using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Venusaur : Pokemon
    {
        public Venusaur(int level = 18)
        {
            this.Name = "Venusaur";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\venusaur.png");

            this.Level = level;

            this.minLevel = 18;
            this.SelectedAttack = new RazorLeaf();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += 4 * level;
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
