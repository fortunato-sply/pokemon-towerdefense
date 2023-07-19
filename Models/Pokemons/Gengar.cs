using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class Gengar : Pokemon
    {
        public Gengar(int level = 18)
        {
            this.Name = "Gengar";
            this.Sprite = new Bitmap(@"C:\Users\disrct\Desktop\pokemon-towerdefense\pokemon-towerdefense\assets\pokemons\gengar.png");

            this.Level = level;

            this.minLevel = 18;
            this.SelectedAttack = new Attack();
            this.Attacks = new List<Attack>();
        }
    }
}
