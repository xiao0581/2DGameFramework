using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class HazardItem : WorldObject
    {
        
            public int Damage { get; private set; }

            public HazardItem(string name, int damage, int x, int y)
                : base(name, false, x, y)  // 这个物品不可拾取
            {
                Damage = damage;
            }

            public void ApplyDamage(Creature creature)
            {
                creature.ReceiveHit(Damage);
                Console.WriteLine($"{creature.Name} 触发了 {Name} 并受到了 {Damage} 点伤害。");
            }
        }

    
}
