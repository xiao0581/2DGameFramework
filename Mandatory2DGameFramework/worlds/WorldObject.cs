using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class WorldObject
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
       
        public int X { get; set; }
        public int Y { get; set; }
        public WorldObject(string name, bool lootable, int x, int y)
        {
            Name = name;
            Lootable = lootable;
           
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Lootable)}={Lootable.ToString()}";
        }
    }
}
