using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Blastoise : Pokemon
    {
        public Blastoise(int level = 18)
        {
            this.Name = "Blastoise";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\blastoise.png");

            this.Level = level;

            this.Type = Type.GetInstance("Water");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Bubbles();
            this.Attacks = new List<Attack>();
            this.Speed = 4;
            this.Power += 4 * Level;
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
