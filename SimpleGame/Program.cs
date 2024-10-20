// See https://aka.ms/new-console-template for more information
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using SimpleGame;

//Console.WriteLine("--------------------------Game start!--------------------------------------------");
//World world = new World(10, 10);


//Creature warrior = new Warrior("andres", 100, 2, 3);  // Warrior, initial hit points: 150
//Creature mage = new Mage("morten", 100, 5, 5);      // Mage, initial hit points: 100


//AttackItem sword = new AttackItem("Sword",  30, 4, 4);    // Sword, attack power: 30
//DefenceItem shield = new DefenceItem("Shield", 15, 6, 6);       // Shield, defense value: 15
//BonusItem healthPotion = new BonusItem("Health Potion", 20, 7, 7); // Health Potion, adds 20 hit points
//HazardItem trap = new HazardItem("Trap", 25, 5, 5);             // Trap, deals 25 damage


//world.AddCreature(warrior);
//world.AddCreature(mage);
//world.AddWorldObject(sword);
//world.AddWorldObject(shield);
//world.AddWorldObject(healthPotion);
//world.AddWorldObject(trap);

//// Warrior moves to the Sword's position and picks it up
//Console.WriteLine("**********************************");
//warrior.Move(4, 4, world);
//warrior.Loot(sword, world);
//mage.Move(7, 7, world);
//warrior.Move(7, 7, world);
//warrior.Hit(mage);
//warrior.Hit(mage);
//warrior.Hit(mage);
//warrior.Hit(mage);
//warrior.Hit(mage);
//--------------------------------------------------------------------------------------------------------------------------------------------------

GameConfigReader configReader = new GameConfigReader();
configReader.ReadConfig("../../../gameConfig.xml");
