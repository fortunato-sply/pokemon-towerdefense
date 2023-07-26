using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public int WavesLimit = 0;
        public List<int> PhaseTiers;
        public List<string> PhaseTypes;
        public List<RareCandy> RareCandies = new List<RareCandy>();

        public void InitializeRareCandies(int quantity)
        {
            Random random = new Random();

            for(int i = 0; i < quantity; i++)
            {
                RareCandy rareCandy = new RareCandy(new Point(PhasePath[PhasePath.Count - Convert.ToInt16(Math.Ceiling((double)Convert.ToDecimal(PhasePath.Count / 2)))].X + random.Next(-30, 30), 
                    PhasePath[PhasePath.Count - Convert.ToInt16(Math.Ceiling((double)(Convert.ToDecimal(PhasePath.Count) / 2)))].Y + random.Next(-30, 30)));

                RareCandies.Add(rareCandy);
            }
        }

        public Phase(List<int> tiers, List<string> types, int limit)
        {
            PhaseTiers = tiers;
            PhaseTypes = types;
            WavesLimit = limit;

            List<Point> path = new List<Point>();
            path.Add(new Point(570, 0));
            path.Add(new Point(570, 550));
            path.Add(new Point(1330, 550));
            path.Add(new Point(1330, 1000));
            path.Add(new Point(1330, 550));
            path.Add(new Point(570, 550));
            path.Add(new Point(570, -200));
            PhasePath = path;
        }

        public List<Pokemon> GetWilds()
        {
            return Waves[ActualWave - 1].Pokemons;
        }

        public void isEnded()
        {
            if (ActualWave >= WavesLimit)
                End = true;
            else
                End = false;

        }
        public void RunPhase(Graphics graphics)
        {    
            isEnded();

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
                    Waves[ActualWave-1].AddPokemon(Id, PhasePath[0], PhaseTiers[random.Next(0, PhaseTiers.Count)], PhaseTypes[random.Next(0, PhaseTypes.Count)]);
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
                if (Pokemon.PathPoint < PhasePath.Count && Pokemon.isWild && Pokemon.IsAlive)
                {
                    alives++;

                    Pokemon.Location
                        = new Point(Pokemon.Location.Value.X + Pokemon.SpeedX,
                        Pokemon.Location.Value.Y + Pokemon.SpeedY);

                    Pokemon.CollectCandy(RareCandies);

                    if(Pokemon.rareCandy != null)
                    {
                        RareCandies.Where(r => r == Pokemon.rareCandy).ToList()[0].Position = Pokemon.Location.Value;
                        MessageBox.Show(RareCandies.Where(r => r == Pokemon.rareCandy).ToList()[0].Position.X.ToString());
                    }

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
                else if (!Pokemon.IsAlive)
                { 
                    Pokemon.rareCandy = null;
                    RareCandies.Where(r => r == Pokemon.rareCandy).ToList()[0].IsStealed = false;
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