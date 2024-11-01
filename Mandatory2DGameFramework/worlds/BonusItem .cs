using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.Div;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class BonusItem : WorldObject
    {
        public int HealthBonus { get; private set; }
        private static readonly MyLogger logger = MyLogger.Instance;

        public BonusItem(string name, int healthBonus, int x, int y)
            : base(name, true, x, y)
        {
            HealthBonus = healthBonus;
            
        }
        /// <summary>
        /// Applies the health bonus to the specified creature.
        /// </summary>
        /// <param name="creature">The creature to receive the health bonus.</param>
        public void ApplyBonus(Creature creature)
        {
         
            creature.HitPoint += HealthBonus;
            Console.WriteLine($"{creature.Name} Gained {HealthBonus} health bonus, current health：{creature.HitPoint}");

            logger.LogInformation($"{creature.Name} Gained {HealthBonus} health bonus, current health：{creature.HitPoint}");
          
        }
    }

}
