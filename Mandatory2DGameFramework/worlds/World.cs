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


        public World(int width, int height, IWorldObjectFactory factory)
        {
            this.width = width;
            this.height = height;
            creatures = new List<Creature>();
            objects = new List<WorldObject>();
            _worldObjectFactory = factory; 
        }
        public World()
        {
            _worldObjectFactory = new WorldObjectFactory();  

          
            var config = GameConfigReader.Instance.GetConfig();

            
            var worldConfig = config.Descendants("World").FirstOrDefault();
            if (worldConfig != null)
            {
                width = int.Parse(worldConfig.Element("Width").Value);
                height = int.Parse(worldConfig.Element("Height").Value);

                creatures = new List<Creature>();
                objects = new List<WorldObject>();

                Console.WriteLine($"World created with width: {width} and height: {height}");

                InitializeFromConfig(config);
            }
            else
            {
                throw new Exception("World configuration not found in XML.");
            }
        }


        private void InitializeFromConfig(XDocument config)
        {
            
            foreach (var creature in config.Descendants("Creature"))
            {
                string name = creature.Element("Name").Value;
                string type = creature.Element("Type").Value;
                int hitPoint = int.Parse(creature.Element("HitPoint").Value);
                int x = int.Parse(creature.Element("PositionX").Value);
                int y = int.Parse(creature.Element("PositionY").Value);

                if (type == "Warrior")
                {
                    AddCreature(new Warrior(name, hitPoint, x, y));
                }
                else if (type == "Mage")
                {
                    AddCreature(new Mage(name, hitPoint, x, y));
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
                string attackerName = action.Element("Attacker").Value;
                string actionType = action.Element("Type").Value;

                Creature attacker = creatures.FirstOrDefault(c => c.Name == attackerName);

                if (attacker == null)
                {
                    Console.WriteLine($"Creature {attackerName} not found.");
                    continue;
                }

                if (actionType == "Move")
                {
                  
                    int targetX = int.Parse(action.Element("PositionX").Value);
                    int targetY = int.Parse(action.Element("PositionY").Value);

                    attacker.CurrentState.Move(attacker, targetX, targetY, this);  
                }
                else if (actionType == "Loot")
                {
                   
                    string targetName = action.Element("Target").Value;
                    WorldObject targetObject = objects.FirstOrDefault(o => o.Name == targetName);

                    if (targetObject != null)
                    {
                        attacker.Loot(attacker, targetObject, this); 
                    }
                    else
                    {
                        Console.WriteLine($"WorldObject {targetName} not found.");
                    }
                }
                else if (actionType == "Attack")
                {
               
                    string targetName = action.Element("Target").Value;
                    Creature target = creatures.FirstOrDefault(c => c.Name == targetName);

                    if (target != null)
                    {
                        attacker.CurrentState.Attack(attacker, target); 
                    }
                    else
                    {
                        Console.WriteLine($"Creature {targetName} not found.");
                    }
                }
            }

            Console.WriteLine("World initialization completed.");
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
                Console.WriteLine($"{obj.Name} was added to the world at ({obj.X}, {obj.Y}).");
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
