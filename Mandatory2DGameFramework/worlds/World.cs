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

        public World(int width, int height, IWorldObjectFactory factory)
        {
            this.width = width;
            this.height = height;
            creatures = new List<Creature>();
            objects = new List<WorldObject>();
            _worldObjectFactory = factory;
            logger.LogInformation($"World created with width: {width} and height: {height}.");
        }
        public World()
        {
            
            _worldObjectFactory = new WorldObjectFactory(); // 内部创建工厂对象

            creatures = new List<Creature>();
            objects = new List<WorldObject>();

            // 使用 GameConfigReader 获取配置并初始化
            var config = GameConfigReader.Instance.GetConfig();
            InitializeFromConfig(config);
            logger.Close();
        }


        private void InitializeFromConfig(XDocument config)
        {
            var worldConfig = config.Descendants("World").FirstOrDefault();
            if (worldConfig != null)
            {
                width = int.Parse(worldConfig.Element("Width").Value);
                height = int.Parse(worldConfig.Element("Height").Value);
                Console.WriteLine($"World created with width: {width} and height: {height}");
            }

            // 初始化生物
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

            // 初始化物品
            foreach (var obj in config.Descendants("WorldObject"))
            {
                string type = obj.Element("Type").Value;
                string name = obj.Element("Name").Value;
                int value = int.Parse(obj.Element("Value").Value);
                int x = int.Parse(obj.Element("PositionX").Value);
                int y = int.Parse(obj.Element("PositionY").Value);

                AddWorldObject(_worldObjectFactory.CreateWorldObject(type, name, value, x, y));
            }

            // 处理动作
            foreach (var action in config.Descendants("Action"))
            {
                HandleAction(action);
            }

          
        }

        private void HandleAction(XElement actionElement)
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

        private Creature CreateCreature(string name, string type, int hitPoint, int x, int y)
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



        public bool IsPositionValid(int x, int y)
        {
          
            return x >= 0 && y >= 0 && x < width && y < height;
        }

        public void AddCreature(Creature creature)
        {
            MyLogger logger = MyLogger.Instance;
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
