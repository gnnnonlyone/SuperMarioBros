using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.BlockStates
{
    public class BlockBrickState : IBlockState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsUsed { get; set; }
        public BlockBrickState()
        {
            sprite = BlockFactory.Instance.CreateBrickBlock();
            Width = sprite.Width;
            Height = sprite.Height;
            IsUsed = false;
        }
        public void BecomeUsed()
        {

        }
        public void Hit()
        {

        }
        public void BecomeBroken()
        {
            sprite = BlockFactory.Instance.CreateBrokenBlock();
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
