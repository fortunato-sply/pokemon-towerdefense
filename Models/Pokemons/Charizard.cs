using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Charizard : Pokemon
    {
        public Charizard(int level = 18)
        {
            this.Name = "Charizard";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\charizard.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 3;

            this.minLevel = 18;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 7;
            this.Power += 4 * Level;
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
