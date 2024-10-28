using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.Div;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class HazardItem : WorldObject
    {
        
            public int Damage { get; private set; }
         private static readonly MyLogger logger = MyLogger.Instance;
        public HazardItem(string name, int damage, int x, int y)
                : base(name, false, x, y)  
            {
                Damage = damage;
            }

            public void ApplyDamage(Creature creature)
            {
                creature.ReceiveHit(Damage);
                Console.WriteLine($"{creature.Name} Triggered {Name} and took {Damage} damage。");
             logger.LogInformation($"{creature.Name} Triggered {Name} and took {Damage} damage。");
            }
        }

    
}
