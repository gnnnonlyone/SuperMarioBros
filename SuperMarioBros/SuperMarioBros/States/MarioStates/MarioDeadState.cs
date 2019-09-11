using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.MarioStates
{
    class MarioDeadState : IMarioAnimatedState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public MarioDeadState(IMario mario)
        {
            sprite = MarioFactory.Instance.CreateMarioDeadSprite();
            Width = sprite.Width;
            Height = sprite.Height;
            mario.MarioPhysics.Dead = true;
        }

        public void Idle()
        {
            // Nothing here to do...
        }
        public void Walk()
        {
            //not use in this case
        }

        public void Up()
        {
            // Nothing here to do...
        }

        public void Down()
        {
            // Nothing here to do...
        }

        public void Left()
        {
            // Nothing here to do...
        }
        
        public void Right()
        {
            // Nothing here to do...
        }

        public void Update(GameTime gameTime)
        {
           // sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }
    }
}