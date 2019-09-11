using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.BlockStates
{
    public class BlockHiddenState : IBlockState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsUsed { get; set; }

        public BlockHiddenState()
        {
            sprite = BlockFactory.Instance.CreateHiddenBlock();
            Width = sprite.Width;
            Height = sprite.Height;
            
            IsUsed = false;
        }

        public void BecomeUsed()
        {
            sprite = BlockFactory.Instance.CreateUsedBlock();
            IsUsed = true;
        }

        public void BecomeBroken()
        {

        }
        public void Hit()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

    }
}
