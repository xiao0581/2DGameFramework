using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.state
{
    public interface ICreatureState
    {
        void ReceiveHit(Creature creature, int damage);
        void Attack(Creature attacker, Creature target);
        void Loot(Creature creature, WorldObject obj, World world);
        void Move(Creature creature, int x, int y, World world);
    }
}
