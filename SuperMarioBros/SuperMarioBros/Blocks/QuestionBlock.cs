using TreeNewBee.Interfaces;
using TreeNewBee.States.BlockStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TreeNewBee.Factory;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Interfaces;

namespace TreeNewBee.Blocks
{
    public class QuestionBlock: IBlock
    {
        public bool Collided { get; set; }
        public IBlockState StateMachine { get; set; }
        public IPhysics BlockPhysics { get; set; }
        public bool Broken { get; set; }
        public QuestionBlock(Vector2 position)
        {
            StateMachine = new BlockQuestionState();
            Collided = false;
            BlockPhysics = new BlockPhysics(position);
            Broken = false;
        }

        public void BecomeUsed()
        {
            Broken = true;
            StateMachine.BecomeUsed();
        }

        public void CreateItem()
        {
            if (!Broken)
            {
                ItemFactory.CreateItem(BlockPhysics.Position);
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            StateMachine.Draw(spriteBatch, BlockPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
            StateMachine.Update(gameTime);
        }
        public Rectangle BlockBox => new Rectangle((int)BlockPhysics.Position.X, (int)BlockPhysics.Position.Y, StateMachine.Width, StateMachine.Height);
    }
    
}
