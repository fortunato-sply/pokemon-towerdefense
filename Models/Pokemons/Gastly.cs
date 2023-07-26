using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Gastly : Pokemon
    {
        public Gastly(int level = 1)
        {
            this.Name = "Gastly";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\gastly.png");

            this.Level = level;

            this.Type = Type.GetInstance("Ghost");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new ShadowBall();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 2 * Level;
            this.Life += 2 * level;
            this.ActualLife = Life;
            this.XpDrop = 10 * level;
            this.XpEvolve = 170 * level;
            this.Evolution = new Haunter();
        }
    }
}
