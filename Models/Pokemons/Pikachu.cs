using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Pikachu : Pokemon
    {
        public Pikachu(int level = 12)
        {
            this.Name = "Pikachu";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\pikachu.png");

            this.Level = level;

            this.Type = Type.GetInstance("Electric");
            this.Tier = 2;

            this.minLevel = 12;
            this.SelectedAttack = new ThunderVolt();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += 3 * level;
            this.XpDrop = 60;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }

            this.Evolution = new Raichu();
        }
    }
}
