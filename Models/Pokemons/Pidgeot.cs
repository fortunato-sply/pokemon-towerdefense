using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Pidgeot : Pokemon
    {
        public Pidgeot(int level = 18)
        {
            this.Name = "Pidgeot";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\pidgeot.png");

            this.Level = level;

            this.Type = Type.GetInstance("Flying");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
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
        }
    }
}
