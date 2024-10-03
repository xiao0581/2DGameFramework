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

        public Creature()
        {
            Name = string.Empty;
            HitPoint = 100;

            Attack = null;
            Defence = null;

        }

        public void Hit(Creature target)
        {
            if (Attack == null)
            {
                Console.WriteLine($"{Name} 没有可用的攻击武器。");
                return;
            }

            int damage = Attack.CalculateDamage();
            target.ReceiveHit(damage);
            Console.WriteLine($"{Name} 使用 {Attack.Name} 攻击了 {target.Name}，造成了 {damage} 点伤害。");
        }

        // 受到攻击时的反应
        public void ReceiveHit(int damage)
        {
            int reducedDamage = Defence != null ? damage - Defence.DefenseValue : damage;
            reducedDamage = Math.Max(reducedDamage, 0);  // 确保伤害不会为负

            HitPoint -= reducedDamage;
            Console.WriteLine($"{Name} 受到了 {reducedDamage} 点伤害。剩余生命值：{HitPoint}");

            if (HitPoint <= 0)
            {
                Console.WriteLine($"{Name} 已经死亡。");
            }
        }

        // 拾取物品
        public void Loot(WorldObject obj)
        {
            if (obj.Lootable)
            {
                if (obj is AttackItem attackItem)
                {
                    Attack = attackItem;
                    Console.WriteLine($"{Name} 拾取了攻击物品：{attackItem.Name}");
                }
                else if (obj is DefenceItem defenceItem)
                {
                    Defence = defenceItem;
                    Console.WriteLine($"{Name} 拾取了防御物品：{defenceItem.Name}");
                }
            }
            else
            {
                Console.WriteLine($"{obj.Name} 不能被拾取。");
            }
        }





        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Attack)}={Attack}, {nameof(Defence)}={Defence}}}";
        }
    }
}
