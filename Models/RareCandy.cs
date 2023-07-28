
using System.Drawing;
using System.Windows.Forms;

namespace pokemon_towerdefense.Models
{
    public class RareCandy
    {
        public Point Position { get; set; } = new Point();
        public bool IsStealed { get; set; }
        public Bitmap Sprite = new Bitmap(Image.FromFile(@"assets\rare_candy.png"), 30, 30);

        public RareCandy(Point position)
        {
            Position = position;
            IsStealed = false;
        }
    }
}
