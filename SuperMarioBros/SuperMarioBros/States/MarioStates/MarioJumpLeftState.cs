
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.MarioStates
{
    class MarioJumpLeftState : IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioJumpLeftState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = false;

            if (mario.MarioPowerUpState is MarioBigState)
            {
                sprite = MarioFactory.Instance.CreateMarioBigJumpLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState)
            {
                sprite = MarioFactory.Instance.CreateMarioFireJumpLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallJumpLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallInvincibleUpLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleUpLeftSprite();
            }
            Width = sprite.Width;
            Height = sprite.Height;

        }

        public void Walk()
        {
            //not use in this case
        }
        public void Down()
        {
            mario.MarioAnimatedState = new MarioIdleLeftState(mario);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }
 
        public void Idle()
        {
            //not used in this case
        }

        public void Left()
        {
            mario.MarioAnimatedState = new MarioIdleLeftState(mario);
        }

        public void Right()
        {
            mario.MarioAnimatedState = new MarioJumpRightState(mario);
        }

        public void Up()
        {
            //not used in this case
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if(mario.MarioPhysics.IsGround)
            {
                mario.MarioAnimatedState = new MarioIdleLeftState(mario);
            }
        }
    }
}
