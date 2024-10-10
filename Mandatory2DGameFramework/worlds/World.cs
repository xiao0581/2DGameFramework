using Mandatory2DGameFramework.model.Cretures;
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

        public World(int width, int height)
        {
            this.width = width;
            this.height = height;
            creatures = new List<Creature>();
            objects = new List<WorldObject>();
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
                Console.WriteLine($"{creature.Name} blev tilføjet til verden på ({creature.X}, {creature.Y}).");
            }
            else
            {
                Console.WriteLine("Positionen er uden for verdenens grænser.");
            }
        }

        public void AddWorldObject(WorldObject obj)
        {
            if (IsPositionValid(obj.X, obj.Y))
            {
                objects.Add(obj);
                Console.WriteLine($"{obj.Name} blev tilføjet til verden på ({obj.X}, {obj.Y}).");
            }
            else
            {
                Console.WriteLine("Positionen er uden for verdenens grænser.");
            }
        }

        public void RemoveWorldObject(WorldObject obj)
        {
            objects.Remove(obj);
            Console.WriteLine($"{obj.Name} 已从世界中移除。");
        }

        public List<WorldObject> GetWorldObjectsAtPosition(int x, int y)
        {
            List<WorldObject> result = new List<WorldObject>();
            foreach (var obj in objects)
            {
                if (obj.X == x && obj.Y == y)
                {
                    result.Add(obj);
                }
            }
            return result;
        }
    }

}
