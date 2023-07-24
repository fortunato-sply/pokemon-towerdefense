using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Squirtle : Pokemon
    {
        public Squirtle(int level = 1)
        {
            this.Name = "Squirtle";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\squirtle.png");

            this.Level = level;

            this.minLevel = 1;
            this.SelectedAttack = new Flamethrower();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += 2 * level;
            this.XpDrop = 30;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }
        }
    }
}
