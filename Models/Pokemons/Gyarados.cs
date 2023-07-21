using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class Gyarados : Pokemon
    {
        public Gyarados(int level = 15)
        {
            this.Name = "Gyarados";
            this.Sprite = new Bitmap(@"..\..\assets\pokemons\gyarados.png");

            this.Level = level;

            this.minLevel = 15;
            this.SelectedAttack = new Bite();
            this.Attacks = new List<Attack>();
            this.Speed = 6;
        }
    }
}