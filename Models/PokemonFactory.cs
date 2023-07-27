﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            new Magikarp(),
            new Gyarados(),
            new Gastly(),
            new Haunter(),
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
            new Dratini(),
            new Dragonair(),
            new Dragonite(),
            new Pikachu(),
            new Raichu(),
            new Abra(),
            new Kadabra(),
            new Alakazam(),
            new Aron(),
            new Lairon(),
            new Aggron(),
            new Onix(),
            new Kabuto(),
            new Kabutops(),
            new Diglett(),
            new Dugtrio(),
            new Glalie(),
            new Lapras(),
            new Cranidos(),
            new Rampardos(),
            new Larvitar(),
            new Pupitar(),
            new Tyranitar(),
            new Cubone(),
            new Marowak(),
            new Totodile(),
            new Croconaw(),
            new Feraligatr(),
            new Lotad(),
            new Lombre(),
            new Ludicolo(),
            new Horsea(),
            new Seadra(),
            new Kingdra(),
            new Sandshrew(),
            new Sandslash(),
            new Psyduck(),
            new Golduck(),
            new Growlithe(),
            new Arcanine(),
            new Mawile(),
            new Mew(),
            new Scizor(),
            new Beldum(),
            new Metang(),
            new Metagross()
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
            if (pokemons.Count == 0)
                return null;

            for (int i = 0; i < quantity; i++)
            {
                Pokemon clonedPokemon = pokemons[rand.Next(0, pokemons.Count)];
                if (clonedPokemon != null)
                {
                    clonedPokemon = clonedPokemon.Clone(rand.Next(minLevel, maxLevel));
                    randomPokemons.Add(clonedPokemon);
                }
                else
                    i--;
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
