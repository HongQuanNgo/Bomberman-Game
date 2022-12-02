using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CustomProgram
{
    public class Attack : State
    {   
        public override void Run(Oneal oneal)
        {
            oneal.Move(EntityManager.Entities);
            Thread.Sleep(230);
        }
    }
}
