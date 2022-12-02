using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Stateless;
using SplashKitSDK;

namespace CustomProgram
{
    public abstract class Monster : MovableObjects
    {
        public Monster(Position position, Direction dir, int speed) : base(position, dir, speed) {}
        public virtual void Run() { }
        public override List<Entity> GetCollision(List<Entity> list)
        {
            List<Entity> collidedList = new List<Entity>();
            Rectangle rect = SplashKit.RectangleFrom(this.Position.X, this.Position.Y, Width, Height);

            foreach (Entity i in list)
            {
                if (SplashKit.RectanglesIntersect(i.GetBounds(), rect))
                {
                    if (i.GetType() == typeof(Player))
                    {
                        collidedList.Add(i);
                    }
                }
            }
            return collidedList;
        }
    }
}
