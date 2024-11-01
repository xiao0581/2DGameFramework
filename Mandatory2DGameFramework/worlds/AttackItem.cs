using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mandatory2DGameFramework.worlds
{
    public class AttackItem : WorldObject
    {


        public int Damage { get; private set; }


        public AttackItem(string name, int damage, int x, int y)
            : base(name, true, x, y)
        {

            Damage = damage;
        }

        /// <summary>
        /// Calculates and returns the damage value of the AttackItem.
        /// </summary>
        /// <returns>The damage value of the attack item.</returns>
        public int CalculateDamage()
        {

            return Damage;
        }
    }

}

