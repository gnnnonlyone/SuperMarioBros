using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TreeNewBee.States.BlockStates
{
    public class BlockBlankState : IBlockState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsUsed { get; set; }
        public BlockBlankState()
        {

            sprite = BlockFactory.Instance.CreateBlankBlock();
            Width = sprite.Width;
            Height = sprite.Height;
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
            sprite.Draw(spriteBatch, position);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
