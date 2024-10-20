using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandatory2DGameFramework.model.Cretures;
namespace Mandatory2DGameFramework.model.Cretures
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private ICreatureState currentState; // 当前状态

        // 构造函数
        public Creature(string name, int hitPoint, int x, int y)
        {
            Name = name;
            HitPoint = hitPoint;
            X = x;
            Y = y;
            currentState = new NormalState();  // 初始状态为正常状态
        }

        // 改变当前状态
        public void ChangeState(ICreatureState newState)
        {
            currentState = newState;
        }

        // 使用当前状态来处理收到的攻击
        public void ReceiveHit(int damage)
        {
            currentState.ReceiveHit(this, damage);
        }

        // 模板方法：移动生物
        public void Move(int newX, int newY, World world)
        {
            if (CanMove(newX, newY, world))
            {
                UpdatePosition(newX, newY);
                OnMove();
            }
        }

        // 这些方法可以被子类覆盖，以实现不同的行为
        protected virtual bool CanMove(int x, int y, World world)
        {
            return world.IsPositionValid(x, y);
        }

        protected virtual void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected virtual void OnMove()
        {
            Console.WriteLine($"{Name} moved to ({X}, {Y}).");
        }

        // 模板方法用于拾取物品
        public virtual void Loot(WorldObject obj, World world)
        {
            if (obj.Lootable)
            {
                if (obj is BonusItem bonusItem)
                {
                    bonusItem.ApplyBonus(this);
                }
                else if (obj is AttackItem attackItem)
                {
                    Attack = attackItem;
                    Console.WriteLine($"{Name} picked up an attack item: {attackItem.Name}");
                }
                else if (obj is DefenceItem defenceItem)
                {
                    Defence = defenceItem;
                    Console.WriteLine($"{Name} picked up armor: {defenceItem.Name}");
                }

                world.RemoveWorldObject(obj);
            }
            else
            {
                Console.WriteLine($"{obj.Name} cannot be picked up.");
            }
        }

        // 攻击其他生物的方法
        public void Hit(Creature target)
        {
            if (Attack == null)
            {
                Console.WriteLine($"{Name} can't attack because there is no attack item.");
                return;
            }

            int damage = Attack.CalculateDamage();
           
            Console.WriteLine($"{Name} attacked {target.Name}, causing {damage} damage.");
            target.ReceiveHit(damage);
        }
    }

}
