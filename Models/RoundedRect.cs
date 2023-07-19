using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class RoundedRect
    {
        public GraphicsPath path { get; set; } = new GraphicsPath();

        Rectangle rectangle;

        int cornerRadius = 20;

        public RoundedRect()
        {

        }

        public GraphicsPath setRect(int x, int y, int width = 200, int height = 200)
        {
            this.rectangle = new Rectangle(x, y, width, height);

            path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90); // Canto superior esquerdo
            path.AddArc(rectangle.Right - cornerRadius, rectangle.Y, cornerRadius, cornerRadius, 270, 90); // Canto superior direito
            path.AddArc(rectangle.Right - cornerRadius, rectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Canto inferior direito
            path.AddArc(rectangle.X, rectangle.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Canto inferior esquerdo
            path.CloseFigure(); // Fecha o caminho

            return path;
        }

        
    }
}
