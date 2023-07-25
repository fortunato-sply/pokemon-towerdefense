using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Gengar : Pokemon
    {
        public Gengar(int level = 18)
        {
            this.Name = "Gengar";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\gengar.png");

            this.Level = level;

            this.Type = Type.GetInstance("Ghost");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new ShadowBall();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 3 * Level;
            this.Life += 2 * level;
            this.XpDrop = 50;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }
        }
    }
}
