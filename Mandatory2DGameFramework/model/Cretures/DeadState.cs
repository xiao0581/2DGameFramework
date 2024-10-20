using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class DeadState: ICreatureState
    {
        public void ReceiveHit(Creature creature, int damage)
        {
            Console.WriteLine($"{creature.Name} is already dead. No effect.");
        }
    }
}
