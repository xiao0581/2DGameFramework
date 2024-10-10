using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackItem : WorldObject
    {
        public int Hit { get; private set; }  // 攻击命中率
        public int Range { get; private set; }  // 攻击范围
        public int Damage { get; private set; }  // 攻击造成的伤害

        // 构造函数
        public AttackItem(string name, int hit, int range, int damage, int x, int y)
            : base(name, true, x, y)  // 传递给基类构造函数, 这个物品是可拾取的（lootable）
        {
            Hit = hit;
            Range = range;
            Damage = damage;
        }

        // 计算伤害
        public int CalculateDamage()
        {
            // 简单的伤害计算逻辑，可以进一步扩展
            return Damage;
        }
    }

}

