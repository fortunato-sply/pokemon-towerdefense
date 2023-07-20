using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public class Placement
    {
        public Rectangle rect { get; set; }
        public bool hasPokemon = false;
        public Pokemon Pokemon = null;

        public Placement(Rectangle rect)
        {
            this.rect = rect;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            if(this.Pokemon == null)
            {
                pokemon.IsPlaced = true;
                pokemon.Location = this.rect.Location;
                this.Pokemon = pokemon;
                this.hasPokemon = true;
            }
        }

        public void RemovePokemon()
        {
            if (this.Pokemon != null)
            {
                this.Pokemon.IsPlaced = false;
                this.Pokemon.Location = new Point();
                this.Pokemon = null;
                this.hasPokemon = false;
            }
        }
    }
}
