using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public static class PokemonFactory
    {
        private static Random rand = new Random();
        private static List<Pokemon> allPokemons = new List<Pokemon>() 
        {
            new Charizard(),
            new Gyarados(), 
            new Gengar(),

        };

        private static List<Pokemon> pokemonsTier1 = allPokemons.Where(p => p.Tier == 1).ToList();

        public static List<Pokemon> GetRandomPokemons(int quantity, int minLevel, int maxLevel)
        {
            var randomPokemons = new List<Pokemon>(quantity);
            for(int i = 0; i < quantity; i++)
            {
                Pokemon clonedPokemon = allPokemons[rand.Next(0, allPokemons.Count)].Clone(rand.Next(minLevel, maxLevel));
                randomPokemons.Add(clonedPokemon);
            }

            return randomPokemons;
        }
    }
}
