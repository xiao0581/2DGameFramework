using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mandatory2DGameFramework.state;
using Mandatory2DGameFramework.Div;
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
        private static readonly MyLogger logger = MyLogger.Instance;

        private ICreatureState currentState; 

        /// <summary>
        /// Initializes a new instance of the Creature class with specified name, hit points, and position.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <param name="hitPoint">The hit points of the creature.</param>
        /// <param name="x">The x-coordinate of the creature's initial position.</param>
        /// <param name="y">The y-coordinate of the creature's initial position.</param>
        public Creature(string name, int hitPoint, int x, int y)
        {
            Name = name;
            HitPoint = hitPoint;
            X = x;
            Y = y;
            currentState = new NormalState();  // initial state
        }

        /// <summary>
        /// Changes the creature's state.
        /// </summary>
        /// <param name="newState">The new state to change to.</param>
        public void ChangeState(ICreatureState newState)
        {
            currentState = newState;
        }

        /// <summary>
        /// The creature receives a hit and takes damage.
        /// </summary>
        /// <param name="damage">The amount of damage to take.</param>
        public void ReceiveHit(int damage)
        {
            currentState.ReceiveHit(this, damage);
        }

        /// <summary>
        /// The creature attacks a target creature.
        /// </summary>
        /// <param name="target">The target creature to attack.</param>
        public void Hit(Creature target)
        {
            currentState.Attack(this, target);
        }

        /// <summary>
        /// The creature loots a world object.
        /// </summary>
        /// <param name="obj">The world object to loot.</param>
        /// <param name="world">The world in which the creature exists.</param>
        public void Loot(WorldObject obj, World world)
        {
            currentState.Loot(this, obj, world);
        }

        /// <summary>
        /// Moves the creature to a new position if the move is valid.
        /// </summary>
        /// <param name="newX">The new x-coordinate.</param>
        /// <param name="newY">The new y-coordinate.</param>
        /// <param name="world">The world in which the creature exists.</param>
        public void Move(int newX, int newY, World world)
        {
            if (CanMove(newX, newY, world))
            {
                UpdatePosition(newX, newY);
                OnMove();
            }
        }

        /// <summary>
        /// Determines if the creature can move to the specified position.
        /// Can be overridden in subclasses.
        /// </summary>
        /// <param name="x">The x-coordinate to move to.</param>
        /// <param name="y">The y-coordinate to move to.</param>
        /// <param name="world">The world in which the creature exists.</param>
        /// <returns>True if the move is valid, otherwise false.</returns>
        protected virtual bool CanMove(int x, int y, World world)
        {
            return world.IsPositionValid(x, y);
        }

        /// <summary>
        /// Updates the creature's position.
        /// Can be overridden in subclasses.
        /// </summary>
        /// <param name="x">The new x-coordinate.</param>
        /// <param name="y">The new y-coordinate.</param>
        protected virtual void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Called when the creature moves.
        /// Can be overridden in subclasses.
        /// </summary>
        protected virtual void OnMove()
        {
            Console.WriteLine($"{Name} moved to ({X}, {Y}).");
            logger.LogInformation($"{Name} moved to ({X}, {Y}).");
           
        }
    }
}
