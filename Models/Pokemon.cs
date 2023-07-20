using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon_towerdefense.Models
{
    public abstract class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int SpeedX { get; set; } = 0;
        public int SpeedY { get; set; } = 0;
        public int PathPoint { get; set; } = 0;
        public Point? Location { get; set; } = null;
        public int Xp { get; protected set; } = 0;
        protected int minLevel { get; set; }
        public int Tier { get; set; }

        public bool isWild = true;

        public int SpeedImage = 0;
        public int ActualImage = 0;
        public Attack SelectedAttack {  get; protected set; }
        public List<Attack> Attacks { get; protected set; } = new List<Attack>();
        public List<Pokemon> Evolutions = null;
        public int Range = 200;
        private Pokemon target = null;

        public Bitmap Sprite = null;

        public bool IsPlaced = false;
        public int Life = 100;
        public int Speed = 0;


        public virtual Pokemon Clone(int? newLevel = null, bool? isWild = null)
        {
            Pokemon clonedPokemon = (Pokemon)this.MemberwiseClone();

            if(this.Location != null)
            {
                clonedPokemon.Location = new Point(Location.Value.X, Location.Value.Y);
            }

            clonedPokemon.Attacks = new List<Attack>(Attacks.Select(a => a));

            if (Evolutions != null)
                clonedPokemon.Evolutions = new List<Pokemon>(Evolutions.Select(p => (Pokemon)p.Clone()));

            // Certifique-se de que a imagem é clonada profundamente, pois é uma referência ao Bitmap
            if (Sprite != null)
                clonedPokemon.Sprite = (Bitmap)Sprite.Clone();

            if (newLevel.HasValue)
                clonedPokemon.Level = newLevel.Value;

            if(isWild != null)
                clonedPokemon.isWild = isWild.Value;

            return clonedPokemon;
        }

        public void LevelUp()
        {
            if (Xp >= 100)
            {
                Level += Xp/100;
                Xp = Xp % 100;
            }
        }

        public void GainXp()
        {
            Xp += 5;
        }

        public void GiveDamage()
        {
            if(target != null)
            {
                this.target.TakeDamage(SelectedAttack.Damage);
                if (this.target.Life <= 0)
                {
                    MessageBox.Show("morreuai");
                    GainXp();
                }
            }
        }
        public void selectTarget(List<Pokemon> pokemons)
        {
            this.target = null;
            double distance = 0;
            double lastDistance = 2000;
            pokemons.ForEach(p =>
            {
                distance = this.CalculateDistance(p);
                if (distance < lastDistance && distance < this.Range)
                {
                    lastDistance = distance;
                    this.target = p;
                }
            });
        }

        public void TakeDamage(int damage)
        {
            Life -= damage;
        }


        private double CalculateDistance(Pokemon target)
        {
            if(this.Location != null)
            {
                int deltaX = target.Location.Value.X - this.Location.Value.X;
                int deltaY = target.Location.Value.Y - this.Location.Value.Y;
                double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                return distance;
            }

            return 0;
        }

        public Bitmap Animate()
        {
            int line = 0;

            if(this.SpeedX != 0)
            {
                if (this.SpeedX > 0)
                    line = 2;
                else
                    line = 1;
            }
            else if(this.SpeedY != 0)
            {
                if (this.SpeedY > 0)
                    line = 0;
                else
                    line = 3;
            }

            int spriteWidth = 59;
            int spriteHeight = 65;

            var imgRect = new Rectangle(0, line * spriteHeight, this.Sprite.Width, spriteHeight);
            Bitmap croppedSprite = this.Sprite.Clone(imgRect, this.Sprite.PixelFormat);

            return croppedSprite;
        }
    }
}
