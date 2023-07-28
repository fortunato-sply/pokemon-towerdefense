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
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.AxHost;
using System.Security.Policy;
using System.IO;
using Microsoft.SqlServer.Server;

namespace pokemon_towerdefense
{
    public partial class Game : Form
    {
        #region Variables Field

        Pokeball pokeball = new Pokeball();
        
        // Instance of All Game Timer Form
        Timer timer = new Timer();

        
        Graphics g = null;

        // Controllers to Show Other Forms
        bool isPaused = false;
        bool showInventory = false;
        
        // Controller to Hover and Grabbed Status
        int grabbed = -1;
        int inventoryGrabbed = -1;
        int inventoryHover = -1;
        bool trashHover = false;

        // Lists of Pokemons
        // Self Pokemons = My Actual Pokémon Team
        // Inventory Pokemons = My Deposity of Pokémons
        List<Pokemon> selfPokemons = new List<Pokemon>();
        List<Pokemon> InventoryPokemons = new List<Pokemon>();

        // Phases of Game
        Phase phase1;
        Phase phase2;
        Phase phase3;
        Phase phase4;

        // List of Phases
        List<Phase> phases = new List<Phase>();

        // Var Phase Controllers
        bool nextWave = false;
        bool nextPhase = false;
        int actualPhase = 0;

        #endregion

