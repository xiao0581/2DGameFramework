using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class DeadState : ICreatureState
    {
        public void ReceiveHit(Creature creature, int damage)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot be hit.");
        }

        public void Attack(Creature attacker, Creature target)
        {
            Console.WriteLine($"{attacker.Name} is dead and cannot attack.");
        }

        public void Loot(Creature creature, WorldObject obj, World world)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot loot.");
        }

        public void Move(Creature creature, int x, int y, World world)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot move.");
        }
    }
}