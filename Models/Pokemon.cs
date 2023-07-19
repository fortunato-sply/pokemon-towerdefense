using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_towerdefense.Models
{
    public abstract class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Point? Location { get; set; } = null;
        public int Xp { get; protected set; } = 0;
        protected int minLevel { get; set; }
        public int Tier { get; set; }
        public Attack SelectedAttack {  get; protected set; }
        public List<Attack> Attacks { get; protected set; } = new List<Attack>();
        public List<Pokemon> Evolutions = null;
        public Bitmap Sprite = null;
        public bool IsPlaced = false;

        public virtual Pokemon Clone(int? newLevel = null)
        {
            Pokemon clonedPokemon = (Pokemon)this.MemberwiseClone();

            if (Location.HasValue)
                clonedPokemon.Location = new Point(Location.Value.X, Location.Value.Y);

            clonedPokemon.Attacks = new List<Attack>(Attacks.Select(a => a));

            if (Evolutions != null)
                clonedPokemon.Evolutions = new List<Pokemon>(Evolutions.Select(p => (Pokemon)p.Clone()));

            // Certifique-se de que a imagem é clonada profundamente, pois é uma referência ao Bitmap
            if (Sprite != null)
                clonedPokemon.Sprite = (Bitmap)Sprite.Clone();

            if (newLevel.HasValue)
                clonedPokemon.Level = newLevel.Value;

            return clonedPokemon;
        }

        public void LevelUp()
        {

        }

        public void GiveDamage()
        {

        }
    }
}
