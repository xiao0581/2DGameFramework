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
        public Mage(string name, int hitPoint, int x, int y) : base(name, hitPoint, x, y)
        {
        }

        protected override void OnMove()
        {
            Console.WriteLine($"{Name} the Mage moved to ({X}, {Y}).");
            logger.LogInformation($"{Name} the Mage moved to ({X}, {Y}).");
        }
    }
}
