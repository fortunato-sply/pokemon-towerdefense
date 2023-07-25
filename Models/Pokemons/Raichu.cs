using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Raichu : Pokemon
    {
        public Raichu(int level = 18)
        {
            this.Name = "Raichu";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\raichu.png");

            this.Level = level;

            this.Type = Type.GetInstance("Electric");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new ThunderVolt();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 4 * Level;
            this.Life += 3 * level;
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
