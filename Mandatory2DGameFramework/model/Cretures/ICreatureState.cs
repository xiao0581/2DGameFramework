using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public interface ICreatureState
    {
        void ReceiveHit(Creature creature, int damage);
    }
}
