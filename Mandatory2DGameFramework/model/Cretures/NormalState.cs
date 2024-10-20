using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class NormalState : ICreatureState
    {
        public void ReceiveHit(Creature creature, int damage)
        {
            int reducedDamage = Math.Max(damage - (creature.Defence?.DefenseValue ?? 0), 0);
            creature.HitPoint -= reducedDamage;

            Console.WriteLine($"{creature.Name} received {reducedDamage} damage. Remaining life points: {creature.HitPoint}");

            if (creature.HitPoint <= 0)
            {
                Console.WriteLine($"{creature.Name} is now dead.");
                creature.ChangeState(new DeadState());  // 状态变为死亡状态
            }
        }
    }
}
