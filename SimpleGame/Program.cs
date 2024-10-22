// See https://aka.ms/new-console-template for more information
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using SimpleGame;

IWorldObjectFactory factory = new WorldObjectFactory();
World world = new World(10, 10, factory); // 创建一个10x10的世界

// 创建生物
Creature warrior = new Warrior("Conan", 100, 2, 3); // 战士
Creature mage = new Mage("Gandalf", 80, 1, 1); // 法师

// 将生物添加到世界
world.AddCreature(warrior);
world.AddCreature(mage);

// 创建物品：刀（攻击）、盾（防御）、陷阱、奖励
world.AddWorldObject("Attack", "Sword", 15, 5, 5); // 刀
world.AddWorldObject("Defence", "Shield", 10, 3, 3); // 盾
world.AddWorldObject("Hazard", "Spike Trap", 20, 4, 4); // 陷阱
world.AddWorldObject("Bonus", "Health Potion", 30, 2, 2); // 奖励

// 生物移动并拾取物品
warrior.Move(5, 5, world); // 战士移动到刀的位置并拾取
mage.Move(2, 2, world); // 法师移动到奖励的位置并拾取

// 生物攻击交互
warrior.Hit(mage);  // 战士攻击法师
mage.Hit(warrior);  // 法师反击战士

// 战士走到陷阱，触发陷阱
warrior.Move(4, 4, world); --------------------------------------------------------------------------------------------------------------------------------------------

