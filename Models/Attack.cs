using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class Attack
    {
        public int Damage { get; set; }
        public Bitmap[] Sprites { get; set; }
        public float Cooldown { get; set; }
        public Pokemon Target { get; set; }
    }
}
