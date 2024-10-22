using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds.Factory
{
    public class WorldObjectFactory : IWorldObjectFactory
    {
        public WorldObject CreateWorldObject(string type, string name, int value, int x, int y)
        {
            switch (type)
            {
                case "Attack":
                    return new AttackItem(name, value, x, y); 
                case "Defence":
                    return new DefenceItem(name, value, x, y); 
                case "Hazard":
                    return new HazardItem(name, value, x, y); 
                case "Bonus":
                    return new BonusItem(name, value, x, y);
                default:
                    throw new ArgumentException("Invalid world object type");
            }
        }
    }
}
