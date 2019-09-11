using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PhysicalState
{
    public class FireballPhysics: IPhysics
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public bool OutOfBoundary { get; set; }

        public FireballPhysics(Vector2 position)
        {
            Position = position;
            Velocity = new Vector2();
            Acceleration = new Vector2();
            OutOfBoundary = false;
        }

        public void MoveLeft()
        {
            Velocity = new Vector2(Constant.Constant.Instance.FireballLeftSpeed, Velocity.Y);
        }
        public void MoveRight()
        {
            Velocity = new Vector2(Constant.Constant.Instance.FireballRightSpeed, Velocity.Y);
        }

        public void CheckBoundary()
        {
            if (Position.X < Constant.Constant.Instance.BoundaryOrigin || Position.X > Constant.Constant.Instance.BoundaryX || Position.Y > Constant.Constant.Instance.BoundaryY || Position.Y < Constant.Constant.Instance.BoundaryOrigin)
            {
                OutOfBoundary = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity += new Vector2(0f, Constant.Constant.Instance.GeneralGravity - Constant.Constant.Instance.FireballFloatAcceleration) * time;
            Position += Velocity * time;
            CheckBoundary();
        }
    }
}
