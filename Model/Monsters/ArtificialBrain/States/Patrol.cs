using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CustomProgram
{
    public class Patrol : State
    {
        public override void Run(Oneal oneal)
        {
            Random r = new Random();
            oneal.Move(EntityManager.Entities);
            Thread.Sleep(200);
            int num = r.Next(5);
            if (num == 1)
            {
                oneal.Direction = Direction.W;
            }
            else if (num == 2)
            {
                oneal.Direction = Direction.N;
            }
            else if (num == 3)
            {
                oneal.Direction = Direction.S;
            }
            else
            {
                oneal.Direction = Direction.E;
            }

        }
    }
}
