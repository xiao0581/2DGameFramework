using Mandatory2DGameFramework.Div;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mandatory2DGameFramework.Cretures
{
    public class Warrior : Creature
    {
        private static readonly MyLogger logger = MyLogger.Instance;

        /// <summary>
        /// Initializes a new instance of the Warrior class with specified name, hit points, and position.
        /// </summary>
        /// <param name="name">The name of the warrior.</param>
        /// <param name="hitPoint">The hit points of the warrior.</param>
        /// <param name="x">The x-coordinate of the warrior's initial position.</param>
        /// <param name="y">The y-coordinate of the warrior's initial position.</param>
        public Warrior(string name, int hitPoint, int x, int y) : base(name, hitPoint, x, y)
        {
        }


        /// <summary>
        /// Called when the warrior moves.
        /// Overrides the OnMove method in the base Creature class.
        /// </summary>
        protected override void OnMove()
        {
            Console.WriteLine($"{Name} the Warrior moved to ({X}, {Y}).");
            logger.LogInformation($"{Name} the Warrior moved to ({X}, {Y}).");
        }
    }
}
