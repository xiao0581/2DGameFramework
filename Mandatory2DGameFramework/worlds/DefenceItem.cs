using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class DefenceItem : WorldObject
    {
        public int DefenseValue { get; private set; }


        public DefenceItem(string name, int defenseValue, int x, int y)
            : base(name, true, x, y)
        {
            DefenseValue = defenseValue;
        }


        public int ReduceDamage(int incomingDamage)
        {

            return Math.Max(incomingDamage - DefenseValue, 0);
        }
    }

}

