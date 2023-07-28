﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace pokemon_towerdefense.Models
{
    internal class Phase
    {
        public int Id { get; set; } = 1;
        public List<Wave> Waves { get; set; } = new List<Wave>();
        public int CoolDownSpawn = 40;
        public int incrementator = 1;
        public bool End { get; set; } = false;
        public List<List<Point>> PhasePath { get; set; } = new List<List<Point>> { };
        public int GameTime = 0;
        public int ActualWave = 1;
        public int WavesLimit = 0;
        public List<int> PhaseTiers;
        public List<string> PhaseTypes;
        public List<RareCandy> RareCandies = new List<RareCandy>();
        public bool GameOver = false;
        public Bitmap Scenario = null;
        public List<Placement> Placements = new List<Placement>();
        public void DrawScenario(Graphics graphics)
        {
            graphics.DrawImage(Scenario, 0, 0);
        }


        public void VerifyGameOver()
        {
            var count = CountRareCandies();
            
            if (count == RareCandies.Count) 
                GameOver = true;
        }

        public int CountRareCandies()
        {
            var count = 0;

            RareCandies.ForEach(r =>
            {
                PhasePath.ForEach(p =>
                {
                    if (Math.Abs(r.Position.X - p[0].X) < 40 && Math.Abs(r.Position.Y - p[0].Y) < 40)
                    {
                        count++;
                    }
                });
            });

            return count;
        }

        public void InitializeRareCandies(int quantity)
        {
            Random random = new Random();

            if (PhasePath.Count > 0)
            {
                for (int i = 0; i < quantity / PhasePath.Count; i++)
                {
                    for (int j = 0; j < PhasePath.Count; j++) {
                        RareCandy rareCandy = new RareCandy(new Point(PhasePath[j][PhasePath[j].Count - 1].X + random.Next(-30, 30),
                            PhasePath[j][PhasePath[j].Count - 1].Y + random.Next(-30, 30)));

                        RareCandies.Add(rareCandy);
                    }
                }
            }
        }

        public Phase(int id, List<int> tiers, List<string> types, int limit, List<List<Point>> points, Bitmap scenario, List<Placement> placements)
        {
            Id = id;
            PhaseTiers = tiers;
            PhaseTypes = types;
            WavesLimit = limit;
            PhasePath = points;
            Scenario = scenario;
            Placements= placements;
        }

        public List<Pokemon> GetWilds()
        {
            return Waves[ActualWave - 1].Pokemons;
        }

        public void IsEnded()
        {
            if (ActualWave >= WavesLimit)
                End = true;
            else
                End = false;

        }
        public void RunPhase(Graphics graphics)
        {    
            IsEnded();
            VerifyGameOver();

            if(Waves.Count == 0 && !End)
            {
                Waves.Add(new Wave(1));
            }
            if (Waves[ActualWave - 1].Pokemons.Count >= 3 + (ActualWave * 2))
            {
                if(Waves[ActualWave-1].End && !End){
                    ActualWave++;
                    Waves.Add(new Wave(ActualWave));
                }
            }
            else
            {
                if (incrementator % CoolDownSpawn == 0)
                {
                    Random random = new Random();

                    var result = false;
                    while (!result)
                    {
                        var tier = PhaseTiers[random.Next(0, PhaseTiers.Count)];
                        var type = PhaseTypes[random.Next(0, PhaseTypes.Count)];
                        result = Waves[ActualWave - 1].AddPokemon(Id, PhasePath[random.Next(PhasePath.Count)], tier, type);
                    }
                }
            }

            incrementator++;

            if (Waves[ActualWave-1].Pokemons.Count > 0)
                runPokemons();
            
            DrawWildPokemons(graphics);
        }

        public void DrawWildPokemons(Graphics graphics)
        {
            foreach (var pokemon in Waves[ActualWave - 1].Pokemons)
            {
                if (pokemon.IsAlive)
                {
                    var lifeBack = new Rectangle(pokemon.Location.Value.X, pokemon.Location.Value.Y - 8, 70, 10);
                    var lifeFront = new Rectangle(pokemon.Location.Value.X + 1, pokemon.Location.Value.Y - 7, Convert.ToInt16(0.68f * ((pokemon.ActualLife * 100) / pokemon.Life)), 8);
                    graphics.FillRectangle(Brushes.White, lifeBack);

                    if ((pokemon.ActualLife * 100) / pokemon.Life < 25)
                        graphics.FillRectangle(Brushes.Red, lifeFront);
                    else
                        graphics.FillRectangle(Brushes.Blue, lifeFront);

                    pokemon.Animate(graphics);
                    pokemon.SpeedImage++;
                    if (pokemon.SpeedImage >= 6)
                    {
                        pokemon.ActualImage += 1;
                        pokemon.SpeedImage = 0;
                    }
                }
            }
        }

        public void runPokemons()
        {
            var alives = 0;

            foreach (var Pokemon in Waves[ActualWave - 1].Pokemons)
            {
                var verify = true;
                
                if (Math.Abs(Pokemon.Location.Value.X - Pokemon.Path[0].X) <= 20 && Math.Abs(Pokemon.Location.Value.Y - Pokemon.Path[0].Y) <= 20 && Pokemon.RunningBack)
                {
                    verify = false;
                }

                if (verify && Pokemon.isWild && Pokemon.IsAlive)
                {
                    alives++;

                    Pokemon.Location
                        = new Point(Pokemon.Location.Value.X + Pokemon.SpeedX,
                        Pokemon.Location.Value.Y + Pokemon.SpeedY);

                    Pokemon.CollectCandy(RareCandies);

                    if (Pokemon.rareCandy != null)
                    {
                        if (!Pokemon.ExternalStealing && !Pokemon.RunningBack)
                        {
                            Pokemon.ExternalStealing = true;
                            Pokemon.PathPoint--;
                            Pokemon.RunningBack = true;
                        }

                        RareCandies.Where(r => r == Pokemon.rareCandy).ToList()[0].Position = Pokemon.Location.Value;

                        if(Pokemon.PathPoint < 0)
                            Pokemon.PathPoint = 0;

                        if (Math.Abs(Pokemon.Location.Value.X - Pokemon.Path[Pokemon.PathPoint].X) < 20 && Math.Abs(Pokemon.Location.Value.Y - Pokemon.Path[Pokemon.PathPoint].Y) < 20 && Pokemon.PathPoint > 0)
                        {
                            Pokemon.PathPoint -= 1;
                            Pokemon.SpeedX = 0;
                            Pokemon.SpeedY = 0;
                        }

                        if (Pokemon.PathPoint < Pokemon.Path.Count - 1)
                        {
                            Pokemon.SpeedX = Pokemon.Path[Pokemon.PathPoint].X - Pokemon.Path[Pokemon.PathPoint + 1].X < 0 ? -Pokemon.Speed :
                                Pokemon.Path[Pokemon.PathPoint].X - Pokemon.Path[Pokemon.PathPoint + 1].X > 0 ? Pokemon.Speed : Pokemon.SpeedX = 0;
                            Pokemon.SpeedY = Pokemon.Path[Pokemon.PathPoint].Y - Pokemon.Path[Pokemon.PathPoint + 1].Y < 0 ? -Pokemon.Speed :
                                Pokemon.Path[Pokemon.PathPoint].Y - Pokemon.Path[Pokemon.PathPoint + 1].Y > 0 ? Pokemon.Speed : Pokemon.SpeedY = 0;
                        }
                    }
                    else if(Pokemon.PathPoint <= Pokemon.Path.Count)
                    {
                        if (Math.Abs(Pokemon.Location.Value.X - Pokemon.Path[Pokemon.PathPoint].X) < 20 && Math.Abs(Pokemon.Location.Value.Y - Pokemon.Path[Pokemon.PathPoint].Y) < 20)
                        {
                            if(Pokemon.PathPoint+1 == Pokemon.Path.Count)
                               Pokemon.RunningBack= true;
                            if (Pokemon.RunningBack && Pokemon.PathPoint > 0)
                                Pokemon.PathPoint -= 1;
                            else
                                Pokemon.PathPoint += 1;

                            Pokemon.SpeedX = 0;
                            Pokemon.SpeedY = 0;
                        }

                        if (Pokemon.PathPoint < Pokemon.Path.Count)
                        {
                            if (Pokemon.SpeedX == 0 && Pokemon.SpeedY == 0)
                            {
                                if (Pokemon.RunningBack)
                                {
                                    Pokemon.SpeedX = Pokemon.Path[Pokemon.PathPoint].X - Pokemon.Path[Pokemon.PathPoint + 1].X < 0 ? -Pokemon.Speed :
                                        Pokemon.Path[Pokemon.PathPoint].X - Pokemon.Path[Pokemon.PathPoint + 1].X > 0 ? Pokemon.Speed : Pokemon.SpeedX = 0;
                                    Pokemon.SpeedY = Pokemon.Path[Pokemon.PathPoint].Y - Pokemon.Path[Pokemon.PathPoint + 1].Y < 0 ? -Pokemon.Speed :
                                        Pokemon.Path[Pokemon.PathPoint].Y - Pokemon.Path[Pokemon.PathPoint + 1].Y > 0 ? Pokemon.Speed : Pokemon.SpeedY = 0;
                                }
                                else if(Pokemon.PathPoint > 0)
                                {
                                    Pokemon.SpeedX = Pokemon.Path[Pokemon.PathPoint - 1].X - Pokemon.Path[Pokemon.PathPoint].X < 0 ? Pokemon.Speed :
                                        Pokemon.Path[Pokemon.PathPoint - 1].X - Pokemon.Path[Pokemon.PathPoint].X > 0 ? -Pokemon.Speed : Pokemon.SpeedX = 0;
                                    Pokemon.SpeedY = Pokemon.Path[Pokemon.PathPoint - 1].Y - Pokemon.Path[Pokemon.PathPoint].Y < 0 ? Pokemon.Speed :
                                        Pokemon.Path[Pokemon.PathPoint - 1].Y - Pokemon.Path[Pokemon.PathPoint].Y > 0 ? -Pokemon.Speed : Pokemon.SpeedY = 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Pokemon.rareCandy != null)
                    {
                        if (!Pokemon.IsAlive)
                            RareCandies.Where(r => r == Pokemon.rareCandy).ToList()[0].IsStealed = false;
                        Pokemon.rareCandy = null;
                        Pokemon.Stealing = false;
                    }
                    if (Pokemon.IsAlive)
                    {
                        Pokemon.RunningBack = false;
                        Pokemon.PathPoint = 0;
                        Pokemon.IsAlive = true;
                        Pokemon.isWild = true;
                        Pokemon.SpeedX = 0;
                        Pokemon.SpeedY = 0;
                        Pokemon.PathPoint = 0;
                        Pokemon.ExternalStealing = false;
                        Pokemon.Location = Pokemon.Path[0];
                    }
                }
            }
            if (alives == 0 && Waves[ActualWave - 1].Pokemons.Count > 0 && Waves[ActualWave - 1].Pokemons.Count >= 3 + (ActualWave * 2))
                Waves[ActualWave - 1].End = true;
        }

        public void runTurrets(Graphics g, List<Placement> pokemons)
        {
            pokemons.ForEach(p =>
            {
                if (p.hasPokemon)
                {
                    p.Pokemon.SelectedAttack.AddAttackTick();
                    if (p.Pokemon.SelectedAttack.AttackTick % p.Pokemon.SelectedAttack.Cooldown == 0)
                    {
                        p.Pokemon.selectTarget(Waves[ActualWave - 1].Pokemons);
                        p.Pokemon.GiveDamage(g);
                        p.Pokemon.SelectedAttack.StartAttack = true;
                        p.Pokemon.SelectedAttack.StartPosition = p.Pokemon.Location.Value;
                    }

                    p.Pokemon.SelectedAttack.ShootAttack(g, p.Pokemon);
                }
            });
        }
    }
}