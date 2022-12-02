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
    public class Player : MovableObjects
    {
        Bitmap player;
        AnimationScript playerScript;
        Animation test;
        DrawingOptions opt;
        public Player(Position position, Direction dir, int speed) : base(position, dir, speed) 
        {
            player = SplashKit.LoadBitmap("player", "player2.bmp");
            player.SetCellDetails(16, 16, 3, 4, 12);

            playerScript = SplashKit.LoadAnimationScript("PlayerScript", "AnimationScript.txt");
            test = playerScript.CreateAnimation("Idle");
            opt = SplashKit.OptionWithAnimation(test);
        }
        public Player() : this(new Position(16, 16), Direction.N, 16) { }
       
        public override void Draw()
        {
            SplashKit.DrawBitmap(player, this.Position.X, this.Position.Y, opt);
            test.Update();
            switch (Direction)
            {
                case Direction.N:
                    test.Assign("GoingNorth");
                    break;
                case Direction.S:
                    test.Assign("GoingSouth");
                    break;
                case Direction.W:
                    test.Assign("GoingWest");
                    break;
                case Direction.E:
                    test.Assign("GoingEast");
                    break;
                default:
                    break;
            }
        }
        public void PutBomb(List<Entity> list)
        {
            Bomb bomb = new Bomb(new Position(this.Position.X, this.Position.Y));
            list.Add(bomb);
        }

        public override void Die(List<Entity> list)
        {
            foreach (Entity i in list.ToList())
            {
                if ((i.GetType() == typeof(Flame)) || (i.GetType().IsSubclassOf(typeof(Monster))))
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
