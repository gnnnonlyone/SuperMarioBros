using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Blocks
{
    public class GroundBlock : IBlock
    {
        public IBlockState StateMachine{ get; set; }
        public bool Collided { get; set; }

        private ISprite blockSprite;
        public bool Broken { get; set; }
        public IPhysics BlockPhysics { get; set; }
        public GroundBlock(Vector2 location)
        {
            blockSprite = BlockFactory.Instance.CreateGroundBlockSprite();
            Collided = false;
            BlockPhysics = new BlockPhysics(location);
            Broken = false;
        }
        public Rectangle BlockBox => new Rectangle((int)BlockPhysics.Position.X, (int)BlockPhysics.Position.Y, blockSprite.Width, blockSprite.Height);

        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, BlockPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
        }

    }
}
