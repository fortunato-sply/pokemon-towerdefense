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
        public Bitmap[] Sprites { get; set; }
        public float Cooldown { get; set; }
        public Pokemon Target { get; set; } = null;
        public bool IsMelee { get; set; }
        public int SpriteIndex = 1;
        public bool StartAttack = false;
        public Point StartPosition = new Point();

        public void ShootAttack(Graphics g, Pokemon attacker)
        {
            if (StartAttack && this.Target != null)
            {
                Point? targetPos = this.Target.Location.Value;

                if (IsMelee)
                {
                    Point? attackerPos = attacker.Location.Value;

                    var dx = targetPos.Value.X - attackerPos.Value.X;
                    var dy = targetPos.Value.Y - attackerPos.Value.Y;

                    StartPosition.X += dx / 8;
                    StartPosition.Y += dy / 8;
                    var pbRect = new Rectangle(StartPosition.X, StartPosition.Y, 66, 69);
                    g.DrawImage(attacker.Sprite, pbRect, 3, 10, 59, 55, GraphicsUnit.Pixel);
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
}
