using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class Charizard : Pokemon
    {
        public Charizard(int level = 18)
        {
            this.Name = "Charizard";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\charizard.png");

            this.Level = level;

            this.minLevel = 18;
            this.SelectedAttack = new Attack();
            this.Attacks = new List<Attack>();
        }
    }
}
