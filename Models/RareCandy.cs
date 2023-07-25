
using System.Drawing;

namespace pokemon_towerdefense
{
    internal class RareCandy
    {
        public Point Position { get; set; }
        public bool IsStealed { get; set; }
        public Bitmap Sprite = new Bitmap(Image.FromFile(@"..\..\assets\rare_candy.png"), 80, 80);

        public RareCandy(Point position)
        {
            Position = position;
            IsStealed = false;
        }
    }
}
