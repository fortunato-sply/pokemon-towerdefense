using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    internal class Wave
    {
        public int WaveId = 1;
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
        public bool End { get; set; } = false;

        public Wave(int id) {
            WaveId = id;
        }
        public void AddPokemon(int phase, Point point)
        {
            Pokemon pokemon = PokemonFactory.GetRandomPokemons(1, phase, phase + 3)[0];
            pokemon.Location = point;
            Pokemons.Add(pokemon);
        }

        public void GenerateWave(int phase, Point point)
        {
            Pokemons = PokemonFactory.GetRandomPokemons(3 + (WaveId * 2), phase, phase + 3);

            foreach(var pokemon in Pokemons)
            {
                pokemon.Location = point;
            }    
        }

        public void IsEnded()
        {
            var count = 0;
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.IsAlive)
                    count++;
            }

            if (count <= 0)
                End = true;
        }
    }
}
