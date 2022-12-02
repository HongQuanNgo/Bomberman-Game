using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace CustomProgram
{
    public class Wall : Entity
    {
        public Wall(Position position):base(position)
        {

        }

        public override void Draw()
        {
            Bitmap wall = SplashKit.LoadBitmap("wall", "wall.png");
            SplashKit.DrawBitmap(wall, this.Position.X, this.Position.Y);
        }

    }
}
