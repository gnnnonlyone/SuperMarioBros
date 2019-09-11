using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PhysicalState;

namespace TreeNewBee.States.BlockStates
{
    public class BlockQuestionState : IBlockState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsUsed { get; set; }
        public BlockPhysics BlockPhysics { get; set; }

        public BlockQuestionState()
        {
            
            sprite = BlockFactory.Instance.CreateQuestionBlock();
            Width = sprite.Width;
            Height = sprite.Height;
            IsUsed = false;
        }

        public void BecomeUsed()
        {
            sprite = BlockFactory.Instance.CreateUsedBlock();
        }
        public void BecomeBroken()
        {

        }
        public void Hit()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
