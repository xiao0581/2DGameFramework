using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mandatory2DGameFramework.state;
namespace Mandatory2DGameFramework.Cretures
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private ICreatureState currentState; // creature's current state


        public Creature(string name, int hitPoint, int x, int y)
        {
            Name = name;
            HitPoint = hitPoint;
            X = x;
            Y = y;
            currentState = new NormalState();  // initial state
        }

        // change the creature's state
        public void ChangeState(ICreatureState newState)
        {
            currentState = newState;
        }

        public void ReceiveHit(int damage)
        {
            currentState.ReceiveHit(this, damage);
        }


        public void Hit(Creature target)
        {
            currentState.Attack(this, target);
        }


        public void Loot(WorldObject obj, World world)
        {
            currentState.Loot(this, obj, world);
        }

        // template method move 
        public void Move(int newX, int newY, World world)
        {
            if (CanMove(newX, newY, world))
            {
                UpdatePosition(newX, newY);
                OnMove();
            }
        }

        // can override this method in subclasses
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
    }
}
