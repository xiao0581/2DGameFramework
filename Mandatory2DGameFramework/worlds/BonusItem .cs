using Mandatory2DGameFramework.Cretures;
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
       

        public BonusItem(string name, int healthBonus, int x, int y)
            : base(name, true, x, y)
        {
            HealthBonus = healthBonus;
            
        }

        public void ApplyBonus(Creature creature)
        {
         
            creature.HitPoint += HealthBonus;
            Console.WriteLine($"{creature.Name} Gained {HealthBonus} health bonus, current health：{creature.HitPoint}");

          
        }
    }

}
