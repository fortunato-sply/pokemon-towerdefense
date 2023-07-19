using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon_towerdefense
{
    public partial class Pause : Form
    {
        Timer timer;
        Game game;
        public Pause(Timer timer, Game game)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            this.timer = timer;
            this.game = game;
        }

        private void Pause_Load(object sender, EventArgs e)
        {
            container.Size = new Size(this.Width, this.Height);
            container.Location = new Point(-1, -1);
            options.Location = new Point(this.Width / 2 - (options.Width / 2), this.Height / 2 - (options.Height / 2));
            label1.Location = new Point(this.Width / 2 - (label1.Width / 2), this.Height / 3 - 100);

            this.KeyPreview = true;
            this.KeyDown += (o, ev) =>
            {
                if (ev.KeyCode == Keys.Escape)
                {
                    resumeGame();
                }
            };
        }

        private void resumeGame()
        {
            game.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            resumeGame();
        }
    }
}
