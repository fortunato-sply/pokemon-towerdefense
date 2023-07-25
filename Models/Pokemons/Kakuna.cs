﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Kakuna : Pokemon
    {
        public Kakuna(int level = 5)
        {
            this.Name = "Kakuna";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\kakuna.png");

            this.Level = level;

            this.Type = Type.GetInstance("Bug");
            this.Tier = 1;

            this.minLevel = 5;
            this.SelectedAttack = new Meelee();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
            this.Power += 1 * Level;
            this.Life += 2 * level;
            this.XpDrop = 60;
            ActualLife = Life;
            for (int i = 0; i < Level; i++)
            {
                XpDrop += Convert.ToInt16(XpDrop * 0.15);
                XpEvolve += Convert.ToInt16(XpEvolve * 0.3);
            }

            this.Evolution = new Beedrill();
        }
    }
}
