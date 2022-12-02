using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.Threading;
using System.Diagnostics;

namespace CustomProgram
{
    public class Oneal : Monster
    {
        Bitmap oneal;
        AnimationScript monsterScript;
        Animation test;
        DrawingOptions opt;
        Thread thread;
        ArtificialBrain aiBrain;

        public Oneal(Position position, Direction dir, int speed, int hp) : base(position, dir, speed)
        {
            aiBrain = new ArtificialBrain(this);

            oneal = SplashKit.LoadBitmap("Oneal", "oneal.png");
            oneal.SetCellDetails(16, 16, 2, 4, 7);
            monsterScript = SplashKit.LoadAnimationScript("MonsterScript", "AnimationScript.txt");
            test = monsterScript.CreateAnimation("OnealGoingWest");
            opt = SplashKit.OptionWithAnimation(test);
            thread = new Thread(Run);
            thread.Start();
        }
        public Oneal() : this(new Position(16, 208), Direction.W, 16, 4) { }
        public override void Draw()
        {
            SplashKit.DrawBitmap(oneal, this.Position.X, this.Position.Y, opt);
            test.Update();
            switch (Direction)
            {
                case Direction.W:
                    test.Assign("OnealGoingWest");
                    break;
                case Direction.E:
                    test.Assign("OnealGoingEast");
                    break;
                default:
                    break;
            }
        }

        public override void Run()
        {   
            while(true)
            {    
                aiBrain.Update();
            }    
        }
    }
}
