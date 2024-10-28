using Mandatory2DGameFramework.Cretures;
using Mandatory2DGameFramework.Div;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.state
{
    public class NormalState : ICreatureState
    {
        private static readonly MyLogger Logger = MyLogger.Instance;
        public void ReceiveHit(Creature creature, int damage)
        {
            int reducedDamage = Math.Max(damage - (creature.Defence?.DefenseValue ?? 0), 0);
            creature.HitPoint -= reducedDamage;

            Console.WriteLine($"{creature.Name} received {reducedDamage} damage. Remaining life points: {creature.HitPoint}");
            Logger.LogInformation($"{creature.Name} received {reducedDamage} damage. Remaining life points: {creature.HitPoint}");

            if (creature.HitPoint <= 0)
            {
                creature.ChangeState(new DeadState());
                Console.WriteLine($"{creature.Name} has died.");
                Logger.LogWarning($"{creature.Name} has died.");
            }
        }

        public void Attack(Creature attacker, Creature target)
        {
            if (attacker.Attack == null)
            {
                Console.WriteLine($"{attacker.Name} has no weapon to attack.");
                Logger.LogWarning($"{attacker.Name} has no weapon to attack.");
                return;
            }

            int damage = attacker.Attack.CalculateDamage();
            Console.WriteLine($"{attacker.Name} attacked {target.Name}, causing {damage} damage.");
            Logger.LogInformation($"{attacker.Name} attacked {target.Name}, causing {damage} damage.");
            target.ReceiveHit(damage);
        }

        public void Loot(Creature creature, WorldObject obj, World world)
        {
            if (obj.Lootable)
            {
                if (obj is BonusItem bonusItem)
                {
                    bonusItem.ApplyBonus(creature);
                }
                else if (obj is AttackItem attackItem)
                {
                    creature.Attack = attackItem;
                    Console.WriteLine($"{creature.Name} picked up an attack item: {attackItem.Name}");
                    Logger.LogInformation($"{creature.Name} picked up an attack item: {attackItem.Name}");
                }
                else if (obj is DefenceItem defenceItem)
                {
                    creature.Defence = defenceItem;
                    Console.WriteLine($"{creature.Name} picked up armor: {defenceItem.Name}.Defense value: {defenceItem.DefenseValue}");
                    Logger.LogInformation($"{creature.Name} picked up armor: {defenceItem.Name}.Defense value: {defenceItem.DefenseValue}");
                }
                world.RemoveWorldObject(obj);
            }
            else
            {
                Console.WriteLine($"{obj.Name} cannot be picked up.");
                Logger.LogWarning($"{obj.Name} cannot be picked up.");
            }
        }

        public void Move(Creature creature, int x, int y, World world)
        {
            if (world.IsPositionValid(x, y))
            {
                creature.X = x;
                creature.Y = y;
                Console.WriteLine($"{creature.Name} moved to ({creature.X}, {creature.Y})");
                Logger.LogInformation($"{creature.Name} moved to ({creature.X}, {creature.Y})");
            }
        }
    }
}

