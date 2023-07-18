using System.Drawing;

namespace pokemon_towerdefense.Models
{
    internal class Pokeball
    {
        public Point Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap bmp = new Bitmap(Image.FromFile(@"C:\Users\disrct\Desktop\pokemon-towerdefense\pokemon-towerdefense\assets\closedPokeball.png"), 200, 200);
        public bool isDragging { get; set; } = false;

        public Pokeball() {
            Location = new Point(1524, 767);
            Width= 200;
            Height= 200;
        }


    }
}
