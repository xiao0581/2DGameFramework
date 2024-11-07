using Mandatory2DGameFramework.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.State
{
    public interface Iattack
    {
        void Attack(Creature attacker, Creature target);
    }
}
