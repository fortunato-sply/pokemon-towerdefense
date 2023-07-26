using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Haunter : Pokemon
    {
        public Haunter(int level = 7)
        {
            this.Name = "Haunter";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\haunter.png");

            this.Level = level;

            this.Type = Type.GetInstance("Ghost");
            this.Tier = 2;

            this.minLevel = 7;
            this.SelectedAttack = new ShadowBall();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 24 * level;
            this.XpEvolve = 250 * level;
            this.Evolution = new Gengar();
        }
    }
}
