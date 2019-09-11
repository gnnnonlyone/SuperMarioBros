using TreeNewBee.Interfaces;
using TreeNewBee.States.BlockStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Interfaces;

namespace TreeNewBee.Blocks
{
    public class UsedBlock: IBlock
    {
        public bool Collided { get; set; }
        public bool Broken { get; set; }
        public IBlockState StateMachine { get; set; }
        public IPhysics BlockPhysics { get; set; }
        public UsedBlock(Vector2 position)
        {
            StateMachine = new BlockUsedState();
            BlockPhysics = new BlockPhysics(position);
            Collided = false;
            Broken = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            StateMachine.Draw(spriteBatch,BlockPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
        }

        public Rectangle BlockBox => new Rectangle((int)BlockPhysics.Position.X, (int)BlockPhysics.Position.Y, StateMachine.Width, StateMachine.Height);
    }
}
