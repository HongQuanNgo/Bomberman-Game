using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CustomProgram
{
    public class Flame : Entity
    {
       
        public Flame(Position position) : base(position)
        {
           
        }

        public override void Draw()
        {
           
            Bitmap flameup = SplashKit.LoadBitmap("flameup", "flame_up.png");
            Bitmap flamedown = SplashKit.LoadBitmap("flamedown", "flame_down.png");
            Bitmap flameright = SplashKit.LoadBitmap("flameright", "flame_right.png");
            Bitmap flameleft = SplashKit.LoadBitmap("flameleft", "flame_left.png");
            Bitmap flamecenter = SplashKit.LoadBitmap("flamecenter", "flame_center.png");

            SplashKit.DrawBitmap(flamecenter, Position.X, Position.Y);
            SplashKit.DrawBitmap(flameleft, Position.X - 15, Position.Y);
            SplashKit.DrawBitmap(flameup, Position.X, Position.Y - 15);
            SplashKit.DrawBitmap(flameright, Position.X + 15, Position.Y);
            SplashKit.DrawBitmap(flamedown, Position.X , Position.Y + 15);
        }


        public override List<Entity> GetCollision(List<Entity> list)
        {
            List<Entity> collidedList = new List<Entity>();
            Rectangle rect1 = SplashKit.RectangleFrom(this.Position.X, this.Position.Y - 15, Width, Height * 3);
            Rectangle rect2 = SplashKit.RectangleFrom(this.Position.X - 15, this.Position.Y, Width * 3, Height);
            foreach(Entity i in base.GetEntityInBounds(list, rect1))
            {
                foreach(Entity j in base.GetEntityInBounds(list, rect2))
                {                    
                    if ((i.GetType() == typeof(Player)))
                    {
                        collidedList.Add(i);
                    }
                    else if ((j.GetType() == typeof(Player)))
                    {
                        collidedList.Add(j);
                    }
                    if (i.GetType().IsSubclassOf(typeof(Monster)))
                    {
                        collidedList.Add(i);
                    }
                    else if (j.GetType().IsSubclassOf(typeof(Monster)))
                    {
                        collidedList.Add(j);
                    }
                }
            }
            return collidedList;
        }

    }
    
}
