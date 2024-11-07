using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.State
{
    public interface Imove
    {
        void Move(Creature creature, int x, int y, World world);
    }

}
