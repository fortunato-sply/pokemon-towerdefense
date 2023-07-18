using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pokemon_towerdefense.CustomizedControls;

namespace pokemon_towerdefense
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            
        }

        private void speedPanel_Click(object sender, EventArgs e)
        {
            if (sender is RoundedPanel)
            {
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 19;
            timer.Tick += (s, ev) =>
            {
                
            };

            timer.Enabled= true;

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("oi");
        }
    }
}
