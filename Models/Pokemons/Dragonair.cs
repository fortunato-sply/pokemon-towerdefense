using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Dragonair : Pokemon
    {
        public Dragonair(int level = 12)
        {
            this.Name = "Dragonair";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\dragonair.png");

            this.Level = level;

            this.Type = Type.GetInstance("Dragon");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new IcyWind();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += 3 * level;
            this.XpDrop = 60;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }

            this.Evolution = new Dragonite();
        }
    }
}
