using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public static class EntityManager
    {
        static List<Entity> stillObjects = new List<Entity>();
        static List<Monster> monsters = new List<Monster>();
        static List<Player> players = new List<Player>();
        static List<Entity> entities = new List<Entity>();
        
        public static List<Entity> StillObjects
        {
            get
            {
                return stillObjects;
            }
            set
            {
                stillObjects = value;
            }
        }
        public static List<Monster> Monsters
        {
            get
            {
                return monsters;
            }
            set
            {
                monsters = value;
            }
        }
        public static List<Player> Players
        {
            get
            {
                return players;
            }
            set
            {
                players = value;
            }
        }
        public static List<Entity> Entities
        {
            get
            {
                return entities;
            }
            set
            {
                entities = value;
            }
        }
    }
}
