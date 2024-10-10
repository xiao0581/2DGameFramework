using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem : WorldObject
    {
        public int DefenseValue { get; private set; }  // 防御值，用于减少受到的伤害

        // 构造函数
        public DefenceItem(string name, int defenseValue, int x, int y)
            : base(name, true, x, y)  // 传递给基类构造函数，防具物品是可拾取的
        {
            DefenseValue = defenseValue;
        }

        // 减少伤害的方法（可选）
        public int ReduceDamage(int incomingDamage)
        {
            // 通过防御值减少伤害，确保最小伤害为0
            return Math.Max(incomingDamage - DefenseValue, 0);
        }
    }

}

