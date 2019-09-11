using Microsoft.Xna.Framework;
using TreeNewBee.Interfaces;
using TreeNewBee.Factory;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Interfaces;
using TreeNewBee.Collision;

namespace TreeNewBee.Items
{
    public class Coin : IItem
    {
        public IPhysics ItemPhysics  { get; private set; }
        public bool Collided { get; set; }
        private ISprite sprite;
        public Coin(Vector2 position)
        {
            ItemPhysics = new ItemPhysics(position);
            sprite = ItemFactory.Instance.CreateCoinItem();
            Collided = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, ItemPhysics.Position);
        }
        
        public void ChangeDirection (CollisionDetection.CollisionSide side)
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
