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
        public List<Pokemon> Pokemons { get; set; }
        public bool End { get; set; } = false;

        public Wave(int id) {
            WaveId = id;
        }
        public void AddPokemon(Pokemon pokemon)
        {
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

        public void isEnded()
        {
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Life <= 0)
                    Pokemons.Remove(pokemon);        
            }

            if (Pokemons.Count <= 0)
                End = true;
        }
    }
}
