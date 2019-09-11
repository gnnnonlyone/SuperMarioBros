using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using System;

namespace SuperMarioBros.PhysicalState
{
    public class EnemyPhysics : IEnemyPhysics
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public bool OutOfBoundary { get; set; }
        public bool InCollision { get; set; }
        public bool Steering { get; set; }
        public bool Gravity { get; set; }

        private Random randomNumber;
        public EnemyPhysics(Vector2 position)
        {
            Position = position;
            Velocity = new Vector2();
            Acceleration = new Vector2();
            Gravity = true;
            OutOfBoundary = false;
            InCollision = false;
            Steering = false;
            Walk();
            randomNumber = new Random();
        }

        public void ChangeDirection()
        {
            if (!InCollision)
            {
                Velocity = new Vector2(-1 * Velocity.X, Velocity.Y);
                Steering = true;
            }
        }

        public void Walk()
        {
            Acceleration = new Vector2(0, Acceleration.Y);
            Velocity = new Vector2(Constant.Constant.Instance.EnemyWalkSpeed, Velocity.Y);
   
        }

        public void CheckBoundary()
        {
            if(Position.X < Constant.Constant.Instance.BoundaryOrigin || Position.X > Constant.Constant.Instance.BoundaryX || Position.Y > Constant.Constant.Instance.BoundaryY || Position.Y < Constant.Constant.Instance.BoundaryOrigin)
            {
                OutOfBoundary = true;
            }
        }

        public void CheckCollisionEnding()
        {
            if(InCollision && Steering)
            {
                Steering = false;
            }
            else if(InCollision && !Steering)
            {
                InCollision = false;
            }
        }

        public void Jump()
        {
            Acceleration = new Vector2(Acceleration.X, Constant.Constant.Instance.RedMushroomWalkSpeed);
            Velocity = new Vector2(Velocity.X, Constant.Constant.Instance.EnmeyJumpSpeed);
        }

        public void Update(GameTime gameTime)
        {
           float realTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
           if(Gravity)
            {
                Velocity += new Vector2(0, Velocity.Y+Constant.Constant.Instance.EnemyDownSpeed) * realTime;
            }
            else
            {
                Gravity = true;
                int n = randomNumber.Next(Constant.Constant.Instance.RandomMaxNumber);
                if (n == Constant.Constant.Instance.RandomTargetNumber)
                {
                    Jump();
                }
            }
            Velocity += realTime * Acceleration;
            Position += realTime * Velocity;
            CheckBoundary();
            CheckCollisionEnding();
        }
    }
}
