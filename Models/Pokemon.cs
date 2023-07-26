using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

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
        public Type Type { get; set; }
        public bool isWild = true;

        public int SpeedImage = 0;
        public int ActualImage = 0;
        public Attack SelectedAttack {  get; protected set; }
        public List<Attack> Attacks { get; protected set; } = new List<Attack>();
        public Pokemon Evolution = null;
        public int Range = 300;
        public Pokemon target = null;

        public Bitmap Sprite = null;

        public bool IsPlaced = false;
        public int Life = 100;
        public int ActualLife = 100;
        public int Defense = 40;
        public int Power = 40;
        public int Speed = 0;
        public bool IsAlive = true;
        public int XpEvolve = 100;
        public int XpDrop = 0;
        public bool Stealing = false;
        public RareCandy rareCandy;

        public void CollectCandy(List<RareCandy> candies)
        {
            candies.ForEach(c =>
            {
                if (!c.IsStealed && !this.Stealing)
                {
                    int deltaX = c.Position.X - this.Location.Value.X;
                    int deltaY = c.Position.X - this.Location.Value.Y;

                    double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                    if (distance < 50)
                    {
                        c.IsStealed = true;
                        this.rareCandy = c;
                    }
                }
            });
        }

        public virtual Pokemon Clone(int? newLevel = null, bool? isWild = null)
        {
            Pokemon clonedPokemon = (Pokemon)this.MemberwiseClone();

            if(this.Location != null)
            {
                clonedPokemon.Location = new Point(Location.Value.X, Location.Value.Y);
            }

            clonedPokemon.Attacks = new List<Attack>(Attacks.Select(a => a));
            clonedPokemon.SelectedAttack = this.SelectedAttack.Clone();

            if (Evolution != null)
                clonedPokemon.Evolution = Evolution.Clone();

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

        public void UpdateStatus()
        {
            Life += 3;
            Power += 3;
            Defense += 3;
            XpEvolve += Convert.ToInt16(XpEvolve * 0.15);
        }

        public void VerifyLevelUp()
        {
            if (Xp >= XpEvolve)
            {
                Level += 1;
                VerifyEvolve();
                Xp = Xp - XpEvolve;
                UpdateStatus();
                if (Xp >= XpEvolve)
                    VerifyLevelUp();
            }
        }

        private void VerifyEvolve()
        {
            if (Evolution != null)
            {
                if (this.Level >= Evolution.minLevel)
                {
                    this.Name = Evolution.Name;
                    this.Range = Evolution.Range;
                    this.Tier = Evolution.Tier;
                    this.Life = Evolution.Life;
                    this.Power = Evolution.Power;
                    this.Defense = Evolution.Defense;
                    this.Speed = Evolution.Speed;
                    this.Sprite = Evolution.Sprite;
                    this.Attacks = Evolution.Attacks;
                    this.minLevel = Evolution.minLevel;
                    this.Evolution = Evolution.Evolution;
                }
            }
        }

        public void GainXp(int dropXp)
        {
            Xp += dropXp;
            VerifyLevelUp();
        }

        public void GiveDamage(Graphics g)
        {
            if(this.target != null)
            {
                if (this.target.IsAlive)
                {
                    this.SelectedAttack.ShootAttack(g, this);
                    this.target.TakeDamage(SelectedAttack.Damage + Power);
                    if (!this.target.IsAlive)
                    {
                        GainXp(this.target.XpDrop);
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
            if(this.ActualLife > 0)
                ActualLife -= (damage - (Defense/10));
            if(this.ActualLife <= 0)
            {
                ActualLife = 0;
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

                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = 0.5f;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                if (SelectedAttack.IsAttacking && SelectedAttack.IsMelee)
                    graphics.DrawImage(Sprite, pbRect, 3 + ((ActualImage % 4) * 64), 10 + (65 * line), 59, 55, GraphicsUnit.Pixel, attributes);
                else
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
