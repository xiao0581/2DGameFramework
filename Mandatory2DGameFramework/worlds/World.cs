using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        private int width;
        private int height;
        private List<Creature> creatures;
        private List<WorldObject> objects;
        private IWorldObjectFactory _worldObjectFactory; 

        public World(int width, int height, IWorldObjectFactory factory)
        {
            this.width = width;
            this.height = height;
            creatures = new List<Creature>();
            objects = new List<WorldObject>();
            _worldObjectFactory = factory; 
        }

        public bool IsPositionValid(int x, int y)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }

        public void AddCreature(Creature creature)
        {
            if (IsPositionValid(creature.X, creature.Y))
            {
                creatures.Add(creature);
                Console.WriteLine($"{creature.Name} was added to the world on ({creature.X}, {creature.Y}).");
            }
            else
            {
                Console.WriteLine("The position is outside the boundaries of the world.");
            }
        }

        public void AddWorldObject(WorldObject obj)
        {
            if (IsPositionValid(obj.X, obj.Y))
            {
                objects.Add(obj);
                Console.WriteLine($"{obj.Name} was added to the world on ({obj.X}, {obj.Y}).");
            }
            else
            {
                Console.WriteLine("The position is outside the boundaries of the world.");
            }
        }

        public void RemoveWorldObject(WorldObject obj)
        {
            objects.Remove(obj);
            Console.WriteLine($"{obj.Name} Removed from the world。");
        }

        public WorldObject? GetWorldObjectAtPosition(int x, int y)
        {
            return objects.FirstOrDefault(obj => obj.X == x && obj.Y == y);
        }

    }
    }
