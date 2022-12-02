using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram
{
    public class Grass : Entity
    {
        public Grass(Position position) : base(position)
        {

        }

        public override void Draw()
        {
            Bitmap grass = SplashKit.LoadBitmap("grass", "grass.png");
            SplashKit.DrawBitmap(grass, this.Position.X, this.Position.Y);
        }
    }
}
