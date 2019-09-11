using Microsoft.Xna.Framework;

namespace SuperMarioBros.Interfaces
{
    public interface IEnemyPhysics
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        bool Gravity { get; set; }
        bool OutOfBoundary { get; set; }
        bool InCollision { get; set; }

        void ChangeDirection();

        void Walk();

        void Update(GameTime gameTime);
    }
}
