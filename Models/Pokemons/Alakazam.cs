using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Alakazam : Pokemon
    {
        public Alakazam(int level = 15)
        {
            this.Name = "Alakazam";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\alakazam.png");

            this.Level = level;

            this.Type = Type.GetInstance("Psychic");
            this.Tier = 3;

            this.minLevel = 15;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 3 * Level;
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
