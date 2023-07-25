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
            new Charmander(),
            new Charmeleon(),
            new Charizard(),
            new ShinyCharizard(),
            new Gyarados(),
            new Gengar(),
            new Pidgey(),
            new Pidgeotto(),
            new Pidgeot(),
            new Squirtle(),
            new Wartotle(),
            new Blastoise(),
            new Bulbasaur(),
            new Ivysaur(),
            new Venusaur(),
            //new Caterpie(),
            new Rattata(),
            new Weedle(),
            new Kakuna(),
            new Beedrill(),
            new Vulpix(),
            new Ninetales(),
            new AlolaNinetales(),
            new Snorlax(),
            new Aerodactyl(),
            new Dragonair(),
            new Dragonite()
        };

        public static List<Pokemon> GetPokemonsByTier(int tier, int quantity = 10, int minLevel = 1, int maxLevel = 100)
        {
            var pokemons = allPokemons.Where(p => p.Tier == tier).ToList();

            var randomPokemons = new List<Pokemon>(quantity);
            for (int i = 0; i < quantity; i++)
            {
                Pokemon clonedPokemon = pokemons[rand.Next(0, pokemons.Count)].Clone(rand.Next(minLevel, maxLevel));
                randomPokemons.Add(clonedPokemon);
            }

            return randomPokemons;
        }

        public static List<Pokemon> GetPokemonsByType(string type, int quantity = 10, int minLevel = 1, int maxLevel = 100)
        {
            var pokemons = allPokemons.Where(p => p.Type.Name == type).ToList();

            var randomPokemons = new List<Pokemon>(quantity);
            for (int i = 0; i < quantity; i++)
            {
                Pokemon clonedPokemon = pokemons[rand.Next(0, pokemons.Count)].Clone(rand.Next(minLevel, maxLevel));
                randomPokemons.Add(clonedPokemon);
            }

            return randomPokemons;
        }

        public static List<Pokemon> GetPokemonsByTypeAndTier(string type, int tier, int quantity = 10, int minLevel = 1, int maxLevel = 100)
        {
            var pokemons = allPokemons.Where(p => p.Type.Name == type && p.Tier == tier).ToList();

            var randomPokemons = new List<Pokemon>(quantity);
            for (int i = 0; i < quantity; i++)
            {
                Pokemon clonedPokemon = pokemons[rand.Next(0, pokemons.Count)].Clone(rand.Next(minLevel, maxLevel));
                randomPokemons.Add(clonedPokemon);
            }

            return randomPokemons;
        }

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
