using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleGame
{
    public class GameConfigReader
    {
        public World World { get; private set; }
        public List<Creature> Creatures { get; private set; } = new List<Creature>();
        public List<WorldObject> Items { get; private set; } = new List<WorldObject>();

        public void ReadConfig(string file)
        {
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(file);

            // Read World Configuration
            XmlNode worldNode = configDoc.DocumentElement.SelectSingleNode("World");
            if (worldNode != null)
            {
                int width = int.Parse(worldNode.Attributes["width"].Value);
                int height = int.Parse(worldNode.Attributes["height"].Value);
                World = new World(width, height);
                
            }

            // Read Creatures Configuration
            XmlNodeList creatureNodes = configDoc.DocumentElement.SelectNodes("//Creatures/Creature");
            foreach (XmlNode creatureNode in creatureNodes)
            {
                string type = creatureNode.Attributes["type"].Value;
                string name = creatureNode.Attributes["name"].Value;
                int hitPoints = int.Parse(creatureNode.Attributes["hitPoints"].Value);
                int x = int.Parse(creatureNode.Attributes["x"].Value);
                int y = int.Parse(creatureNode.Attributes["y"].Value);

                Creature creature;
                if (type == "Warrior")
                {
                    creature = new Warrior(name, hitPoints, x, y);
                 
                }
                else if (type == "Mage")
                {
                    creature = new Mage(name, hitPoints, x, y);
                  
                }
                else
                {
                    throw new Exception($"Unknown creature type: {type}");
                }
                Creatures.Add(creature);
                World.AddCreature(creature);

            }

            // Read Items Configuration
            XmlNodeList itemNodes = configDoc.DocumentElement.SelectNodes("//Items/*");
            foreach (XmlNode itemNode in itemNodes)
            {
                string itemName = itemNode.Attributes["name"].Value;
                int x = int.Parse(itemNode.Attributes["x"].Value);
                int y = int.Parse(itemNode.Attributes["y"].Value);

                if (itemNode.Name == "AttackItem")
                {
                    int attackPower = int.Parse(itemNode.Attributes["attackPower"].Value);
                    AttackItem attackItem = new AttackItem(itemName, attackPower, x, y);
                    World.AddWorldObject(attackItem);
                   
                }
                else if (itemNode.Name == "DefenceItem")
                {
                    int defenseValue = int.Parse(itemNode.Attributes["defenseValue"].Value);
                    DefenceItem defenceItem = new DefenceItem(itemName, defenseValue, x, y);
                    World.AddWorldObject(defenceItem);
                }
                else if (itemNode.Name == "BonusItem")
                {
                    int bonusPoints = int.Parse(itemNode.Attributes["bonusPoints"].Value);
                    BonusItem bonusItem = new BonusItem(itemName, bonusPoints, x, y);
                   World.AddWorldObject(bonusItem);
                }
                else if (itemNode.Name == "HazardItem")
                {
                    int damage = int.Parse(itemNode.Attributes["damage"].Value);
                    HazardItem hazardItem = new HazardItem(itemName, damage, x, y);
                    World.AddWorldObject(hazardItem);
                }
            }




            // Read Actions Configuration
            // Read Actions Configuration
            XmlNodeList actionNodes = configDoc.DocumentElement.SelectNodes("//Actions/Action");
            foreach (XmlNode actionNode in actionNodes)
            {
                string actionType = actionNode.Attributes["type"].Value;

                // 对于 Move 和 Loot 操作，继续使用 creatureName
                if (actionType == "Move" || actionType == "Loot")
                {
                    string creatureName = actionNode.Attributes["creatureName"]?.Value;
                    Creature creature = Creatures.Find(c => c.Name == creatureName);

                    if (creature == null)
                    {
                        Console.WriteLine($"Creature with name {creatureName} not found.");
                        continue;
                    }

                    // Move and Loot logic remains unchanged
                    switch (actionType)
                    {
                        case "Move":
                            int x = int.Parse(actionNode.Attributes["x"].Value);
                            int y = int.Parse(actionNode.Attributes["y"].Value);
                            creature.Move(x, y, World);
                            break;

                        case "Loot":
                            x = int.Parse(actionNode.Attributes["x"].Value);
                            y = int.Parse(actionNode.Attributes["y"].Value);
                            WorldObject? item = World.GetWorldObjectAtPosition(x, y);
                            if (item != null)
                            {
                                creature.Loot(item, World);
                            }
                            else
                            {
                                Console.WriteLine($"No item found at position ({x}, {y}) for {creatureName} to loot.");
                            }
                            break;
                    }
                }
                // 处理 Hit 操作
                else if (actionType == "Hit")
                {
                    string attackerName = actionNode.Attributes["attackerName"].Value;
                    string targetName = actionNode.Attributes["targetName"].Value;

                    Creature attacker = Creatures.Find(c => c.Name == attackerName);
                    Creature target = Creatures.Find(c => c.Name == targetName);

                    if (attacker == null)
                    {
                        Console.WriteLine($"Creature with name {attackerName} not found.");
                        continue;
                    }

                    if (target == null)
                    {
                        Console.WriteLine($"Creature with name {targetName} not found.");
                        continue;
                    }

                    attacker.Hit(target);
                }
            }

        }
    }
    
}
