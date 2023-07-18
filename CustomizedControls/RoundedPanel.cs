using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon_towerdefense.CustomizedControls
{
    public class RoundedPanel : Panel
    {
        private int radius = 10;

        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                Invalidate(); // Invalidate the control to trigger repainting
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                RectangleF rect = new RectangleF(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                path.AddArc(rect.X, rect.Y, Radius * 2, Radius * 2, 180, 90);
                path.AddArc(rect.Width - (Radius * 2), rect.Y, Radius * 2, Radius * 2, 270, 90);
                path.AddArc(rect.Width - (Radius * 2), rect.Height - (Radius * 2), Radius * 2, Radius * 2, 0, 90);
                path.AddArc(rect.X, rect.Height - (Radius * 2), Radius * 2, Radius * 2, 90, 90);
                path.CloseFigure();/**/

                Region = new Region(path);
            }
        }
    }
}
