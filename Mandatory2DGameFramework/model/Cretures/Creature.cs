using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }


        // Todo consider how many attack / defence weapons are allowed
        public AttackItem?   Attack { get; set; }
        public DefenceItem?  Defence { get; set; }

       
        public int X { get; set; }
        public int Y { get; set; }

        public Creature(string name, int hitPoint, int x, int y)
        {
            Name = name;
            HitPoint = hitPoint;
            X = x;
            Y = y;
        }

        // 移动生物到新的位置
        public void Move(int newX, int newY, World world)
        {
            if (world.IsPositionValid(newX, newY))
            {
                X = newX;
                Y = newY;
                Console.WriteLine($"{Name} 移动到了 ({X}, {Y})。");

                // 检查是否有陷阱在当前位置
                foreach (var obj in world.GetWorldObjectsAtPosition(X, Y))
                {
                    if (obj is HazardItem hazard)
                    {
                        hazard.ApplyDamage(this);
                    }
                }
            }
        }

        public void Hit(Creature target)
        {
            if (Attack == null)
            {
                Console.WriteLine($"{Name} har ikke et tilgængeligt angrebsvåben.");
                return;
            }

            int damage = Attack.CalculateDamage();
            target.ReceiveHit(damage);
            Console.WriteLine($"{Name} angreb {target.Name} med {Attack.Name} og forårsagede {damage} skade.");
        }

        // Reaktion på at blive angrebet
        public void ReceiveHit(int damage)
        {
            int reducedDamage = Defence != null ? damage - Defence.DefenseValue : damage;
            reducedDamage = Math.Max(reducedDamage, 0);  // Sikre at skaden ikke er negativ

            HitPoint -= reducedDamage;
            Console.WriteLine($"{Name} modtog {reducedDamage} skade. Resterende livspoint: {HitPoint}");

            if (HitPoint <= 0)
            {
                Console.WriteLine($"{Name} er død.");
            }
        }

        // Looting af genstande
        public void Loot(WorldObject obj, World world)
        {
            if (obj.Lootable)
            {
                if (obj is BonusItem bonusItem)
                {
                    bonusItem.ApplyBonus(this);  // 应用奖励效果
                }
                else if (obj is AttackItem attackItem)
                {
                    Attack = attackItem;
                    Console.WriteLine($"{Name} 拾取了攻击物品：{attackItem.Name}");
                }
                else if (obj is DefenceItem defenceItem)
                {
                    Defence = defenceItem;
                    Console.WriteLine($"{Name} 拾取了防具：{defenceItem.Name}");
                }

                // 从世界中移除该物品
                world.RemoveWorldObject(obj);
            }
            else
            {
                Console.WriteLine($"{obj.Name} 不能被拾取。");
            }
        }








        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}}}";
        }
    }
}
