using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SplashKitSDK;
namespace CustomProgram
{

    public class Program
    {

        public static void Main()
        {
            Window window = new Window("Bomberman", 304, 240);
            Game game = new Game();
            game.State = Game.GameState.Start;

            MainView viewer = new MainView(EntityManager.Entities);
            viewer.CreateMap();
            Player player = new Player();
            EntityManager.Players.Add(player);
            EntityManager.Entities.AddRange(EntityManager.Players);
 
            Monster balloon = new Balloon();
            Monster oneal = new Oneal();
            Monster flyer = new Flyer();
            EntityManager.Monsters.Add(flyer);
            EntityManager.Monsters.Add(balloon);
            EntityManager.Monsters.Add(oneal);
            EntityManager.Entities.AddRange(EntityManager.Monsters);

            GameController controller = new GameController(EntityManager.Players, EntityManager.Monsters);
  
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                game.KeyHandle();
                game.Draw();
                if (game.State == Game.GameState.OnGoing)
                {
                    viewer.Render();
                    controller.Update(EntityManager.Entities);
                    if (!EntityManager.Entities.Contains(player))
                    {
                        game.State = Game.GameState.Lose;
                    }
                    if (!EntityManager.Entities.OfType<Monster>().Any())
                    {
                        game.State = Game.GameState.Win;
                    }
                }
                
                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("Bomberman"));

        }
    }
}

