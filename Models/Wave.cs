using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    internal class Wave
    {
        public List<Pokemon> Pokemons { get; set; }
        public bool End { get; set; } = false;

        public Wave() { }
        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public void GenerateWave(List<Pokemon> pokemons)
        {
            for (int i = 0;i < Pokemons.Count; i++)
            {
                
            }
        }
    }
}
