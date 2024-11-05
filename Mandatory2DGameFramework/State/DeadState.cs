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


        /// <summary>
        /// Handles the event when a dead creature receives a hit.
        /// </summary>
        /// <param name="creature">The creature receiving the hit.</param>
        /// <param name="damage">The amount of damage.</param>
        public void ReceiveHit(Creature creature, int damage)
        {

            Console.WriteLine($"{creature.Name} is dead and cannot be hit.");
            logger.LogInformation($"{creature.Name} is dead and cannot be hit.");

        }

        /// <summary>
        /// Handles the event when a dead creature attempts to attack.
        /// </summary>
        /// <param name="attacker">The attacking creature.</param>
        /// <param name="target">The target creature.</param>
        public void Attack(Creature attacker, Creature target)
        {
            Console.WriteLine($"{attacker.Name} is dead and cannot attack.");
            logger.LogInformation($"{attacker.Name} is dead and cannot attack.");
        }

        /// <summary>
        /// Handles the event when a dead creature attempts to loot.
        /// </summary>
        /// <param name="creature">The looting creature.</param>
        /// <param name="obj">The object to be looted.</param>
        /// <param name="world">The world in which the creature exists.</param>
        public void Loot(Creature creature, WorldObject obj, World world)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot loot.");
            logger.LogInformation($"{creature.Name} is dead and cannot loot.");
        }

        /// <summary>
        /// Handles the event when a dead creature attempts to move.
        /// </summary>
        /// <param name="creature">The moving creature.</param>
        /// <param name="x">The new x-coordinate.</param>
        /// <param name="y">The new y-coordinate.</param>
        /// <param name="world">The world in which the creature exists.</param>
        public void Move(Creature creature, int x, int y, World world)
        {
            Console.WriteLine($"{creature.Name} is dead and cannot move.");
            logger.LogInformation($"{creature.Name} is dead and cannot move.");
        }
    }
}