using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PhysicalState
{
    class SwimFishPhysics:IEnemyPhysics
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public bool OutOfBoundary { get; set; }
        public bool InCollision { get; set; }
        public bool Steering { get; set; }
        public bool Gravity { get; set; }
        public SwimFishPhysics(Vector2 position)
        {
            Position = position;
            Velocity = Constant.Constant.Instance.SwimFishSpeed;
            // Acceleration = new Vector2(0,10);
            Gravity = true;
            OutOfBoundary = false;
            InCollision = false;
            Steering = false;
            Walk();
        }

        public void ChangeDirection()
        {
            if (!InCollision)
            {
                Velocity = new Vector2(Constant.Constant.Instance.NegativeOne * Velocity.X, Velocity.Y);
                Steering = true;
            }
        }

        public void Walk()
        {
          
        }

        public void CheckBoundary()
        {
            
            if (Position.X < Constant.Constant.Instance.BoundaryOrigin || Position.X > Constant.Constant.Instance.BoundaryX || Position.Y > Constant.Constant.Instance.BoundaryY || Position.Y < Constant.Constant.Instance.BoundaryOrigin)
            {
                Velocity = new Vector2(Constant.Constant.Instance.NegativeOne * Velocity.X, Constant.Constant.Instance.NegativeOne * Velocity.Y);
            }
        }

        public void CheckCollisionEnding()
        {
            if (InCollision && Steering)
            {
                Steering = false;
            }
            else if (InCollision && !Steering)
            {
                InCollision = false;
            }
        }

        public void Update(GameTime gameTime)
        {
            float realTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += realTime * Velocity;
            CheckBoundary();
            CheckCollisionEnding();
        }
    }
}
