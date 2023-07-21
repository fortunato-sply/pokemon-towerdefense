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
        public bool End { get; set; } = false;
        public List<Point> PhasePath { get; set; } = new List<Point> { };
        public int GameTime = 0;

        public void RunPhase(Graphics graphics)
        {
            if (PhasePath.Count == 0)
            {
                List<Point> path = new List<Point>();
                path.Add(new Point(570, 0));
                path.Add(new Point(570, 550));
                path.Add(new Point(1330, 550));
                path.Add(new Point(1330, 1200));
                generatePhasePath(path);
            }

            if (Waves.Count == 0)
                GenerateWaves(3);

            runPokemons();

            foreach (var pokemon in Waves[0].Pokemons)
            {
                if (pokemon.IsAlive)
                {
                    var lifeBack = new Rectangle(pokemon.Location.Value.X, pokemon.Location.Value.Y - 8, 70, 10);
                    var lifeFront = new Rectangle(pokemon.Location.Value.X+1, pokemon.Location.Value.Y - 7, 68 - Convert.ToInt16(Convert.ToDecimal(68/100) * pokemon.Life), 8);
                    var imgRect = new Rectangle(pokemon.Location.Value.X, pokemon.Location.Value.Y, 70, 77);
                    var sprites = pokemon.Animate();

                    graphics.FillRectangle(Brushes.White, lifeBack);
                    graphics.FillRectangle(Brushes.Blue, lifeFront);

                    graphics.DrawImage(sprites, imgRect, 3 + ((pokemon.ActualImage % 4) * 64), 10, 59, 55, GraphicsUnit.Pixel);

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
            for (int i = 0; i < quantity; i++)
            {
                Wave wave = new Wave(i);
                Waves.Add(wave);
                Waves[i].GenerateWave(Id, PhasePath[0]);
            }
        }
        public void generatePhasePath(List<Point> points)
        {
            PhasePath = points;
        }

        public void runPokemons()
        {
            Waves[0].IsEnded();

            if (Waves[0].End)
            {
                Waves.RemoveAt(0);
            }
            foreach (var Pokemon in Waves[0].Pokemons)
            {
                if (Pokemon.PathPoint < PhasePath.Count)
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

        public void runTurrets(List<Placement> pokemons)
        {
            GameTime++;

            pokemons.ForEach(p =>
            {
                if (p.hasPokemon)
                {
                    if (GameTime % p.Pokemon.SelectedAttack.Cooldown == 0)
                    {
                        p.Pokemon.selectTarget(Waves[0].Pokemons);
                        p.Pokemon.GiveDamage();
                    }
                }
            });
        }
    }
}