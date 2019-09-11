using TreeNewBee.Interfaces;
using TreeNewBee.States.BlockStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TreeNewBee.Collision;
using static TreeNewBee.Collision.CollisionDetection;
using TreeNewBee.States.MarioStates;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Interfaces;
using TreeNewBee.Factory;
using SuperMarioBros.Factories;

namespace TreeNewBee.Blocks
{
   public class BrickBlock: IBlock
    {
        public IBlockState StateMachine { get; set; }
        public IPhysics BlockPhysics { get; set; }
        public bool Collided { get; set; }
        public bool Broken { get; set; }
        public BrickBlock(Vector2 position)
        {
            StateMachine = new BlockBrickState();
            BlockPhysics = new BlockPhysics(position);
            Collided = false;
            Broken = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            StateMachine.Draw(spriteBatch, BlockPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
            //stateMachine.Update(gameTime); to be implemented in upcoming sprints
        }
        public void BecomeBroken()
        {
            StateMachine.BecomeBroken();

        }

        public Rectangle BlockBox => new Rectangle((int)BlockPhysics.Position.X, (int)BlockPhysics.Position.Y, StateMachine.Width, StateMachine.Height);

    }
}
