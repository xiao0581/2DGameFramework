// See https://aka.ms/new-console-template for more information
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Mandatory2DGameFramework.worlds;

using Mandatory2DGameFramework.worlds.Factory;
using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.Div;


//IWorldObjectFactory factory = new WorldObjectFactory();
//World world = new World(10, 10, factory); 

//Creature warrior = new Warrior("Morten", 100, 2, 3);
//Creature mage = new Mage("Anders", 20, 1, 1); 


//world.AddCreature(warrior);
//world.AddCreature(mage);

//world.AddWorldObject("Attack", "Sword", 30, 5, 5); 
//world.AddWorldObject("Defence", "Shield", 10, 3, 3); 
//world.AddWorldObject("Hazard", "Spike Trap", 20, 4, 4); 
//world.AddWorldObject("Bonus", "Health Potion", 30, 2, 2);

//Console.WriteLine("---------------------------------------------------------------------------");
//warrior.Move(5, 5, world); 
//warrior.Loot(world.GetWorldObjectAtPosition(5, 5), world); 


//mage.Move(2, 2, world); 
//mage.Loot(world.GetWorldObjectAtPosition(3, 3), world);



//Console.WriteLine("---------------------------------------------------------------------------");
//warrior.Hit(mage);
//warrior.Hit(mage);


GameConfigReader.Initialize("C:\\Users\\xiaohui\\Desktop\\4.SWC\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\SimpleGame\\gameConfig.xml");


World world = new World();

