using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace pokemon_towerdefense.Models
{
    public abstract class Attack
    {
        public int Damage { get; set; }
        public Bitmap Sprite { get; set; } = null;
        public float Cooldown { get; set; }
        public Pokemon Target { get; set; } = null;
        public bool IsMelee { get; set; } = false;
        public int SpriteIndex = 1;
        public bool StartAttack = false;
        public Point StartPosition = new Point();

        public void ShootAttack(Graphics g, Pokemon attacker)
        {
            if (StartAttack && attacker.target != null)
            {
                Point? targetPos = this.Target.Location.Value;

                Point? attackerPos = attacker.Location.Value;
                if (IsMelee)
                {
                    var dx = targetPos.Value.X - attackerPos.Value.X;
                    var dy = targetPos.Value.Y - attackerPos.Value.Y;
                    
                    StartPosition.X += dx / 8;
                    StartPosition.Y += dy / 8;

                    var pbRect = new Rectangle(StartPosition.X, StartPosition.Y, 66, 69);
                    g.DrawImage(attacker.Sprite, pbRect, 3, 10, 59, 55, GraphicsUnit.Pixel);

                    if (Sprite != null)
                    {
                        var proportion = Sprite.Width / Sprite.Height;
                        Rectangle rect = new Rectangle(StartPosition.X + Sprite.Height/2, StartPosition.Y + Sprite.Height/2,
                            Convert.ToInt16(Sprite.Height * 1.5), Convert.ToInt16(Sprite.Height * 1.5));
                        g.DrawImage(Sprite, rect, Sprite.Height * Convert.ToInt16((SpriteIndex * proportion) / 8), 0, Sprite.Height, Sprite.Height, GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    var proportion = Sprite.Width / Sprite.Height;
                    var dx = targetPos.Value.X - attackerPos.Value.X;
                    var dy = targetPos.Value.Y - attackerPos.Value.Y;

                    StartPosition.X += dx / 8;
                    StartPosition.Y += dy / 8;
                    Rectangle rect = new Rectangle(StartPosition.X, StartPosition.Y, Sprite.Height * 2, Sprite.Height * 2);

                    g.DrawImage(Sprite, rect, Sprite.Height * Convert.ToInt16((SpriteIndex * proportion) / 8) , 0, Sprite.Height, Sprite.Height, GraphicsUnit.Pixel);
                }
                
                if (SpriteIndex >= 8) {
                    SpriteIndex = 0;
                    StartAttack = false;
                }

                SpriteIndex++;
            }
        }
    }

    public class Flamethrower : Attack
    {
        public Flamethrower() 
        {
            this.Damage = 20;
            this.Cooldown = 12;
            this.IsMelee = true;
        }
    }

    public class Ember : Attack
    {
        public Ember()
        {
            this.Damage = 15;
            this.Cooldown = 10;

            this.Sprite = new Bitmap(Bitmap.FromFile(@"..\..\assets\ember-sprite.png"));
        }
    }
    public class Bite : Attack
    {
        public Bite()
        {
            this.Damage = 20;
            this.Cooldown = 10;
            this.IsMelee = true;

            this.Sprite = new Bitmap(Bitmap.FromFile(@"..\..\assets\bite-sprite.png"));
        }
    }
}
