﻿// See https://aka.ms/new-console-template for more information
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


//WorldObject sword = factory.CreateWorldObject("Attack", "Sword", 30, 5, 5);
//WorldObject shield = factory.CreateWorldObject("Defence", "Shield", 5, 3, 3);
//WorldObject potion = factory.CreateWorldObject("Bonus", "Potion", 5, 2, 2);

//world.AddWorldObject(sword);
//world.AddWorldObject(shield);
//world.AddWorldObject(potion);

//Console.WriteLine("---------------------------------------------------------------------------");
//warrior.Move(5, 5, world);
//warrior.Loot(world.GetWorldObjectAtPosition(5, 5), world);

//mage.Move(3, 3, world);
//mage.Loot(world.GetWorldObjectAtPosition(3, 3), world);
//warrior.Move(3, 3, world);
//Console.WriteLine("---------------------------------------------------------------------------");
//warrior.Hit(mage);
//warrior.Hit(mage);






GameConfigReader.Initialize("C:\\Users\\xiaohui\\Desktop\\4.SWC\\Mandatory2DGameFramework\\Mandatory2DGameFramework\\SimpleGame\\gameConfig.xml");

//GameConfigReader.Initialize("C:\\Users\\xiao\\source\\repos\\2DGameFramework\\SimpleGame\\gameConfig.xml");

World world = new World();

