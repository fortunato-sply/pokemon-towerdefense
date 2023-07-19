using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public abstract class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Point? Location { get; set; } = null;
        public int Xp { get; protected set; } = 0;
        protected int minLevel { get; set; }
        public Attack SelectedAttack {  get; protected set; }
        public List<Attack> Attacks { get; protected set; } = new List<Attack>();
        public List<Pokemon> Evolutions = null;
        public Bitmap Sprite = null;
        public bool IsPlaced = false;

        public void LevelUp()
        {

        }

        public void GiveDamage()
        {

        }
    }
}
