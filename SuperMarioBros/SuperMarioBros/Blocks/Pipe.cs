using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Interfaces;

namespace TreeNewBee.Blocks
{
    public class Pipe: IBlock
    {
      
        public IBlockState StateMachine { get; set; }
        public bool Collided { get; set; }
        public bool Broken { get; set; }
        public IPhysics BlockPhysics { get; set; }
        private ISprite blockSprite;


        public Pipe(Vector2 position)
        {
            blockSprite = BlockFactory.Instance.CreatePipe();
            BlockPhysics = new BlockPhysics(position);
            Collided = false;
            Broken = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch,BlockPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
        }

        public Rectangle BlockBox => new Rectangle((int)BlockPhysics.Position.X, (int)BlockPhysics.Position.Y, blockSprite.Width, blockSprite.Height);
    }
}
