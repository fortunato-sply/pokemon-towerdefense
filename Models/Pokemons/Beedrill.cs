using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Beedrill : Pokemon
    {
        public Beedrill(int level = 12)
        {
            this.Name = "Beedrill";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\beedrill.png");

            this.Level = level;

            this.Type = Type.GetInstance("Bug");
            this.Tier = 2;

            this.minLevel = 12;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 1 * Level;
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
