using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SplashKitSDK;
//a library that supports FSM 
//Finite State Machine
using Stateless;

namespace CustomProgram
{
    public class ArtificialBrain
    {
        private StateMachine<StatesEnum, TriggersEnum> machine;
        private Oneal _oneal;
        public ArtificialBrain(Oneal oneal)
        {
            _oneal = oneal;
            machine = new StateMachine<StatesEnum, TriggersEnum>(StatesEnum.Patrol);
            machine.Configure(StatesEnum.Patrol)
                .Permit(TriggersEnum.PlayerWithinRange, StatesEnum.Attack)
                .Ignore(TriggersEnum.PlayerOutOfRange);
            machine.Configure(StatesEnum.Attack)
                .Permit(TriggersEnum.PlayerOutOfRange, StatesEnum.Patrol)
                .Ignore(TriggersEnum.PlayerWithinRange);
        }
        public StateMachine<StatesEnum, TriggersEnum> Machine
        {
            get
            {
                return machine;
            }
            set
            {
                machine = value;
            }
        }
        
        public bool WithinRange()
        {
            bool withinRange = false;
            int min = 0;
            Rectangle rect = new Rectangle();
            List<Entity> collidedList = new List<Entity>();
            foreach (Entity i in EntityManager.Entities.ToList())
            {
                if (i.GetType() != typeof(Grass))
                {
                    switch (_oneal.Direction)
                    {
                        case Direction.N or Direction.S:
                            rect = SplashKit.RectangleFrom(_oneal.Position.X, _oneal.Position.Y, 16, 16 * MainView.HEIGHT);
                            if (SplashKit.RectanglesIntersect(i.GetBounds(), rect) && i.Position.X == _oneal.Position.X)
                            {
                                collidedList.Add(i);
                            }
                            foreach (Entity j in collidedList)
                            {
                                min = Math.Abs(collidedList[0].Position.Y - _oneal.Position.Y);
                                int num = Math.Abs(j.Position.Y - _oneal.Position.Y);
                                if (num < min)
                                {
                                    min = num;
                                }

                            }
                            collidedList.Clear();
                            rect = SplashKit.RectangleFrom(_oneal.Position.X, _oneal.Position.Y, 16, min);
                            
                            break;

                        case Direction.W or Direction.E:
                            rect = SplashKit.RectangleFrom(_oneal.Position.X, _oneal.Position.Y, 16 * MainView.WIDTH, 16);
                            if (SplashKit.RectanglesIntersect(i.GetBounds(), rect) && i.Position.Y == _oneal.Position.Y)
                            {
                                collidedList.Add(i);
                            }
                            foreach (Entity j in collidedList)
                            {
                                min = Math.Abs(collidedList[0].Position.X - _oneal.Position.X);
                                int num = Math.Abs(j.Position.X - _oneal.Position.X);
                                if (num < min)
                                {
                                    min = num;
                                }
                            }
                            collidedList.Clear();
                            rect = SplashKit.RectangleFrom(_oneal.Position.X, _oneal.Position.Y, min, 16);
                            
                            break;
                    }
                    if (i.GetType() == typeof(Player))
                    {
                        if (SplashKit.PointPointDistance(SplashKit.RectangleCenter(i.GetBounds()), SplashKit.RectangleCenter(rect)) <= 48)
                        {
                            withinRange = true;
                            if  (_oneal.Position.X == i.Position.X)
                            {
                                if (_oneal.Position.Y > i.Position.Y)
                                {
                                    _oneal.Direction = Direction.N;
                                }
                                if (_oneal.Position.Y < i.Position.Y)
                                {
                                    _oneal.Direction = Direction.S;
                                }
                            }
                            if (_oneal.Position.Y == i.Position.Y)
                            {
                                if (_oneal.Position.X > i.Position.X)
                                {
                                    _oneal.Direction = Direction.W;
                                }
                                if (_oneal.Position.X < i.Position.X)
                                {
                                    _oneal.Direction = Direction.E;
                                }
                            }
                        }
                    }
                }         
            }
            return withinRange;
        }
        public void PlayerWithinRangeTrigger()
        {
            machine.Fire(TriggersEnum.PlayerWithinRange);
        }
        public void PlayerOutOfRangeTrigger()
        {
            machine.Fire(TriggersEnum.PlayerOutOfRange);
        }
      
        public void Update()
        {
            State state;
            if (WithinRange())
            {
                PlayerWithinRangeTrigger();
            }
            else if (!WithinRange())
            {
                PlayerOutOfRangeTrigger();
            }

            if (machine.State == StatesEnum.Attack)
            {
                state = new Attack();
            }
            else
            {
                state = new Patrol();
            }
            state.Run(_oneal);
            Console.WriteLine(machine.State);
            Console.WriteLine(WithinRange());
            Console.WriteLine(_oneal.Direction);
        }
    }
}
