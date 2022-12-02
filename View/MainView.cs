using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomProgram
{

    public class MainView 
    {
        public static int WIDTH = 19;
        public static int HEIGHT = 15;
        private List<Entity> _entities;
 
        public MainView(List<Entity> entities)
        {
            _entities = entities;
        }


        public void CreateMap()
        {
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    Entity stillObject;
                    if (j == 0 || j == HEIGHT - 1 || i == 0 || i == WIDTH - 1 || ((i % 2 == 0) && (j % 2 == 0)))
                    {
                        stillObject = new Wall(new Position(i * 16, j * 16));
                    }
                    else
                    {
                        stillObject = new Grass(new Position(i * 16, j * 16));
                    }

                    _entities.Add(stillObject);
                }
            }
        }

        public void Render()
        {
            foreach (Entity i in _entities.ToList())
            {
                i.Draw();
            }
            
        }

        
    }
}
