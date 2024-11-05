using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.Div;
using Mandatory2DGameFramework.worlds.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        public int width;
        public int height;
        public List<Creature> creatures;
        public List<WorldObject> objects;
        public IWorldObjectFactory _worldObjectFactory; 
        public static readonly MyLogger logger = MyLogger.Instance;

        /// <summary>
        /// Initializes a new instance of the World class with specified dimensions and a factory for creating world objects.
        /// </summary>
        /// <param name="width">The width of the world, representing the horizontal size of the game area.</param>
        /// <param name="height">The height of the world, representing the vertical size of the game area.</param>
        /// <param name="factory">An instance of IWorldObjectFactory used to create objects within the world.</param>
        public World(int width, int height, IWorldObjectFactory factory)
        {
            this.width = width;
            this.height = height;
            creatures = new List<Creature>();
            objects = new List<WorldObject>();
            _worldObjectFactory = factory;
            Console.WriteLine($"World created with width: {width} and height: {height}");
            
        }
        /// <summary>
        /// Default constructor for the World class, initializes world components and configures the world from a configuration file.
        /// </summary>
        public World()
        {

            var factory = new WorldObjectFactory();

            creatures = new List<Creature>();
            objects = new List<WorldObject>();
            var configReader = GameConfigReader.Instance;
            (width, height) = configReader.GetWorldDimensions();



            configReader.InitializeCreatures(this);
            configReader.InitializeWorldObjects(this, factory);


            configReader.InitializeActions(this);

            logger.Close();

        }



        /// <summary>
        /// Checks if the given position is valid within the world boundaries.
        /// </summary>
        /// <param name="x">The x-coordinate of the position.</param>
        /// <param name="y">The y-coordinate of the position.</param>
        /// <returns>True if the position is valid, otherwise false.</returns>
        public bool IsPositionValid(int x, int y)
        {
          
            return x >= 0 && y >= 0 && x < width && y < height;
        }
        /// <summary>
        /// Adds a creature to the world if its position is valid.
        /// </summary>
        /// <param name="creature">The creature to add.</param>
        public void AddCreature(Creature creature)
        {
           
            if (IsPositionValid(creature.X, creature.Y))
            {
                creatures.Add(creature);
                Console.WriteLine($"{creature.Name} was added to the world on ({creature.X}, {creature.Y}).");
                logger.LogInformation($"{creature.Name} was added to the world at ({creature.X}, {creature.Y}).");

            }
            else
            {
                Console.WriteLine("The position is outside the boundaries of the world.");
                logger.LogWarning($"Failed to add {creature.Name}. Position ({creature.X}, {creature.Y}) is out of bounds.");

            }
        }
        /// <summary>
        /// Adds a world object to the world if its position is valid.
        /// </summary>
        /// <param name="obj">The world object to add.</param>
        public void AddWorldObject(WorldObject obj)
        {
            if (IsPositionValid(obj.X, obj.Y))
            {
                objects.Add(obj);
                Console.WriteLine($"{obj.Name} was added to the world at ({obj.X}, {obj.Y}).");
                logger.LogInformation($"{obj.Name} was added to the world at ({obj.X}, {obj.Y}).");

            }
            else
            {
                Console.WriteLine("The position is outside the boundaries of the world.");
                logger.LogWarning($"Failed to add {obj.Name}. Position ({obj.X}, {obj.Y}) is out of bounds.");

            }
        }
        /// <summary>
        /// Removes a world object from the world.
        /// </summary>
        /// <param name="obj">The world object to remove.</param>
        public void RemoveWorldObject(WorldObject obj)
        {
            objects.Remove(obj);
            Console.WriteLine($"{obj.Name} Removed from the world。");
        }
        /// <summary>
        /// Gets the world object at the specified position.
        /// </summary>
        /// <param name="x">The x-coordinate of the position.</param>
        /// <param name="y">The y-coordinate of the position.</param>
        /// <returns>The world object at the specified position, or null if no object
        public WorldObject? GetWorldObjectAtPosition(int x, int y)
        {
            return objects.FirstOrDefault(obj => obj.X == x && obj.Y == y);
        }

    }

    }
