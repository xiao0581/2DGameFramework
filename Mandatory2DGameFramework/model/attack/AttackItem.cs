using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackItem : WorldObject
    {
        public string  Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }
        public int Damage { get; private set; }
        public AttackItem()
        {
            Name = string.Empty;
            Hit = 0;
            Range = 0;
        }

        public int CalculateDamage()
        {
            return Damage;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }
    }
}
