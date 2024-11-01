using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds.Factory
{
    public class WorldObjectFactory : IWorldObjectFactory
    { 
        
       /// <summary>
      /// Creates a WorldObject of the specified type with the provided parameters.
      /// </summary>
      /// <param name="type">The type of world object to create (e.g., "Attack", "Defence", "Bonus").</param>
      /// <param name="name">The name of the world object.</param>
      /// <param name="value">The value associated with the world object.</param>
      /// <param name="x">The x-coordinate of the world object.</param>
      /// <param name="y">The y-coordinate of the world object.</param>
      /// <returns>A new instance of a WorldObject based on the provided type.</returns>
      /// <exception cref="ArgumentException">Thrown when an invalid world object type is specified.</exception>
        public WorldObject CreateWorldObject(string type, string name, int value, int x, int y)
        {
            switch (type)
            {
                case "Attack":
                    return new AttackItem(name, value, x, y); 
                case "Defence":
                    return new DefenceItem(name, value, x, y); 
                case "Bonus":
                    return new BonusItem(name, value, x, y);
                default:
                    throw new ArgumentException("Invalid world object type");

            }
        }
    }
}
