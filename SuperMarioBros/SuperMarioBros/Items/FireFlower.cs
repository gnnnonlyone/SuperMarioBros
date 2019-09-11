using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using TreeNewBee.Collision;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Items
{
    public class FireFlower : IItem
    {
        public bool Collided { get; set; }
        public IPhysics ItemPhysics { get; private set; }
        private ISprite sprite;
        
        public FireFlower(Vector2 position)
        {
            ItemPhysics = new ItemPhysics(position);
            sprite = ItemFactory.Instance.CreateFlowerItem();
            Collided = false;
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
