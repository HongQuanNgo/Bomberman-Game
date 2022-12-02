using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace CustomProgram
{
    public abstract class Entity
    {
        private Position _position;
        private int _width;
        private int _height;
        public Entity(Position position)
        {
            _position = position;
            _width = 16;
            _height = 16;
    }

        public Position Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
       
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public virtual void Draw() { }

        public virtual bool GetMoveCollision(List<Entity> list, Rectangle rect)
        {
            return true;
        }
        public virtual List<Entity> GetCollision(List<Entity> list) 
        {
            return list;
        }
        public virtual List<Entity> GetEntityInBounds(List<Entity> list, Rectangle rect)
        {
            List<Entity> InBoundList = new List<Entity>();
            foreach (Entity i in list.ToList())
            {
                if (SplashKit.RectanglesIntersect(i.GetBounds(), rect))
                {
                    InBoundList.Add(i);
                }
            }
            return InBoundList;
        }
        public virtual Rectangle GetBounds()
        {
            Rectangle rect = SplashKit.RectangleFrom(_position.X, _position.Y, _width, _height);
            return rect;
        }
    }
}
