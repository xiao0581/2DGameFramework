// See https://aka.ms/new-console-template for more information
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;
Console.WriteLine("Hello, World!");
World world = new World(10, 10);

// 创建生物和物品
Creature warrior = new Creature("Krigeren", 100, 2, 3);
Creature mage = new Creature("Troldmanden", 80, 5, 5);
WorldObject wall = new WorldObject("Mur", false, 3, 3);

// 将生物和物品添加到世界中
world.AddCreature(warrior);
world.AddCreature(mage);
world.AddWorldObject(wall);

// 移动物品
warrior.Move(3, 4, world);

// Krigeren攻击Troldmanden
warrior.Hit(mage);

// 输出状态
Console.WriteLine($"{mage.Name} har {mage.HitPoint} livspoint tilbage.");
