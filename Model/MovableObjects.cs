using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace CustomProgram
{
    public class MovableObjects:Entity
    {
        
        private Direction _direction;
        private int _speed;
        
        public MovableObjects(Position position, Direction dir, int speed):base(position)
        {
            _direction = dir;
            _speed = speed;

        }

        public Direction Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }
        
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public override bool GetMoveCollision(List<Entity> list, Rectangle rect)
        {
            bool collisionable = false;
            foreach (Entity i in GetEntityInBounds(list, rect))
            {
                if (i.GetType() == typeof(Wall) || i.GetType() == typeof(Bomb) || i.GetType().IsSubclassOf(typeof(Monster)) || i.GetType() == typeof(Player))
                {
                    collisionable = true;
                }
            }
            return collisionable;
        }
        public override List<Entity> GetEntityInBounds(List<Entity> list, Rectangle rect)
        {
            List<Entity> InBoundList = new List<Entity>();
            foreach (Entity i in list.ToList())
            {
                if (i.GetBounds().Equals(rect))
                {
                    InBoundList.Add(i);
                }
            }
            return InBoundList;
        }
        public virtual void Move(List<Entity> list)
        {
            Rectangle rect = new Rectangle();
            switch (Direction)
            {
                case Direction.N:
                    rect = SplashKit.RectangleFrom(Position.X, Position.Y - Speed, Width, Height);
                    break;
                case Direction.S:
                    rect = SplashKit.RectangleFrom(Position.X, Position.Y + Speed, Width, Height);
                    break;
                case Direction.E:
                    rect = SplashKit.RectangleFrom(Position.X + Speed, Position.Y, Width, Height);
                    break;
                case Direction.W:
                    rect = SplashKit.RectangleFrom(Position.X - Speed, Position.Y, Width, Height);
                    break;
                default:
                    break;
            }

            if (GetMoveCollision(list, rect) == true)
            {
                return;
            }

            switch (Direction)
            {
                case Direction.N:
                    Position.GoNorth(Speed);
                    break;
                case Direction.S:
                    Position.GoSouth(Speed);
                    break;
                case Direction.E:
                    Position.GoEast(Speed);
                    break;
                case Direction.W:
                    Position.GoWest(Speed);
                    break;
                default:
                    break;
            }
        }

        public virtual void Die(List<Entity> list)
        {
            foreach (Entity i in list.ToList())
            {
                if (i.GetType() == typeof(Flame))
                {
                    if (i.GetCollision(list).Contains(this))
                    {
                        Console.WriteLine("collided");
                        list.Remove(this);
                    }
                }
            }
        }
    }
}