        public Game()
        {
            #region Rectangles
            
            // Background to Simule Retry Button on Game Over
            RoundedRect BackRetryRect = new RoundedRect();
            BackRetryRect.setRect(PbScreen.Width / 2 - (PbScreen.Width / 20), PbScreen.Height / 2 + (PbScreen.Height / 20), PbScreen.Width / 10, PbScreen.Height / 18);

            // Retry Rectangle to get Size to Retry Text Button
            Rectangle RetryRectangle = new Rectangle(PbScreen.Width / 2 - (PbScreen.Width / 20), PbScreen.Height / 2 + (PbScreen.Height / 20), PbScreen.Width / 10, PbScreen.Height / 18);
            
            // BackGround to Simule Next Phase Button
            RoundedRect nextPhaseButton = null;

            // BackGround to Simule Inventory Button
            RoundedRect roundedRect = new RoundedRect();
            GraphicsPath InventoryRect = roundedRect.setRect(1540, 977, 179, 60);

            // BackGround to Speed Control Buttons Family
            roundedRect = new RoundedRect();
            var SpeedControlBackground = roundedRect.setRect(12, 986, 526, 63);

            // List to get Speed Control Small Buttons
            List<GraphicsPath> SpeedControlRectangles = new List<GraphicsPath>();

            for (int i = 0; i < 4; i++)
            {
                RoundedRect rndRect = new RoundedRect();
                SpeedControlRectangles.Add(rndRect.setRect(PbScreen.Width - (PbScreen.Width/90), PbScreen.Height - (PbScreen.Height/ 50), 65, 60));

            }

            #endregion

            #region List of Points (Phase Path)
            List<List<Point>> path1 = new List<List<Point>>();
            List<Point> path1_1 = new List<Point>();
            path1_1.Add(new Point(570, -100));
            path1_1.Add(new Point(570, 550));
            path1_1.Add(new Point(1330, 550));
            path1_1.Add(new Point(1330, 1000));

            path1.Add(path1_1);

            List<Point> path2_1 = new List<Point>();
            path2_1.Add(new Point(850, 1150));
            path2_1.Add(new Point(850, 680));
            path2_1.Add(new Point(550, 680));
            path2_1.Add(new Point(550, 340));
            path2_1.Add(new Point(1150, 340));
            path2_1.Add(new Point(1150, 680));
            path2_1.Add(new Point(1650, 680));

            List<Point> path2_2 = new List<Point>();
            path2_2.Add(new Point(-100, 680));
            path2_2.Add(new Point(550, 680));
            path2_2.Add(new Point(550, 340));
            path2_2.Add(new Point(1150, 340));
            path2_2.Add(new Point(1150, 680));
            path2_2.Add(new Point(1650, 680));

            List<List<Point>> path2 = new List<List<Point>>();
            path2.Add(path2_1);
            path2.Add(path2_2);

            List<Point> path3_1 = new List<Point>();
            path3_1.Add(new Point(430, -100));
            path3_1.Add(new Point(430, 400));
            path3_1.Add(new Point(1270, 400));
            path3_1.Add(new Point(1270, 830));
            path3_1.Add(new Point(1780, 830));
            path3_1.Add(new Point(1780, 250));

            List<Point> path3_2 = new List<Point>();
            path3_2.Add(new Point(1270, -100));
            path3_2.Add(new Point(1270, 830));
            path3_2.Add(new Point(1780, 830));
            path3_2.Add(new Point(1780, 250));

            List<List<Point>> path3 = new List<List<Point>>();
            path3.Add(path3_1);
            path3.Add(path3_2);

            List<Point> path4_1 = new List<Point>();
            path4_1.Add(new Point(50, -100));
            path4_1.Add(new Point(50, 320));
            path4_1.Add(new Point(740, 320));
            path4_1.Add(new Point(740, 50));

            List<Point> path4_2 = new List<Point>();
            path4_2.Add(new Point(1820, -100));
            path4_2.Add(new Point(1820, 320));
            path4_2.Add(new Point(1150, 320));
            path4_2.Add(new Point(1150, 50));

            List<Point> path4_3 = new List<Point>();
            path4_3.Add(new Point(50, 1120));
            path4_3.Add(new Point(50, 700));
            path4_3.Add(new Point(740, 700));
            path4_3.Add(new Point(740, 1000));
            
            List<Point> path4_4 = new List<Point>();
            path4_4.Add(new Point(1820, 1120));
            path4_4.Add(new Point(1820, 700));
            path4_4.Add(new Point(1150, 700));
            path4_4.Add(new Point(1150, 1000));

            List<List<Point>> path4 = new List<List<Point>>();
            path4.Add(path4_1);
            path4.Add(path4_2);
            path4.Add(path4_3);
            path4.Add(path4_4);

            #endregion

            #region List of Placements

            List<Placement> placements1 = new List<Placement>();
            List<Placement> placements2 = new List<Placement>();
            List<Placement> placements3 = new List<Placement>();
            List<Placement> placements4 = new List<Placement>();

            int placementWidth = 50, placementHeight = 55;
            // SETUP PLACEMENTS 1
            placements1.Add(new Placement(new Rectangle(724, 455, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(854, 455, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(542, 647, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(724, 345, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(854, 647, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(724, 647, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(724, 227, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(1037, 455, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(1167, 647, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(1037, 647, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(1347, 455, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(1414, 773, placementWidth, placementHeight)));
            placements1.Add(new Placement(new Rectangle(1414, 925, placementWidth, placementHeight)));

            // SETUP PLACEMENTS 2
            placements2.Add(new Placement(new Rectangle(50, 565, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(190, 565, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(330, 570, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(700, 430, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(835, 430, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(970, 430, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(1025, 520, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(1025, 610, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(1340, 560, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(1480, 560, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(1620, 560, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(50, 825, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(190, 825, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(330, 825, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(470, 825, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(610, 825, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(775, 875, placementWidth, placementHeight)));
            placements2.Add(new Placement(new Rectangle(775, 980, placementWidth, placementHeight)));

            // SETUP PLACEMENTS 3
            placements3.Add(new Placement(new Rectangle(225, 260, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(225, 155, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(225, 50, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(544, 280, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(684, 280, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(824, 280, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(964, 280, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1104, 50, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1104, 165, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1104, 280, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(544, 560, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(684, 560, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(824, 560, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(964, 560, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1104, 560, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1104, 700, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1104, 840, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1433, 490, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1433, 663, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1580, 663, placementWidth, placementHeight)));
            placements3.Add(new Placement(new Rectangle(1580, 490, placementWidth, placementHeight)));

            // SETUP PLACEMENTS 4
            // Esquerda-Cima
            placements4.Add(new Placement(new Rectangle(50, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(190, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(330, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(470, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(610, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(750, 420, placementWidth, placementHeight)));
            // Esquerda-Baixo
            placements4.Add(new Placement(new Rectangle(50, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(190, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(330, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(470, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(610, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(750, 600, placementWidth, placementHeight)));
            // Direita-Cima
            placements4.Add(new Placement(new Rectangle(1825, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1685, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1545, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1405, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1275, 420, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1135, 420, placementWidth, placementHeight)));
            // Direita-Baixo
            placements4.Add(new Placement(new Rectangle(1825, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1685, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1545, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1405, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1275, 600, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1135, 600, placementWidth, placementHeight)));
            // Cima-Esquerda
            placements4.Add(new Placement(new Rectangle(840, 20, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(840, 120, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(840, 220, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(840, 320, placementWidth, placementHeight)));
            // Cima-Direta
            placements4.Add(new Placement(new Rectangle(1025, 20, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1025, 120, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1025, 220, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1025, 320, placementWidth, placementHeight)));
            // Baixo-Esquerda
            placements4.Add(new Placement(new Rectangle(840, 1000, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(840, 900, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(840, 800, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(840, 700, placementWidth, placementHeight)));
            // Baixo-Direita
            placements4.Add(new Placement(new Rectangle(1025, 1000, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1025, 900, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1025, 800, placementWidth, placementHeight)));
            placements4.Add(new Placement(new Rectangle(1025, 700, placementWidth, placementHeight)));

            #endregion

            #region Cenaries of Phases

            var scenario1 = new Bitmap(@"assets\cenario1.jpg");
            var scenario2 = new Bitmap(@"assets\cenario2.jpg");
            var scenario3 = new Bitmap(@"assets\rockcenary1.jpg");
            var scenario4 = new Bitmap(@"assets\watercenary1.png");

            #endregion

            #region Lists of Tiers

            List<int> tiers1 = new List<int>();
            tiers1.Add(1);
            List<int> tiers2 = new List<int>();
            tiers2.Add(1);
            tiers2.Add(2);
            List<int> tiers3 = new List<int>();
            tiers3.Add(1);
            tiers3.Add(2);
            tiers3.Add(3);
            List<int> tiers4 = new List<int>();
            tiers4.Add(1);
            tiers4.Add(2);
            tiers4.Add(3);
            tiers4.Add(4);

            #endregion

            #region Lists of Types

            List<string> types1 = new List<string>();
            types1.Add("Grass");
            types1.Add("Bug");
            types1.Add("Flying");
            List<string> types2 = new List<string>();
            types2.Add("Grass");
            types2.Add("Bug");
            types2.Add("Flying");
            List<string> types3 = new List<string>();
            types3.Add("Rock");
            types3.Add("Steel");
            List<string> types4 = new List<string>();
            types4.Add("Water");
            types4.Add("Flying");

            #endregion

            #region Creation of Phases (SETUP)
            // CREATE PHASE 1
            phase1 = new Phase(1, tiers1, types1, 3, path1, scenario1, placements1);
            phase1.InitializeRareCandies(4);

            // CREATE PHASE 2
            phase2 = new Phase(2, tiers2, types2, 8, path2, scenario2, placements2);
            phase2.InitializeRareCandies(8);

            // CREATE PHASE 3
            phase3 = new Phase(3, tiers3, types3, 13, path3, scenario3, placements3);
            phase3.InitializeRareCandies(16);


            // CREATE PHASE 4
            phase4 = new Phase(4, tiers4, types4, 18, path4, scenario4, placements4);
            phase4.InitializeRareCandies(20);

            phases.Add(phase1);
            phases.Add(phase2);
            phases.Add(phase3);
            phases.Add(phase4);

            #endregion

            #region Initialization of Phase
            
            InitializeComponent();
            PlayBattleTheme();
            
            #endregion

            TypeConfigurator.ConfigureTypes();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            PbScreen.Size = Screen.PrimaryScreen.Bounds.Size;

            #region Mouse Events Attributions

            PbScreen.MouseDown += Form1_MouseDown;
            PbScreen.MouseDown += Inventory_MouseDown;
            PbScreen.MouseUp += Inventory_MouseUp;
            PbScreen.MouseUp += Form1_MouseUp;
            PbScreen.MouseMove += Form1_MouseMove;
            PbScreen.MouseMove += Inventory_MouseMove;

            PbScreen.MouseClick += Placement_MouseClick;
            PbScreen.MouseClick += BackButtonClick;
            PbScreen.MouseClick += InventoryButtonClick;

            #endregion

            var newBmp = new Bitmap(PbScreen.Width, PbScreen.Height);

            g = Graphics.FromImage(newBmp);
            PbScreen.Image = newBmp;
            int delayWave = 0;

            Pen pen = new Pen(Color.Black);


            // TESTE ADICIONANDO POKEMONS
            Pokemon Pikachu = new Pikachu();
            Pikachu.isWild = false;
            this.selfPokemons.Add(Pikachu);

            #region Creation of Colors with Opacity

            Color blueOpacity = Color.FromArgb(150, Color.Blue);
            Brush brushBlueOpacity = new SolidBrush(blueOpacity);

            Color blackOpacity = Color.FromArgb(150, Color.Black);
            Brush brushBlackOpacity = new SolidBrush(blackOpacity);

            Color redOpacity = Color.FromArgb(150, Color.Red);
            Brush brushRedOpacity = new SolidBrush(redOpacity);

            #endregion

            var actualWave = 0;
            //Queue<DateTime> queue = new Queue<DateTime>();
            //queue.Enqueue(DateTime.Now);


            timer.Tick += delegate
            {
                //var now = DateTime.Now;
                //queue.Enqueue(now);
                //if (queue.Count > 20)
                //{
                    if (isPaused)
                    {
                        g.Clear(Color.Black);
                        g.DrawString("GAME PAUSED", new Font("Press Start 2P", 16, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width / 2 - 120, PbScreen.Height / 3 - 100));

                        RoundedRect roundedRect = new RoundedRect();
                        var backBtn = roundedRect.setRect(PbScreen.Width / 2 - 140, PbScreen.Height / 2 - 150, 280, 80);
                        g.FillPath(Brushes.Red, backBtn);

                        g.DrawString("Voltar", new Font("Press Start 2P", 18, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width / 2 - 70, PbScreen.Height / 2 - 120));

                        roundedRect = new RoundedRect();
                        var exitBtn = roundedRect.setRect(PbScreen.Width / 2 - 140, PbScreen.Height / 2 - 50, 280, 80);
                        g.FillPath(Brushes.Red, exitBtn);
                        g.DrawString("Sair", new Font("Press Start 2P", 18, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width / 2 - 50, PbScreen.Height / 2 - 20));
                    }
                    else if (showInventory)
                    {
                        g.Clear(blackOpacity);

                        g.DrawString("INVENTORY", new Font("Press Start 2P", 16, FontStyle.Regular), Brushes.White, new PointF(PbScreen.Width / 2 - 120, PbScreen.Height / 3 - 250));

                        Rectangle dr = new Rectangle(1800, 20, 80, 100);
                        Rectangle sr;

                        if (trashHover)
                            sr = new Rectangle(32, 0, 32, 32);
                        else
                            sr = new Rectangle(0, 0, 32, 32);

                        Bitmap trashIcon = new Bitmap(Image.FromFile(@"assets\thrash.png"), 64, 32);
                        g.DrawImage(trashIcon, dr, sr, GraphicsUnit.Pixel);
                        for (int j = 1; j < 4; j++)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                RoundedRect rect = new RoundedRect();
                                var path = rect.setRect(300 + (i * 160), 170 * j, 150, 150);
                                g.FillPath(brushBlackOpacity, path);
                            }
                        }

                        int contX = 330;
                        int contY = 210;

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
                                var xpEvolve = pokemon.XpEvolve;

                                if (i == inventoryHover)
                                    g.FillPath(brushRedOpacity, path);
                                else
                                    g.FillPath(brushBlackOpacity, path);

                                g.DrawString(name, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.White, new PointF(110 + (i * 215), 790));
                                g.DrawString("Lv " + level, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.Red, new PointF(220 + (i * 215), 810));
                                DrawXpBar(xp, 110 + (i * 215), 970, xpEvolve);

                                Rectangle destRect = new Rectangle(135 + (i * 215), 835, 130, 120);
                                g.DrawImage(sprite, destRect, 3, 6, 59, 55, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                if (i == inventoryHover)
                                    g.FillPath(brushBlueOpacity, path);
                                else
                                    g.FillPath(brushBlackOpacity, path);
                            }
                        }

                        for (int i = 0; i < InventoryPokemons.Count; i++)
                        {
                            if (i != inventoryGrabbed)
                            {
                                var nextLineX = i == 0 ? 0 : i % 8;
                                var nextLineY = i == 0 ? 0 : i / 8;

                                g.DrawString(InventoryPokemons[i].Name, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.White, new PointF(contX - 15 + (160 * nextLineX), contY - 25 + (170 * nextLineY)));
                                g.DrawString("Lv " + InventoryPokemons[i].Level, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.Red, new PointF(contX + 60 + (160 * nextLineX), contY - 10 + (170 * nextLineY)));
                                Rectangle destRect = new Rectangle(contX + (160 * nextLineX), contY + (170 * nextLineY), 90, 100);
                                InventoryPokemons[i].StaticAnimate(g, destRect);
                            }
                            else
                            {
                                Rectangle destRect = new Rectangle(Cursor.Position.X - 45, Cursor.Position.Y - 50, 90, 100);
                                InventoryPokemons[i].StaticAnimate(g, destRect);
                            }
                        }

                        // BACK INVENTORY BUTTON
                        RoundedRect roundedRect = new RoundedRect();
                        GraphicsPath invRect = roundedRect.setRect(1540, 977, 179, 60);
                        g.FillPath(Brushes.Red, invRect);
                        g.DrawString("Voltar", new Font("Press Start 2P", 12, FontStyle.Regular), Brushes.White, new PointF(1580, 998));
                    }
                    else
                    {
                        // BACKGROUND
                        g.Clear(Color.Transparent);

                        phases[actualPhase].DrawScenario(g);

                        g.DrawString("Rare Candies:" + (phases[actualPhase].RareCandies.Count - phases[actualPhase].CountRareCandies()).ToString() + "/" + phases[actualPhase].RareCandies.Count.ToString(), new Font("Press Start 2P", 18, FontStyle.Bold), Brushes.Black, new Point(20, 30));
                        g.DrawString("Wave:" + phases[actualPhase].ActualWave.ToString() + "/" + phases[actualPhase].WavesLimit.ToString(), new Font("Press Start 2P", 18, FontStyle.Bold), Brushes.Black, new Point(20, 75));

                        if (phases[actualPhase].Waves.Count > 0)
                        {
                            var end = phases[actualPhase].Waves[phases[actualPhase].ActualWave - 1].End;
                            if (end)
                            {
                                if (phases[actualPhase].End)
                                    nextWave = true;
                                else
                                {
                                    actualWave = phases[actualPhase].ActualWave;
                                    delayWave = 50;
                                }
                            }
                        }

                        // PLACEMENTS
                        phases[actualPhase].Placements.ForEach(p =>
                        {
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

                        // STOP MOVING POKEMONS
                        if (grabbed != -1)
                        {
                            phases[actualPhase].DrawWildPokemons(g);
                            // RARE CANDIES
                            phases[actualPhase].RareCandies.ForEach(r =>
                            {
                                g.DrawImage(r.Sprite, r.Position.X, r.Position.Y);
                            });
                        }

                        if (!pokeball.isDragging && !phases[actualPhase].GameOver && grabbed == -1 && !nextWave)
                        {
                            //WILD POKEMONS
                            phases[actualPhase].RunPhase(g);
                            phases[actualPhase].runTurrets(g, phases[actualPhase].Placements);

                            // RARE CANDIES
                            phases[actualPhase].RareCandies.ForEach(r =>
                            {
                                g.DrawImage(r.Sprite, r.Position.X, r.Position.Y);
                            });

                            g.DrawImage(
                                pokeball.BmpClosed,
                                1524,
                                767
                            );
                        }

                        // POKEBALL
                        if (pokeball.isDragging)
                        {
                            var isOver = false;
                            var WildPokemons = phases[actualPhase].GetWilds();
                            WildPokemons.ForEach(wild =>
                            {
                                if (Math.Abs(Cursor.Position.X - wild.Location.Value.X) < 40 && Math.Abs(Cursor.Position.Y - wild.Location.Value.Y) < 40 && (wild.ActualLife * 100) / wild.Life < 25 && wild.IsAlive)
                                {
                                    isOver = true;
                                    g.DrawImage(pokeball.BmpOpened,
                                        Cursor.Position.X - 100,
                                        Cursor.Position.Y - 180,
                                        200, 360);

                                    phases[actualPhase].DrawWildPokemons(g);
                                    // RARE CANDIES
                                    phases[actualPhase].RareCandies.ForEach(r =>
                                    {
                                        g.DrawImage(r.Sprite, r.Position.X, r.Position.Y);
                                    });
                                }
                            });

                            if (!isOver)
                            {
                                phases[actualPhase].DrawWildPokemons(g);
                                // RARE CANDIES
                                phases[actualPhase].RareCandies.ForEach(r =>
                                {
                                    g.DrawImage(r.Sprite, r.Position.X, r.Position.Y);
                                });

                                g.DrawImage(
                                    pokeball.BmpClosed,
                                    Cursor.Position.X - (pokeball.Width / 2),
                                    Cursor.Position.Y - (pokeball.Height / 2)
                                );
                            }
                        }
                    phases[actualPhase].GameOver = true;
                    // DRAW INFO PHASES AND WAVES
                    if (phases[actualPhase].GameOver)
                        {
                        #region GameOver Show and Set Items

                        g.DrawString("Game Over!", new Font("Press Start 2P", (float)(0.07 * (PbScreen.Width / 2 - (PbScreen.Width/10))), FontStyle.Bold), Brushes.Red, new PointF(PbScreen.Width / 2 - (float)(PbScreen.Width/5.5), PbScreen.Height / 2));
                        
                        g.FillPath(Brushes.Black, BackRetryRect.path);

                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;
                        
                        g.DrawString("RETRY", new Font("Press Start 2P", (float)(0.02 * RetryRectangle.Location.X), FontStyle.Bold), Brushes.Red, RetryRectangle, format);
                        
                        #endregion
                    }
                    else
                        {
                            if (nextWave)
                            {
                                if (actualPhase + 1 != phases.Count)
                                {
                                    nextPhase = true;
                                    g.DrawString("Phase Clear!", new Font("Press Start 2P", 32, FontStyle.Bold), Brushes.Yellow, new PointF(PbScreen.Width / 2 - 180, PbScreen.Height / 2));

                                    nextPhaseButton = new RoundedRect();
                                    var bg = nextPhaseButton.setRect(PbScreen.Width / 2 - 100, PbScreen.Height / 2 + 50, 300, 80);

                                    Rectangle rect = new Rectangle(PbScreen.Width / 2 - 100, PbScreen.Height / 2 + 50, 300, 80);
                                    if (nextPhaseButton != null)
                                    {
                                        if (rect.Contains(Cursor.Position))
                                            nextPhaseButton.Hover = true;
                                        else
                                            nextPhaseButton.Hover = false;
                                    }

                                    if (nextPhaseButton.Hover)
                                        g.FillPath(Brushes.Blue, bg);
                                    else
                                        g.FillPath(Brushes.Black, bg);
                                    g.DrawString("Continue", new Font("Press Start 2P", 26, FontStyle.Bold), Brushes.Red, new PointF((PbScreen.Width / 2) - 100, (PbScreen.Height / 2 + 75)));
                                }
                                else
                                {
                                    g.DrawString("Congrats! You Beat the Game", new Font("Press Start 2P", 32, FontStyle.Bold), Brushes.Yellow, new PointF(PbScreen.Width / 2 - 600, PbScreen.Height / 2 - 50));
                                }
                            }
                            else if (delayWave > 0)
                            {
                                g.DrawString("Wave " + actualWave.ToString() + " Ended", new Font("Press Start 2P", 32, FontStyle.Bold), Brushes.Yellow, new PointF(PbScreen.Width / 2 - 180, PbScreen.Height / 2));

                                delayWave--;
                            }
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
                                var xpEvolve = pokemon.XpEvolve;

                                if (grabbed == -1)
                                {
                                    if (pokemon.IsPlaced)
                                        g.FillPath(brushBlueOpacity, path);
                                    else
                                        g.FillPath(brushBlackOpacity, path);

                                    g.DrawString(name, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.White, new PointF(110 + (i * 215), 740));
                                    g.DrawString("Lv " + level, new Font("Press Start 2P", 8, FontStyle.Regular), Brushes.Red, new PointF(220 + (i * 215), 760));
                                    DrawXpBar(xp, 110 + (i * 215), 920, xpEvolve);
                                }

                                if (i == grabbed)
                                {
                                    Rectangle destRect = new Rectangle(Cursor.Position.X - 50, Cursor.Position.Y - 50, 100, 100);
                                    g.DrawImage(sprite, destRect, 3, 10, 59, 55, GraphicsUnit.Pixel);
                                }
                                else if (grabbed == -1)
                                {
                                    Rectangle destRect = new Rectangle(135 + (i * 215), 785, 130, 120);
                                    g.DrawImage(sprite, destRect, 3, 6, 59, 55, GraphicsUnit.Pixel);
                                }
                            }
                            else if (grabbed == -1)
                            {
                                g.FillPath(brushBlackOpacity, path);
                            }
                        }

                        // INVENTORY BUTTON
                        g.FillPath(Brushes.Red, InventoryRect);
                        g.DrawString("Inventário", new Font("Press Start 2P", 12, FontStyle.Regular), Brushes.White, new PointF(1548, 998));

                        // SPEED CONTROL
                        g.FillPath(Brushes.Black, SpeedControlBackground);
                        g.DrawString("Speed", new Font("Press Start 2P", 24F, FontStyle.Regular), Brushes.White, new PointF(17, 1000));

                        for (int i = 0; i < 4; i++)
                        {
                            g.FillPath(Brushes.Red, SpeedControlRectangles[i]);
                        }

                        for (int i = 0, n = 0; i < 4; i++, n += 2)
                        {
                            var text = "";
                            if (n == 0)
                                text = "1X";
                            else
                                text = $"{n}X";

                            g.DrawString(text, new Font("Press Start 2P", 14F, FontStyle.Regular), Brushes.White, new PointF(215 + (90 * i), 1008));
                        }
                    }

                    //DateTime old = queue.Dequeue();
                    //var time = now - old;
                    //var fps = (int)(19 / time.TotalSeconds);
                    //var drawFont = new Font("Press Start 2P", 16);
                    //PointF drawPoint = new PointF(1760.0F, 50.0F);
                    //g.DrawString($"{fps} fps", drawFont, Brushes.Black, drawPoint);

                    PbScreen.Refresh();
                //}
            };
        }

        private void DrawXpBar(int xp, int x, int y, int xpEvolve)
        {
            int sizeXp = 140;
            Rectangle backRect = new Rectangle(x + 20, y, sizeXp, 20);
            Rectangle frontRect = new Rectangle(x + 21, y + 1, Convert.ToInt16(xp * (Convert.ToDecimal(sizeXp - 2) / xpEvolve)), 18);
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

        private void Inventory_MouseMove(object sender, MouseEventArgs e)
        {
            inventoryHover = -1;

            if (inventoryGrabbed != -1)
            {
                for (int i = 0; i < 6; i++)
                {
                    var startX = 100 + (i * 215);
                    var startY = 780;

                    if (Cursor.Position.X > startX && Cursor.Position.X < startX + 200 &&
                        Cursor.Position.Y > startY && Cursor.Position.Y < startY + 220)
                    {
                        inventoryHover = i;
                    }
                }
            }

            Rectangle dr = new Rectangle(1800, 20, 80, 100);

            if(dr.Contains(Cursor.Position) && inventoryGrabbed != -1)
            {
                trashHover = true;
            }
            else
            {
                trashHover = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }


        private void Inventory_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void Inventory_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle dr = new Rectangle(1800, 20, 80, 100);

            if (dr.Contains(Cursor.Position) && inventoryGrabbed != -1)
            {
                InventoryPokemons.Remove(InventoryPokemons[inventoryGrabbed]);
                inventoryGrabbed = -1;
            }

            if (inventoryGrabbed != -1)
            {
                if (inventoryHover != -1)
                {
                    if (selfPokemons.Count > inventoryHover)
                    {
                        if (selfPokemons[inventoryHover].IsPlaced)
                        {
                            phases[actualPhase].Placements.ForEach(p =>
                            {
                                if(p.Pokemon == selfPokemons[inventoryHover])
                                {
                                    p.RemovePokemon();
                                }
                            });
                        }

                        var pokemon = selfPokemons[inventoryHover];
                        selfPokemons[inventoryHover] = InventoryPokemons[inventoryGrabbed];
                        InventoryPokemons[inventoryGrabbed] = pokemon;
                    }
                    else
                    {
                        var pokemon = InventoryPokemons[inventoryGrabbed];
                        selfPokemons.Add(pokemon);
                        InventoryPokemons.Remove(InventoryPokemons[inventoryGrabbed]);
                    }
                }
            }

            inventoryGrabbed = -1;
            
            if (showInventory)
            {
                for (int i = 0; i < InventoryPokemons.Count; i++)
                {
                    var nextLineX = i == 0 ? 0 : i % 8;
                    var nextLineY = i == 0 ? 0 : i / 8;
                    var startX = 330 + (160 * nextLineX);
                    var startY = 210 + (170 * nextLineY);

                    if (Cursor.Position.X > startX && Cursor.Position.X < startX + 90 &&
                        Cursor.Position.Y > startY && Cursor.Position.Y < startY + 100)
                    {
                        inventoryGrabbed = i;
                    }
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // NEXT PHASE BUTTON CLICKED
            Rectangle rect = new Rectangle(PbScreen.Width / 2 - 100, PbScreen.Height / 2 + 50, 300, 80);
            if (rect.Contains(Cursor.Position) && nextPhase)
            {
                phases[actualPhase].Placements.ForEach(p =>
                {
                    p.RemovePokemon();
                });
                actualPhase++;
                nextWave = false;
                phases[actualPhase].End = false;
                phases[actualPhase].GameOver = false;
                nextPhase = false;
                selfPokemons.ForEach(pk =>
                {
                    pk.IsPlaced = false;
                });

                string folder = @"";
                string fileName = "savePhase.txt";
                string fullPath = folder + fileName;
                string[] phase = {actualPhase.ToString()};
                File.WriteAllLines(fullPath, phase);
                string readText = File.ReadAllText(fullPath);
            }

            if (e.Location.X >= pokeball.Location.X && e.Location.X < (pokeball.Location.X + pokeball.Width) &&
                e.Location.Y >= pokeball.Location.Y && e.Location.Y < (pokeball.Location.Y + pokeball.Height))
            {
                pokeball.isDragging = true;
            }

            if (e.Button == MouseButtons.Left)
            {
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
                phases[actualPhase].Placements.ForEach(p =>
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
                var WildPokemons = phases[actualPhase].GetWilds();
                WildPokemons.ForEach(wild =>
                {
                    if (Math.Abs(Cursor.Position.X - wild.Location.Value.X) < 40 && Math.Abs(Cursor.Position.Y - wild.Location.Value.Y) < 40 && (wild.ActualLife * 100) / wild.Life < 25 && wild.IsAlive)
                    {
                        if (selfPokemons.Count < 6)
                        {
                            wild.isWild = false;
                            wild.IsAlive = false;
                            selfPokemons.Add(wild);
                        }
                        else if (InventoryPokemons.Count < 24)
                        {
                            wild.isWild = false;
                            wild.IsAlive = false;
                            InventoryPokemons.Add(wild);
                        }
                    }
                });
                pokeball.isDragging = false;
            }

            if (grabbed != -1) {
                phases[actualPhase].Placements.ForEach(p =>
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
            SoundPlayer simpleSound = new SoundPlayer(@"assets\Battle_Theme.wav");
            simpleSound.PlayLooping();
            
        }
    }
}