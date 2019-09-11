using TreeNewBee.Interfaces;
using TreeNewBee.States.BlockStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Interfaces;

namespace TreeNewBee.Blocks
{
    public class HiddenBlock: IBlock
    {
        public bool Collided { get; set; }
        public IBlockState StateMachine { get; set; }
        public IPhysics BlockPhysics { get; set; }
        public bool Broken { get; set; }
        public HiddenBlock(Vector2 position)
        {
            StateMachine = new BlockHiddenState();
            BlockPhysics = new BlockPhysics(position);
            Collided = false;
            Broken = false;
        }

        public void BecomeUsed()
        {
            StateMachine.BecomeUsed();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            StateMachine.Draw(spriteBatch,BlockPhysics.Position);
        }
        public Rectangle BlockBox => new Rectangle((int)BlockPhysics.Position.X, (int)BlockPhysics.Position.Y, StateMachine.Width, StateMachine.Height);

        public void Update(GameTime gameTime)
        {
        }

    }
}
