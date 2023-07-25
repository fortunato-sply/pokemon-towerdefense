﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace pokemon_towerdefense.Models
{
    public class Rattata : Pokemon
    {
        public Rattata(int level = 1)
        {
            this.Name = "Rattata";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\rattata.png");

            this.Level = level;

            this.Type = Type.GetInstance("Normal");
            this.Tier = 1;

            this.minLevel = 1;
            this.SelectedAttack = new Bite();
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

            this.Evolution = null;
        }
    }
}
