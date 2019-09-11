using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;

namespace TreeNewBee.Interfaces
{
    public interface IEnemy
    {
        IEnemyState State { get; set; }
        Rectangle EnemyBox { get; }
        IEnemyPhysics EnemyPhysics { get; set; }

        bool Collidable { get; set; }
        bool Flipped { get; set; }
        void ChangeDirection(Collision.CollisionDetection.CollisionSide side);
        void BeStomped();
        void BeFlipped();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
