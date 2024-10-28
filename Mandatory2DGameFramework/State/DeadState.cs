using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.Div;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.state
{
    public class DeadState : ICreatureState
    {
        private static readonly MyLogger logger = MyLogger.Instance;
        public void ReceiveHit(Creature creature, int damage)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot be hit.");
            logger.LogInformation($"{creature.Name} is dead and cannot be hit.");
        }

        public void Attack(Creature attacker, Creature target)
        {
            Console.WriteLine($"{attacker.Name} is dead and cannot attack.");
            logger.LogInformation($"{attacker.Name} is dead and cannot attack.");
        }

        public void Loot(Creature creature, WorldObject obj, World world)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot loot.");
            logger.LogInformation($"{creature.Name} is dead and cannot loot.");
        }

        public void Move(Creature creature, int x, int y, World world)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot move.");
            logger.LogInformation($"{creature.Name} is dead and cannot move.");
        }
    }
}