using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.BlockStates
{
    public class BlockBrokenState: IBlockState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsUsed { get; set; }

        public BlockBrokenState()
        {
            Width = sprite.Width;
            Height = sprite.Height;
            sprite = BlockFactory.Instance.CreateBrokenBlock();
            IsUsed = false;
        }
        public void BecomeUsed()
        {

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
