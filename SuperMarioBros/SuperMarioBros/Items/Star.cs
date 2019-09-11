using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using TreeNewBee.Collision;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Items
{
    public class Star : IItem
    {
        public bool Collided { get; set; }
        public IPhysics ItemPhysics { get; private set; }
        private ISprite sprite;
        public Star(Vector2 position)
        {
            sprite = ItemFactory.Instance.CreateStarItem();
            Collided = false;
            ItemPhysics = new ItemPhysics(position);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, ItemPhysics.Position);
        }

        public void ChangeDirection(CollisionDetection.CollisionSide side)
        {
            (ItemPhysics as ItemPhysics).ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            ItemPhysics.Update(gameTime);
            sprite.Update(gameTime);
        }


        public Rectangle ItemBox => new Rectangle((int)ItemPhysics.Position.X, (int)ItemPhysics.Position.Y, sprite.Width, sprite.Height);
    }
}
