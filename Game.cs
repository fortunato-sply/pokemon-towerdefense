using System;
using pokemon_towerdefense.Models;
using System.Drawing;
using System.Windows.Forms;
using pokemon_towerdefense.CustomizedControls;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Linq;
using System.Media;

namespace pokemon_towerdefense
{
    public partial class Game : Form
    {
        Phase phase = new Phase();
        Pokeball pokeball = new Pokeball();
        Timer timer = new Timer();

        int grabbed = -1;

        Graphics g = null;

        bool isPaused = false;
        bool showInventory = false;
            
        List<Placement> placements = new List<Placement>();

        List<Pokemon> selfPokemons = new List<Pokemon>();
        List<Pokemon> InventoryPokemons = new List<Pokemon>();

        public Game()
        {
            InitializeComponent();
            PlayBattleTheme();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            PbScreen.MouseDown += Form1_MouseDown;
            PbScreen.MouseUp += Form1_MouseUp;

            PbScreen.MouseClick += Placement_MouseClick;
            PbScreen.MouseClick += BackButtonClick;
            PbScreen.MouseClick += InventoryButtonClick;

            var newBmp = new Bitmap(PbScreen.Width, PbScreen.Height);

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
            Pokemon zard = new Charizard();
            zard.isWild = false;
            Pokemon gengar = new Gengar();
            gengar.isWild = false;
            Pokemon squirtle = new Squirtle();
            squirtle.isWild = false;
            Pokemon shZard = new ShinyCharizard();
            shZard.isWild = false;
            Pokemon gyarados = new Gyarados();
            gyarados.isWild = false;
            this.selfPokemons.Add(zard);
            this.selfPokemons.Add(gyarados);
            this.selfPokemons.Add(gengar);
            this.selfPokemons.Add(squirtle);
            this.selfPokemons.Add(shZard);

            this.InventoryPokemons.Add(zard);
            this.InventoryPokemons.Add(gengar);
            for(int i = 0; i < 8; i++)
            {
                this.InventoryPokemons.Add(gengar);
            }

            Color blueOpacity = Color.FromArgb(150, Color.Blue);
            Brush brushBlueOpacity = new SolidBrush(blueOpacity);

            Color blackOpacity = Color.FromArgb(150, Color.Black);
            Brush brushBlackOpacity = new SolidBrush(blackOpacity);

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
                else if(showInventory)
                {
                    g.Clear(blackOpacity);
                    g.DrawString("INVENTORY", new Font("Press Start 2P", 16, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width / 2 - 120, PbScreen.Height / 3 - 250));

                    for(int j = 1; j < 4; j++)
                    {
                        for(int i = 0; i < 8; i++)
                        {
                            RoundedRect rect = new RoundedRect();
                            var path = rect.setRect(300 + (i * 160), 170 * j, 150, 150);
                            g.FillPath(brushBlackOpacity, path);
                        }
                    }

                    int contX = 330;
                    int contY = 210;
                    for(int i = 1; i < InventoryPokemons.Count+1; i++)
                    {
                        g.DrawString(InventoryPokemons[i-1].Name, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.White, new PointF(contX - 15 + (160 * i), contY - 25 + (180 * (8 % (i + 1)))));
                        g.DrawString("Lv " + InventoryPokemons[i-1].Level, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.Red, new PointF(contX + 60 + (160 * i), contY - 10 + (180 * (8 % (i + 1)))));
                        Rectangle destRect = new Rectangle(contX + (160 * ((i) % 8)), contY + (180 * ((i) / 8)), 90, 100);
                        InventoryPokemons[i-1].StaticAnimate(g, destRect);
                    }

                    // BACK INVENTORY BUTTON
                    RoundedRect roundedRect = new RoundedRect();
                    GraphicsPath invRect = roundedRect.setRect(1540, 977, 179, 60);
                    g.FillPath(Brushes.Red, invRect);
                    g.DrawString("Voltar", new Font("Press Start 2P", 12, FontStyle.Regular), Brushes.White, new PointF(1580, 998));

                    // POKE CONTAINERS
                    for (int i = 0; i < 6; i++)
                    {
                        RoundedRect rect = new RoundedRect();
                        var path = rect.setRect(100 + (i * 215), 780);


                        if (this.selfPokemons.Count > i)
                        {
                            var pokemon = this.selfPokemons[i];
                            var name = pokemon.Name;
                            var level = pokemon.Level;
                            var sprite = pokemon.Sprite;
                            var xp = pokemon.Xp;

                            if (pokemon.IsPlaced)
                                g.FillPath(brushBlueOpacity, path);
                            else
                                g.FillPath(brushBlackOpacity, path);

                            g.DrawString(name, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.White, new PointF(110 + (i * 215), 790));
                            g.DrawString("Lv " + level, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.Red, new PointF(220 + (i * 215), 810));
                            DrawXpBar(xp, 110 + (i * 215), 970);

                            if (i == grabbed)
                            {
                                Rectangle destRect = new Rectangle(Cursor.Position.X - 50, Cursor.Position.Y - 50, 100, 100);
                                g.DrawImage(sprite, destRect, 3, 10, 59, 55, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                Rectangle destRect = new Rectangle(135 + (i * 215), 835, 130, 120);
                                g.DrawImage(sprite, destRect, 3, 6, 59, 55, GraphicsUnit.Pixel);
                            }
                        }
                        else
                        {
                            g.FillPath(brushBlackOpacity, path);
                        }
                    }
                }
                else
                {
                    // BACKGROUND
                    g.Clear(Color.Transparent);

                    g.DrawImage(
                        photo,
                        -1,
                        -1
                    );

                    // PLACEMENTS
                    this.placements.ForEach(p => {
                        g.DrawRectangle(Pens.Black, p.rect);

                        if (p.hasPokemon)
                        {
                            var imgRect = new Rectangle(p.rect.X, p.rect.Y, 50, 55);
                            p.Pokemon.Animate(g);

                            p.Pokemon.SpeedImage++;
                            if (p.Pokemon.SpeedImage >= 10)
                            {
                                p.Pokemon.ActualImage += 1;
                                p.Pokemon.SpeedImage = 0;
                            }
                        }
                    });

                    // POKEBALL
                    if (pokeball.isDragging)
                    {
                        var isOver = false;
                        var WildPokemons = phase.GetWilds();
                        WildPokemons.ForEach(wild =>
                        {
                            if (Math.Abs(Cursor.Position.X - wild.Location.Value.X) < 40 && Math.Abs(Cursor.Position.Y - wild.Location.Value.Y) < 40 && wild.Life < 25)
                            {
                                isOver = true;
                                g.DrawImage(pokeball.BmpOpened, 
                                    Cursor.Position.X - 100,
                                    Cursor.Position.Y - 180,
                                    200, 360);
                            }
                        });

                        phase.DrawWildPokemons(g);

                        if (!isOver) {
                            g.DrawImage(
                                pokeball.BmpClosed,
                                Cursor.Position.X - (pokeball.Width / 2),
                                Cursor.Position.Y - (pokeball.Height / 2)
                            );
                        }
                    }
                    else
                    {
                        //WILD POKEMONS
                        phase.RunPhase(g);
                        phase.runTurrets(g, this.placements);

                        g.DrawImage(
                            pokeball.BmpClosed,
                            1524,
                            767
                        );
                    }

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
                                g.FillPath(brushBlueOpacity, path);
                            else
                                g.FillPath(brushBlackOpacity, path);

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
                            g.FillPath(brushBlackOpacity, path);
                        }
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
                if(showInventory)
                {
                    if (ev.KeyCode == Keys.Escape)
                        this.showInventory = false;
                }
                else
                {
                    if (ev.KeyCode == Keys.Escape)
                    {
                        this.isPaused = !this.isPaused;
                    }
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

        private void InventoryButtonClick(object sender, EventArgs e)
        {
            if (Cursor.Position.X >= 1540 && Cursor.Position.X < 1540 + 179
                && Cursor.Position.Y >= 977 && Cursor.Position.Y <= 977 + 60)
            {
                this.showInventory = !this.showInventory; 
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
            if (pokeball.isDragging)
            {
                var WildPokemons = phase.GetWilds();
                WildPokemons.ForEach(wild =>
                {
                    if (Math.Abs(Cursor.Position.X - wild.Location.Value.X) < 40 && Math.Abs(Cursor.Position.Y - wild.Location.Value.Y) < 40 && wild.Life < 25)
                    {
                        wild.isWild = false;
                        wild.IsAlive = false;
                        selfPokemons.Add(wild);
                    }
                });
                pokeball.isDragging = false;
            }

            if (grabbed != -1) {
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
        private void PlayBattleTheme()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"..\..\assets\Battle_Theme.wav");
            simpleSound.Play();
        }
    }
}
