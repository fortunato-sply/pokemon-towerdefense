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
    public partial class Inventory : Form
    {
        Game game;
        public Inventory(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Carregu");
        }
    }
}
