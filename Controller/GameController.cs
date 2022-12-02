using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;


namespace CustomProgram
{
    public class GameController
    {
        private List<Player> _players;
        private List<Monster> _monsters;

        public GameController(List<Player> players, List<Monster> monsters)
        {
            _players = players;
            _monsters = monsters;
        }

        public void Update(List<Entity> list)
        {
            foreach (Player player in _players)
            {
                if (SplashKit.KeyTyped(KeyCode.WKey))
                {
                    player.Direction = Direction.N;
                    player.Move(list);
                }

                else if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    player.Direction = Direction.S;
                    player.Move(list);  
                }

                else if (SplashKit.KeyTyped(KeyCode.AKey))
                {
                    player.Direction = Direction.W;
                    player.Move(list);
                }

                else if (SplashKit.KeyTyped(KeyCode.DKey))
                {
                    player.Direction = Direction.E;
                    player.Move(list);  
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    player.PutBomb(list);
                }
                player.Die(list);
            }
            foreach(Monster monster in _monsters)
            {
                monster.Die(list);
            }
            
        }
    }
}
