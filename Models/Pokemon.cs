﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

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
        public int Range = 300;
        public Pokemon target = null;

        public Bitmap Sprite = null;

        public bool IsPlaced = false;
        public int Life = 100;
        public int Speed = 0;
        public bool IsAlive = true;


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

        public void StaticAnimate(Graphics g, Rectangle destRect)
        {
            this.SpeedImage++;
            if (this.SpeedImage >= 6)
            {
                this.ActualImage += 1;
                this.SpeedImage = 0;
            }

            g.DrawImage(Sprite, destRect, 3 + ((ActualImage % 4) * 64), 10, 59, 55, GraphicsUnit.Pixel);
        }

        public void VerifyLevelUp()
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
            VerifyLevelUp();
        }

        public void GiveDamage(Graphics g)
        {
            if(this.target != null)
            {
                if (this.target.IsAlive)
                {
                    this.SelectedAttack.ShootAttack(g, this);
                    this.target.TakeDamage(SelectedAttack.Damage);
                    if (this.target.Life <= 0)
                    {
                        GainXp();
                    }
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
                if (p.IsAlive)
                {
                    distance = this.CalculateDistance(p);
                    if (distance < lastDistance && distance < this.Range)
                    {
                        lastDistance = distance;
                        this.target = p;
                        this.SelectedAttack.Target = this.target;
                    }
                }
            });
        }

        public void TakeDamage(int damage)
        {
            if(this.Life > 0)
                Life -= damage;
            else
            {
                Life = 0;
                IsAlive = false;
            }
        }

        Bitmap last = null;
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

        public void Animate(Graphics graphics)
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

            if (line == 3)
                spriteHeight = 63;

            var pbRect = new Rectangle(Location.Value.X - 8, Location.Value.Y - 10, 66, 69);

            if(this.isWild)
                graphics.DrawImage(Sprite, pbRect, 3 + ((ActualImage % 4) * 64), 10 + (65 * line), 59, 55, GraphicsUnit.Pixel);
            else
            {
                var angle = getAngle();


                if (angle >= 45 && angle < 135)
                    line = 0;
                else if (angle >= -45 && angle < 45)
                    line = 1;
                else if (angle < 45 && angle > -135)
                    line = 3;
                else
                    line = 2;

                graphics.DrawImage(Sprite, pbRect, 3 + ((ActualImage % 4) * 64), 10 + (65 * line), 59, 55, GraphicsUnit.Pixel);
            }
        }
        
        private double? getAngle()
        {
            if(target != null)
            {
                var CA = this.Location.Value.X - this.target.Location.Value.X;
                var CO = this.Location.Value.Y - this.target.Location.Value.Y;

                var radians = Math.Atan2(CO, CA);
                var angle = radians * (180 / Math.PI);
                return angle * -1;
            }
            return null;
        }
    }
}
