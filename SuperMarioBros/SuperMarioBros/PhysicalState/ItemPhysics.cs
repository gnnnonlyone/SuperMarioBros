using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.PhysicalState
{
    public class ItemPhysics : IPhysics
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public Vector2 StartingPosition { get; set; }

        public bool OutOfBoundary { get; set; }

        public ItemPhysics(Vector2 position)
        {
            Position = position;
            Velocity = new Vector2();
            Acceleration = new Vector2();
            StartingPosition = position;
            OutOfBoundary = false;
        }

        public void RedMushroomWalk()
        {
            Velocity = new Vector2(Constant.Constant.Instance.RedMushroomWalkSpeed, Constant.Constant.Instance.MushroomUpSpeed);
        }

        public void GreenMushroomWalk()
        {
            Velocity = new Vector2(Constant.Constant.Instance.GreenMushroomWalkSpeed, Constant.Constant.Instance.MushroomUpSpeed);
        }
    

        public void ChangeDirection()
        {
            Velocity = new Vector2(-1 * Velocity.X, Velocity.Y);
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
            float realTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity += realTime * Acceleration;
            Position += realTime * Velocity;
            CheckBoundary();
        }
    }
}
