using System;
using pokemon_towerdefense.Models;
using System.Drawing;
using System.Windows.Forms;
using pokemon_towerdefense.CustomizedControls;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace pokemon_towerdefense
{
    public partial class Game : Form
    {
        Pokeball pokeball = new Pokeball();
        Timer timer = new Timer();

        int grabbed = -1;

        Graphics g = null;

        List<Placement> placements = new List<Placement>();

        List<Pokemon> selfPokemons = new List<Pokemon>();

        public Game()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            PbScreen.MouseDown += Form1_MouseDown;
            PbScreen.MouseUp += Form1_MouseUp;

            PbScreen.MouseClick += Placement_MouseClick;

            var newBmp = new Bitmap(1920, 1080);

            g = Graphics.FromImage(newBmp);
            PbScreen.Image = newBmp;

            Pen pen = new Pen(Color.Black);
            var photo = new Bitmap(@"..\..\assets\cenario.jpg");

            int placementWidth = 50, placementHeight = 55;
            this.placements.Add(new Placement(new Rectangle(724, 455, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(854, 455, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(542, 647, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(724, 345, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(854, 647, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(724, 647, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(724, 227, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(1037, 455, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(1167, 647, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(1037, 647, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(1347, 455, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(1414, 773, placementWidth, placementHeight)));
            this.placements.Add(new Placement(new Rectangle(1414, 925, placementWidth, placementHeight)));

            // TESTE ADICIONANDO POKEMONS
            this.selfPokemons.Add(new Charizard());
            this.selfPokemons.Add(new Gyarados());
            this.selfPokemons.Add(new Gengar());
            this.selfPokemons.Add(new Squirtle());

            timer.Tick += delegate
            {
                // BACKGROUND
                g.Clear(Color.Transparent);

                g.DrawImage(
                    photo,
                    0,
                    0
                );

                this.placements.ForEach(p => {
                    g.DrawRectangle(Pens.Black, p.rect);

                    if(p.hasPokemon)
                    {
                        var imgRect = new Rectangle(p.rect.X, p.rect.Y, 50, 55);
                        g.DrawImage(p.Pokemon.Sprite, imgRect, 3, 10, 59, 55, GraphicsUnit.Pixel);
                    }
                });


                for (int i = 0; i < 6; i++)
                {
                    RoundedRect rect = new RoundedRect();
                    var path = rect.setRect(100 + (i * 215), 750);
                    g.FillPath(Brushes.Black, path);

                    if(this.selfPokemons.Count > i)
                    {
                        var pokemon = this.selfPokemons[i];
                        var name = pokemon.Name;
                        var level = pokemon.Level;
                        var sprite = pokemon.Sprite;
                        var xp = pokemon.Xp;

                        g.DrawString(name, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.White, new PointF(110 + (i * 215), 760));
                        g.DrawString("Lv " + level, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.Red, new PointF(220 + (i * 215), 760));
                        DrawXpBar(xp, 110 + (i * 215), 920);

                        if (i == grabbed)
                        {
                            Rectangle destRect = new Rectangle(Cursor.Position.X - 50, Cursor.Position.Y - 50, 100, 100);
                            g.DrawImage(sprite, destRect, 3, 10, 59, 55, GraphicsUnit.Pixel);
                        }
                        else
                        {
                            Rectangle destRect = new Rectangle(135 + (i * 215), 785, 130, 120);
                            if(!pokemon.IsPlaced)
                            {
                                g.DrawImage(sprite, destRect, 3, 6, 59, 55, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(sprite, destRect, 3, 6, 59, 55, GraphicsUnit.Pixel, GetGrayImage());
                            }
                        }
                    }


                }

                // POKEBALL
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


                PbScreen.Refresh();
            };
        }

        private void DrawXpBar(int xp, int x, int y)
        {
            int sizeXp = 140;
            Rectangle backRect = new Rectangle(x + 20, y, sizeXp, 20);
            Rectangle frontRect = new Rectangle(x + 21, y+1, Convert.ToInt16(xp * (Convert.ToDecimal(sizeXp - 2) / 100)), 18);
            g.FillRectangle(Brushes.White, backRect);
            g.FillRectangle(Brushes.Blue, frontRect);
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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= pokeball.Location.X && e.Location.X < (pokeball.Location.X + pokeball.Width) &&
                e.Location.Y >= pokeball.Location.Y && e.Location.Y < (pokeball.Location.Y + pokeball.Height))
            {
                pokeball.isDragging = true;
            }

            for (int i = 0; i < 6; i++)
            {
                if (this.selfPokemons.Count > i)
                {
                    if (!this.selfPokemons[i].IsPlaced)
                    {
                        if (e.Location.X >= 125 + (i * 215) && e.Location.X < 275 + (i * 215) &&
                        e.Location.Y >= 780 && e.Location.Y < 930)
                        {
                            grabbed = i;
                        }
                    }
                }
            }
        }

        private void Placement_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                placements.ForEach(p =>
                {
                    if (Cursor.Position.X >= p.rect.X && Cursor.Position.X < p.rect.X + p.rect.Width &&
                        Cursor.Position.Y >= p.rect.Y && Cursor.Position.Y < p.rect.Y + p.rect.Height)
                    {
                        if(p.hasPokemon)
                            p.RemovePokemon();
                        
                    }
                });
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pokeball.isDragging = false;
            if(grabbed != -1) {
               placements.ForEach(p =>
                {
                    if (Cursor.Position.X >= p.rect.X && Cursor.Position.X < p.rect.X + p.rect.Width &&
                        Cursor.Position.Y >= p.rect.Y && Cursor.Position.Y < p.rect.Y + p.rect.Height)
                    {
                        p.AddPokemon(this.selfPokemons[grabbed]);
                    }
                });

                grabbed = -1;
            }
        }

        private ImageAttributes GetGrayImage()
        {
            ImageAttributes imageAttr = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
                });

            imageAttr.SetColorMatrix(colorMatrix);
            return imageAttr;
        }
    }
}
