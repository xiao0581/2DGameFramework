using Mandatory2DGameFramework.Div;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Cretures
{
    public class Mage : Creature
    {
        private static readonly MyLogger logger = MyLogger.Instance;


        /// <summary>
        /// Initializes a new instance of the Mage class with specified name, hit points, and position.
        /// </summary>
        /// <param name="name">The name of the mage.</param>
        /// <param name="hitPoint">The hit points of the mage.</param>
        /// <param name="x">The x-coordinate of the mage's initial position.</param>
        /// <param name="y">The y-coordinate of the mage's initial position.</param>
        public Mage(string name, int hitPoint, int x, int y) : base(name, hitPoint, x, y)
        {
        }

        /// <summary>
        /// Called when the mage moves.
        /// Overrides the OnMove method in the base Creature class.
        /// </summary>
        protected override void OnMove()
        {
            Console.WriteLine($"{Name} the Mage moved to ({X}, {Y}).");
            logger.LogInformation($"{Name} the Mage moved to ({X}, {Y}).");
        }
    }
}
