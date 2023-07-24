using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon_towerdefense.Models
{
    internal class Phase
    {
        public int Id { get; set; } = 1;
        public List<Wave> Waves { get; set; } = new List<Wave>();
        public int CoolDownSpawn = 40;
        public int incrementator = 1;
        public bool End { get; set; } = false;
        public List<Point> PhasePath { get; set; } = new List<Point> { };
        public int GameTime = 0;
        public int ActualWave = 1;

        public List<Pokemon> GetWilds()
        {
            return Waves[0].Pokemons;
        }
        public void RunPhase(Graphics graphics)
        {
            if (PhasePath.Count == 0)
            {
                List<Point> path = new List<Point>();
                path.Add(new Point(570, 0));
                path.Add(new Point(570, 550));
                path.Add(new Point(1330, 550));
                path.Add(new Point(1330, 1000));
                path.Add(new Point(1330, 550));
                path.Add(new Point(570, 550));
                path.Add(new Point(570, -200));
                generatePhasePath(path);
            }
            
            if(Waves.Count == 0)
            {
                Waves.Add(new Wave(1));
            }
            if (Waves[ActualWave-1].Pokemons.Count >= 3 + (ActualWave * 2))
            {
                ActualWave++;
                Waves.Add(new Wave(ActualWave));
            }

            if(incrementator % CoolDownSpawn == 0)
            {
                Waves[0].AddPokemon(Id, PhasePath[0]);
            }

            incrementator++;
            //            if (Waves.Count == 0)
            //                 GenerateWaves(3);

            if (Waves[0].Pokemons.Count > 0)
            {
                runPokemons();
            }
            DrawWildPokemons(graphics);
        }

        public void DrawWildPokemons(Graphics graphics)
        {
            foreach (var pokemon in Waves[0].Pokemons)
            {
                if (pokemon.IsAlive)
                {
                    var lifeBack = new Rectangle(pokemon.Location.Value.X, pokemon.Location.Value.Y - 8, 70, 10);
                    var lifeFront = new Rectangle(pokemon.Location.Value.X + 1, pokemon.Location.Value.Y - 7, Convert.ToInt16(0.68f * ((pokemon.ActualLife * 100) / pokemon.Life)), 8);
                    graphics.DrawString(pokemon.Life.ToString(), new Font("Press Start 2P", 18, FontStyle.Regular), Brushes.White, new PointF(700, 700));
                    graphics.FillRectangle(Brushes.White, lifeBack);

                    if(pokemon.Life < 25)
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
        public void GenerateWaves(int quantity)
        {
            for (int i = 0; i < 3; i++)
            {
                Wave wave = new Wave(i);
                for (int j = 0; j < 3 + (i * 2); j++)
                {
                    wave.AddPokemon(Id, PhasePath[0]);
                }
                Waves.Add(wave);
            }
            //for (int i = 0; i < quantity; i++)
            //{
            //    Wave wave = new Wave(i);
            //    Waves.Add(wave);
            //    Waves[i].GenerateWave(Id, PhasePath[0]);
            //}
        }
        public void generatePhasePath(List<Point> points)
        {
            PhasePath = points;
        }

        public void runPokemons()
        {
            Waves[0].IsEnded();

            foreach (var Pokemon in Waves[0].Pokemons)
            {
                if (Pokemon.PathPoint < PhasePath.Count && Pokemon.isWild)
                {
                    Pokemon.Location
                        = new Point(Pokemon.Location.Value.X + Pokemon.SpeedX,
                        Pokemon.Location.Value.Y + Pokemon.SpeedY);

                    if (Math.Abs(Pokemon.Location.Value.X - PhasePath[Pokemon.PathPoint].X) < 20 && Math.Abs(Pokemon.Location.Value.Y - PhasePath[Pokemon.PathPoint].Y) < 20)
                    {
                        Pokemon.PathPoint += 1;
                        Pokemon.SpeedX = 0;
                        Pokemon.SpeedY = 0;
                    }

                    if (Pokemon.PathPoint < PhasePath.Count)
                    {
                        if (Pokemon.SpeedX == 0 && Pokemon.SpeedY == 0)
                        {
                            Pokemon.SpeedX = PhasePath[Pokemon.PathPoint - 1].X - PhasePath[Pokemon.PathPoint].X < 0 ? Pokemon.Speed :
                                PhasePath[Pokemon.PathPoint - 1].X - PhasePath[Pokemon.PathPoint].X > 0 ? -Pokemon.Speed : Pokemon.SpeedX = 0;
                            Pokemon.SpeedY = PhasePath[Pokemon.PathPoint - 1].Y - PhasePath[Pokemon.PathPoint].Y < 0 ? Pokemon.Speed :
                                        PhasePath[Pokemon.PathPoint - 1].Y - PhasePath[Pokemon.PathPoint].Y > 0 ? -Pokemon.Speed : Pokemon.SpeedY = 0;
                        }
                    }
                }
            }
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
                        p.Pokemon.selectTarget(Waves[0].Pokemons);
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