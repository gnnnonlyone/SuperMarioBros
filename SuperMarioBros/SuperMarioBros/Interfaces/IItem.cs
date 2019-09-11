using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using TreeNewBee.Collision;

namespace TreeNewBee.Interfaces
{
    public interface IItem
    {
        bool Collided { get; set; }
        IPhysics ItemPhysics { get; }
        Rectangle ItemBox { get; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void ChangeDirection(CollisionDetection.CollisionSide side);
    }
}
