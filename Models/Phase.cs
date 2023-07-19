using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    internal class Phase
    {
        public int Id { get; set; }
        public List<Wave> Waves { get; set; }
        public bool End { get; set; } = false;
        public List<Point> PhasePath { get; set; }
        

    }
}
