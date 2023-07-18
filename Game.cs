using System;
using pokemon_towerdefense.Models;
using System.Drawing;
using System.Windows.Forms;
using pokemon_towerdefense.CustomizedControls;

namespace pokemon_towerdefense
{
    public partial class Game : Form
    {
        Pokeball pokeball = new Pokeball();
        Timer timer = new Timer();

        public Game()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            Pokeball.MouseDown += Form1_MouseDown;
            Pokeball.MouseUp += Form1_MouseUp;
            
            var newBmp = new Bitmap(1920, 1080);

            Graphics g = Graphics.FromImage(newBmp);
            Pokeball.Image = newBmp;

            g.DrawImage(Image.FromFile(@"C:\Users\disrct\Desktop\pokemon-towerdefense\pokemon-towerdefense\assets\cenario.jpg"), 0, 0);
            g.DrawImage(pokeball.bmp, pokeball.Location.x, pokeball.Location.y);

            var photo = new Bitmap(@"C:\Users\disrct\Desktop\pokemon-towerdefense\pokemon-towerdefense\assets\cenario.jpg");
            timer.Tick += delegate
            {
                g.Clear(Color.White);

                g.DrawImage(
                    photo,
                    0,
                    0
                );

                if (pokeball.isDragging)
                {
                    g.DrawImage(
                        pokeball.bmp,
                        Cursor.Position.X - (pokeball.Width / 2),
                        Cursor.Position.Y - (pokeball.Height / 2)
                    );
                } 
                else
                {
                    g.DrawImage(
                        pokeball.bmp,
                        1524,
                        767
                    );
                }

                Pokeball.Refresh();
            };
        }

        private void speedPanel_Click(object sender, EventArgs e)
        {
            if (sender is RoundedPanel)
            {

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer.Interval = 2;
            timer.Enabled = true;
            timer.Start();

            this.KeyPreview = true;
            this.KeyDown += (o, ev) =>
            {
                if (ev.KeyCode == Keys.Escape)
                {
                    Form pauseForm = new Pause(timer, this);
                    this.Hide();
                    timer.Stop();
                    pauseForm.Show();
                }
            };

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= pokeball.Location.x && e.Location.X < (pokeball.Location.x + pokeball.Width) &&
                e.Location.Y >= pokeball.Location.y && e.Location.Y < (pokeball.Location.y + pokeball.Height))
            {
                pokeball.isDragging = true;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pokeball.isDragging = false;
        }
    }
}
