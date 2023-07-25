﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Snorlax : Pokemon
    {
        public Snorlax(int level = 18)
        {
            this.Name = "Snorlax";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\snorlax.png");

            this.Level = level;

            this.Type = Type.GetInstance("Normal");
            this.Tier = 4;

            this.minLevel = 18;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 3 * Level;
            this.Life += 5 * level;
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