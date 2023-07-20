using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class Squirtle : Pokemon
    {
        public Squirtle(int level = 1)
        {
            this.Name = "Squirtle";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\squirtle.png");

            this.Level = level;

            this.minLevel = 1;
            this.SelectedAttack = new Flamethrower();
            this.Attacks = new List<Attack>();
            this.Speed = 3;
        }
    }
}
