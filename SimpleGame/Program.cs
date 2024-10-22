// See https://aka.ms/new-console-template for more information
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds.Factory;


IWorldObjectFactory factory = new WorldObjectFactory();
World world = new World(10, 10, factory); 

Creature warrior = new Warrior("Morten", 100, 2, 3);
Creature mage = new Mage("Anders", 80, 1, 1); 


world.AddCreature(warrior);
world.AddCreature(mage);


world.AddWorldObject("Attack", "Sword", 15, 5, 5); 
world.AddWorldObject("Defence", "Shield", 10, 3, 3); 
world.AddWorldObject("Hazard", "Spike Trap", 20, 4, 4); 
world.AddWorldObject("Bonus", "Health Potion", 30, 2, 2); 


warrior.Move(5, 5, world); 
warrior.Loot(world.GetWorldObjectAtPosition(5, 5), world); 


mage.Move(2, 2, world); 
mage.Loot(world.GetWorldObjectAtPosition(2, 2), world); 


warrior.Move(3, 3, world); 
warrior.Loot(world.GetWorldObjectAtPosition(3, 3), world); 


warrior.Hit(mage);  
mage.Hit(warrior);  


warrior.Move(4, 4, world);
