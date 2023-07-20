using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class ShinyCharizard : Pokemon
    {
        public ShinyCharizard(int level = 24)
        {
            this.Name = "S. Charizard";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\scharizard.png");

            this.Level = level;

            this.minLevel = 24;
            this.SelectedAttack = new Attack();
            this.Attacks = new List<Attack>();
        }
    }
}
