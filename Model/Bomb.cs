using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using SplashKitSDK;


namespace CustomProgram
{
    public class Bomb : Entity
    {

        Bitmap bomb;
        AnimationScript bombScript;
        Animation test;
        DrawingOptions opt;
        Thread thread;
        static int BOMB_TIME = 2000;
 
        public Bomb(Position position) : base(position)
        {
            bomb = SplashKit.LoadBitmap("bomb", "bomb.png");
            bomb.SetCellDetails(16, 16, 3, 1, 3);
            bombScript = SplashKit.LoadAnimationScript("BombScript", "AnimationScript.txt");
            test = bombScript.CreateAnimation("Exploded");
            opt = SplashKit.OptionWithAnimation(test);
            
            thread = new Thread(Run);
            thread.Start();
        }
 
        public override void Draw()
        {
            SplashKit.DrawBitmap(bomb, this.Position.X, this.Position.Y, opt);
            test.Update();
        }
        public void Run()
        {
            Thread.Sleep(BOMB_TIME);
            EntityManager.Entities.Remove(this);
            Flame flame = new Flame(new Position(this.Position.X, this.Position.Y));
            EntityManager.Entities.Add(flame);
            Thread.Sleep(500);
            EntityManager.Entities.Remove(flame);
        }

    }


}
