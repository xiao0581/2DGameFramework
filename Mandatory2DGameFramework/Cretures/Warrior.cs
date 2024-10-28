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
        public Warrior(string name, int hitPoint, int x, int y) : base(name, hitPoint, x, y)
        {
        }

        protected override void OnMove()
        {
            Console.WriteLine($"{Name} the Warrior moved to ({X}, {Y}).");
            logger.LogInformation($"{Name} the Warrior moved to ({X}, {Y}).");
        }
    }
}
