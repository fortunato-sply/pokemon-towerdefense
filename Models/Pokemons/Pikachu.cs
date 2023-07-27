using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Pikachu : Pokemon
    {
        public Pikachu(int level = 1)
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
            this.ActualLife = Life;
            this.XpDrop = 17 + (8 * level);
            this.XpEvolve = 200 * level;
            this.Evolution = new Raichu();
        }
    }
}
