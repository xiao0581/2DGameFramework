using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class BonusItem : WorldObject
    {
        public int HealthBonus { get; private set; }
        public int XpBonus { get; private set; }

        public BonusItem(string name, int healthBonus, int xpBonus, int x, int y)
            : base(name, true, x, y)
        {
            HealthBonus = healthBonus;
            XpBonus = xpBonus;
        }

        public void ApplyBonus(Creature creature)
        {
            // 给予生物奖励，例如恢复生命值或增加经验值
            creature.HitPoint += HealthBonus;
            Console.WriteLine($"{creature.Name} 获得了 {HealthBonus} 生命值加成，当前生命值：{creature.HitPoint}");

            // 增加经验值的逻辑可以进一步实现
            // creature.XP += XpBonus;  // 假设你添加了经验值系统
        }
    }

}
