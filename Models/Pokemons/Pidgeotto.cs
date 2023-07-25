using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Pidgeotto : Pokemon
    {
        public Pidgeotto(int level = 7)
        {
            this.Name = "Pidgeotto";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\pidgeotto.png");

            this.Level = level;

            this.Type = Type.GetInstance("Flying");
            this.Tier = 2;

            this.minLevel = 7;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.XpDrop = 60;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }

            this.Evolution = new Pidgeot();
        }
    }
}
