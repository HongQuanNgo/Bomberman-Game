using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.Threading;

namespace CustomProgram
{
    public class Flyer : Monster
    {
        Bitmap flyer;
        AnimationScript monsterScript;
        Animation test;
        DrawingOptions opt;
        Thread thread;
        public Flyer(Position position, Direction dir, int speed) : base(position, dir, speed)
        {
            flyer = SplashKit.LoadBitmap("Flyer", "flyer.png");
            flyer.SetCellDetails(16, 16, 4, 1, 4);
            monsterScript = SplashKit.LoadAnimationScript("MonsterScript", "AnimationScript.txt");
            test = monsterScript.CreateAnimation("FlyerFlying");
            opt = SplashKit.OptionWithAnimation(test);

            thread = new Thread(Run);
            thread.Start();
        }

        public Flyer() : this(new Position(16, 112), Direction.E, 16) { }
        public override void Draw()
        {
            SplashKit.DrawBitmap(flyer, this.Position.X, this.Position.Y, opt);
            test.Update();
            
        }
        public override void Run()
        {
            while (true)
            {
                Move(EntityManager.Entities);
                Thread.Sleep(150);
                
                if (this.Position.X == (MainView.WIDTH - 2) * 16)
                {
                    this.Direction = Direction.W;
                }
                if (this.Position.X == 16)
                {
                    this.Direction = Direction.E;
                }
            }
        }
    }
}
