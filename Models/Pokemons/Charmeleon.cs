using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Charmeleon : Pokemon
    {
        public Charmeleon(int level = 7)
        {
            this.Name = "Charmeleon";
            this.Sprite = new Bitmap(@"assets\pokemons\charmeleon.png");

            this.Level = level;

            this.Type = Type.GetInstance("Fire");
            this.Tier = 2;

            this.minLevel = 7;
            this.SelectedAttack = new Ember();
            this.Attacks = new List<Attack>();
            this.Speed = 5;
            this.Power += 2 * Level;
            this.Life += Convert.ToInt16(2 * Tier * Level);;
            this.ActualLife = Life;
            this.XpDrop = 20 + (10 * level);
            this.XpEvolve = 240 * level;
            this.Evolution = new Charizard();
        }
    }
}
