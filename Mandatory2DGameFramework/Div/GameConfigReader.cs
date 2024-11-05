using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.worlds.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mandatory2DGameFramework.Div
{
    public class GameConfigReader
    {//fff
        private static GameConfigReader _instance;
        private XDocument _config;
        private static readonly MyLogger logger = MyLogger.Instance;

        public static GameConfigReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("Please initialize the config reader with a file path first.");
                }
                return _instance;
            }
        }

        /// <summary>
        /// Private constructor that loads the configuration from the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the XML configuration file.</param>
        private GameConfigReader(string filePath)
        {
            _config = XDocument.Load(filePath);
        }

        /// <summary>
        /// Initializes the singleton instance of GameConfigReader with the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the XML configuration file.</param>
        public static void Initialize(string filePath)
        {
            if (_instance == null)
            {
                _instance = new GameConfigReader(filePath);
            }
        }

        /// <summary>
        /// Gets the loaded configuration as an XDocument.
        /// </summary>
        /// <returns>The XDocument containing the configuration data.</returns>
        public XDocument GetConfig()
        {
            return _config;
        }

        /// <summary>
        /// Gets the dimensions of the world.
        /// </summary>
        public (int width, int height) GetWorldDimensions()
        {
            var worldConfig = _config.Descendants("World").FirstOrDefault();
            if (worldConfig != null)
            {
                int width = int.Parse(worldConfig.Element("Width").Value);
                int height = int.Parse(worldConfig.Element("Height").Value);
                Console.WriteLine($"World created with width: {width} and height: {height}");
                logger.LogInformation($"World created with width: {width} and height: {height}.");
                return (width, height);

            }
            throw new InvalidOperationException("World dimensions not found in configuration.");
        }

        /// <summary>
        /// Initializes all creatures and returns a list of them.
        /// </summary>
        public void InitializeCreatures(World world)
        {
            
            foreach (var creatureData in _config.Descendants("Creature"))
            {
                string name = creatureData.Element("Name").Value;
                string type = creatureData.Element("Type").Value;
                int hitPoint = int.Parse(creatureData.Element("HitPoint").Value);
                int x = int.Parse(creatureData.Element("PositionX").Value);
                int y = int.Parse(creatureData.Element("PositionY").Value);

                Creature newCreature = CreateCreature(name, type, hitPoint, x, y);
                if (newCreature != null)
                {
                    world.AddCreature(newCreature);
                }
            }
            
        }

        /// <summary>
        /// Initializes all world objects and returns a list of them.
        /// </summary>
        public void InitializeWorldObjects(World world,IWorldObjectFactory factory)
        {
            
            foreach (var objData in _config.Descendants("WorldObject"))
            {
                string type = objData.Element("Type").Value;
                string name = objData.Element("Name").Value;
                int value = int.Parse(objData.Element("Value").Value);
                int x = int.Parse(objData.Element("PositionX").Value);
                int y = int.Parse(objData.Element("PositionY").Value);

                var worldObject = factory.CreateWorldObject(type, name, value, x, y);
                if (worldObject != null)
                {
                    world.AddWorldObject(worldObject);
                   
                }
                else
                {
                    Console.WriteLine($"Failed to create WorldObject of type {type} with name {name}.");
                }
            }
           
        }

        /// <summary>
        /// Initializes all actions and executes them in the given world.
        /// </summary>
        public void InitializeActions(World world)
        {
            foreach (var actionElement in _config.Descendants("Action"))
            {
                string attackerName = actionElement.Element("Attacker").Value;
                string actionType = actionElement.Element("Type").Value;

                Creature attacker = world.creatures.FirstOrDefault(c => c.Name == attackerName);

                if (attacker == null)
                {
                    Console.WriteLine($"Creature {attackerName} not found.");
                    logger.LogWarning($"Failed to find creature {attackerName}.");
                    return;
                }

                if (actionType == "Move")
                {
                    int X = int.Parse(actionElement.Element("PositionX").Value);
                    int Y = int.Parse(actionElement.Element("PositionY").Value);
                    attacker.Move(X, Y, world);
                }
                else if (actionType == "Loot")
                {
                    string targetName = actionElement.Element("Target").Value;
                    WorldObject targetObject = world.objects.FirstOrDefault(o => o.Name == targetName);

                    if (targetObject != null)
                    {
                        attacker.Loot(targetObject, world);
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
                    Creature target = world.creatures.FirstOrDefault(c => c.Name == targetName);

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
        }


        /// <summary>
        /// Creates a world object based on its type.
        /// </summary>
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

     


    }
}
