using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.Threading;

namespace CustomProgram
{
    public class Balloon : Monster
    {
        Bitmap balloon;
        AnimationScript monsterScript; 
        Animation test;
        DrawingOptions opt;
        Thread thread;
        public Balloon(Position position, Direction dir, int speed) : base(position, dir, speed)
        {
            balloon = SplashKit.LoadBitmap("Balloon", "balloon.png");
            balloon.SetCellDetails(16, 16, 2, 4, 7);
            monsterScript = SplashKit.LoadAnimationScript("MonsterScript", "AnimationScript.txt");
            test = monsterScript.CreateAnimation("BalloonGoingWest");
            opt = SplashKit.OptionWithAnimation(test);

            thread = new Thread(Run);
            thread.Start();
        }

        public Balloon() : this(new Position(288,16), Direction.W, 16) { }
        public override void Draw()
        {
            SplashKit.DrawBitmap(balloon, this.Position.X, this.Position.Y, opt);
            test.Update();
            switch (Direction)
            {
                case Direction.W:
                    test.Assign("BalloonGoingWest");
                    break;
                case Direction.E:
                    test.Assign("BalloonGoingEast");
                    break;
                default:
                    break;
            }
        }
        public override void Run()
        { 
            Random r = new Random();
            while (true)
            {
                Move(EntityManager.Entities);
                Thread.Sleep(200);
                int num = r.Next(5);
                if (num == 1)
                {
                    this.Direction = Direction.W;
                }
                else if (num == 2)
                {
                    this.Direction = Direction.N;
                }
                else if (num == 3)
                {
                    this.Direction = Direction.S;
                }
                else
                {
                    this.Direction = Direction.E;
                }
            }
        }
    }
}
