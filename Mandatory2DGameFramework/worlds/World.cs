using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.Div;
using Mandatory2DGameFramework.worlds.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        private int width;
        private int height; 
        private List<Creature> creatures;
        private List<WorldObject> objects;
        private IWorldObjectFactory _worldObjectFactory; 
        private static readonly MyLogger logger = MyLogger.Instance;

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
            
            _worldObjectFactory = new WorldObjectFactory(); 

            creatures = new List<Creature>();
            objects = new List<WorldObject>();

           
            var config = GameConfigReader.Instance.GetConfig();
            InitializeFromConfig(config);
            logger.Close();
        }

        /// <summary>
        /// confread from config file
        /// </summary>
        /// <param name="config"></param>
        public void InitializeFromConfig(XDocument config)
        {
            var worldConfig = config.Descendants("World").FirstOrDefault();
            if (worldConfig != null)
            {
                width = int.Parse(worldConfig.Element("Width").Value);
                height = int.Parse(worldConfig.Element("Height").Value);
                Console.WriteLine($"World created with width: {width} and height: {height}");
                logger.LogInformation($"World created with width: {width} and height: {height}.");
            }

           
            foreach (var creature in config.Descendants("Creature"))
            {
                string name = creature.Element("Name").Value;
                string type = creature.Element("Type").Value;
                int hitPoint = int.Parse(creature.Element("HitPoint").Value);
                int x = int.Parse(creature.Element("PositionX").Value);
                int y = int.Parse(creature.Element("PositionY").Value);

                Creature newCreature = CreateCreature(name, type, hitPoint, x, y);
                if (newCreature != null)
                {
                    AddCreature(newCreature);
                }
            }

          
            foreach (var obj in config.Descendants("WorldObject"))
            {
                string type = obj.Element("Type").Value;
                string name = obj.Element("Name").Value;
                int value = int.Parse(obj.Element("Value").Value);
                int x = int.Parse(obj.Element("PositionX").Value);
                int y = int.Parse(obj.Element("PositionY").Value);

                AddWorldObject(_worldObjectFactory.CreateWorldObject(type, name, value, x, y));
            }

         
            foreach (var action in config.Descendants("Action"))
            {
                HandleAction(action);
            }

          
        }
        /// <summary>
        /// Initializes the World from a given XML configuration.
        /// </summary>
        /// <param name="config">The XML document containing world configuration data.</param>
        public void HandleAction(XElement actionElement)
        {
            string attackerName = actionElement.Element("Attacker").Value;
            string actionType = actionElement.Element("Type").Value;

            Creature attacker = creatures.FirstOrDefault(c => c.Name == attackerName);

            if (attacker == null)
            {
                Console.WriteLine($"Creature {attackerName} not found.");
                logger.LogWarning($"Failed to find creature {attackerName}.");
                return;
            }

            if (actionType == "Move")
            {
                int targetX = int.Parse(actionElement.Element("PositionX").Value);
                int targetY = int.Parse(actionElement.Element("PositionY").Value);
                attacker.Move(targetX, targetY, this);
            }
            else if (actionType == "Loot")
            {
                string targetName = actionElement.Element("Target").Value;
                WorldObject targetObject = objects.FirstOrDefault(o => o.Name == targetName);

                if (targetObject != null)
                {
                    attacker.Loot(targetObject, this);
                }
                else
                {
                    Console.WriteLine($"WorldObject {targetName} not found.");
                   logger.LogWarning($"Failed to loot {targetName}. Object not found.");
                }
            }
            else if (actionType == "Attack")
            {
                string targetName = actionElement.Element("Target").Value;
                Creature target = creatures.FirstOrDefault(c => c.Name == targetName);

                if (target != null)
                {
                    attacker.Hit(target);
                }
                else
                {
                    Console.WriteLine($"Creature {targetName} not found.");
                    logger.LogWarning($"Failed to attack {targetName}. Creature not found.");

                }
            }
        }
        /// <summary>
        /// Creates a creature based on the provided type, name, hit points, and position.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <param name="type">The type of the creature (e.g., "Warrior", "Mage").</param>
        /// <param name="hitPoint">The hit points of the creature.</param>
        /// <param name="x">The x-coordinate of the creature's initial position.</param>
        /// <param name="y">The y-coordinate of the creature's initial position.</param>
        /// <returns>Returns a new instance of a Creature if the type is recognized, otherwise returns null.</returns>
        public Creature CreateCreature(string name, string type, int hitPoint, int x, int y)
        {
            if (type == "Warrior")
            {
                return new Warrior(name, hitPoint, x, y);
            }
            else if (type == "Mage")
            {
                return new Mage(name, hitPoint, x, y);
            }
            else
            {
                Console.WriteLine($"Unknown creature type: {type}");
                return null;
            }
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
