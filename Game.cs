using System;
using pokemon_towerdefense.Models;
using System.Drawing;
using System.Windows.Forms;
using pokemon_towerdefense.CustomizedControls;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Reflection.Emit;

namespace pokemon_towerdefense
{
    public partial class Game : Form
    {
        Pokeball pokeball = new Pokeball();
        Timer timer = new Timer();

        int grabbed = -1;

        Graphics g = null;

        bool isPaused = false;

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
            PbScreen.MouseClick += BackButtonClick;

            var newBmp = new Bitmap(PbScreen.Width, PbScreen.Height);

            g = Graphics.FromImage(newBmp);
            PbScreen.Image = newBmp;

            int speedImage = 0;
            int actualImage = 0;

            Phase phase = new Phase();
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
            this.selfPokemons.Add(new ShinyCharizard());

            timer.Tick += delegate
            {
                if(isPaused)
                {
                    g.Clear(Color.Black);
                    g.DrawString("GAME PAUSED", new Font("Press Start 2P", 16, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width/2 - 120, PbScreen.Height / 3 - 100));

                    RoundedRect roundedRect = new RoundedRect();
                    var backBtn = roundedRect.setRect(PbScreen.Width / 2 - 140, PbScreen.Height / 2 - 150, 280, 80);
                    g.FillPath(Brushes.Red, backBtn);

                    g.DrawString("Voltar", new Font("Press Start 2P", 18, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width / 2 - 70, PbScreen.Height / 2 - 120));
                    
                    roundedRect = new RoundedRect();
                    var exitBtn = roundedRect.setRect(PbScreen.Width / 2 - 140, PbScreen.Height / 2 - 50, 280, 80);
                    g.FillPath(Brushes.Red, exitBtn);
                    g.DrawString("Sair", new Font("Press Start 2P", 18, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width / 2 - 50, PbScreen.Height / 2 - 20));
                }
                else
                {
                    // BACKGROUND
                    g.Clear(Color.Transparent);

                    g.DrawImage(
                        photo,
                        0,
                        0
                    );

                    // PLACEMENTS
                    this.placements.ForEach(p => {
                        g.DrawRectangle(Pens.Black, p.rect);

                        if (p.hasPokemon)
                        {
                            var imgRect = new Rectangle(p.rect.X, p.rect.Y, 50, 55);
                            var sprites = p.Pokemon.Animate();

                            g.DrawImage(sprites, imgRect, 3 + ((actualImage % 4) * 64), 10, 59, 55, GraphicsUnit.Pixel);

                            speedImage++;
                            if (speedImage >= 10)
                            {
                                actualImage += 1;
                                speedImage = 0;
                            }
                        }
                    });

                    // POKE CONTAINERS
                    for (int i = 0; i < 6; i++)
                    {
                        RoundedRect rect = new RoundedRect();
                        var path = rect.setRect(100 + (i * 215), 730);


                        if (this.selfPokemons.Count > i)
                        {
                            var pokemon = this.selfPokemons[i];
                            var name = pokemon.Name;
                            var level = pokemon.Level;
                            var sprite = pokemon.Sprite;
                            var xp = pokemon.Xp;

                            if (pokemon.IsPlaced)
                                g.FillPath(Brushes.Blue, path);
                            else
                                g.FillPath(Brushes.Black, path);

                            g.DrawString(name, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.White, new PointF(110 + (i * 215), 740));
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
                                g.DrawImage(sprite, destRect, 3, 6, 59, 55, GraphicsUnit.Pixel);
                            }
                        }
                        else
                        {
                            g.FillPath(Brushes.Black, path);
                        }


                    }

                //WILD POKEMONS
                phase.RunPhase(g);

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

                    // INVENTORY BUTTON
                    RoundedRect roundedRect = new RoundedRect();
                    GraphicsPath invRect = roundedRect.setRect(1540, 977, 179, 60);
                    g.FillPath(Brushes.Red, invRect);
                    g.DrawString("Inventário", new Font("Press Start 2P", 12, FontStyle.Regular), Brushes.White, new PointF(1548, 998));

                    // SPEED CONTROL
                    roundedRect = new RoundedRect();
                    var background = roundedRect.setRect(12, 986, 526, 63);
                    g.FillPath(Brushes.Black, background);
                    g.DrawString("Speed", new Font("Press Start 2P", 24F, FontStyle.Regular), Brushes.White, new PointF(17, 1000));

                    for (int i = 0; i < 4; i++)
                    {
                        roundedRect = new RoundedRect();
                        var rect = roundedRect.setRect(208 + (88 * i), 987, 65, 60);
                        g.FillPath(Brushes.Red, rect);
                    }

                    for (int i = 0, n = 0; i < 4; i++, n+= 2)
                    {
                        var text = "";
                        if (n == 0)
                            text = "1X";
                        else
                            text = $"{n}X";

                        g.DrawString(text, new Font("Press Start 2P", 14F, FontStyle.Regular), Brushes.White, new PointF(215 + (90 * i), 1008));
                    }
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
                    this.isPaused = !this.isPaused;
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

        private void BackButtonClick(object sender, MouseEventArgs e)
        {
            if(isPaused)
            {
                RoundedRect roundedRect = new RoundedRect();
                roundedRect.setRect(PbScreen.Width / 2 - 140, PbScreen.Height / 2 - 150, 280, 80);

                if (roundedRect.isHandOn())
                {
                    isPaused = false;
                };

                roundedRect = new RoundedRect();
                roundedRect.setRect(PbScreen.Width / 2 - 140, PbScreen.Height / 2 - 50, 280, 80);

                if(roundedRect.isHandOn())
                {
                    Application.Exit();
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

        private ImageAttributes GrayImage()
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
