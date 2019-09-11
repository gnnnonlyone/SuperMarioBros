using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.States.BlockStates
{
    class UnderwaterBlockState : IBlockState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsUsed { get; set; }
        public UnderwaterBlockState()
        {

            sprite = BlockFactory.Instance.CreateUnderwaterBlock();
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
