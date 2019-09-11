
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.MarioStates
{
    class MarioJumpRightState : IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioJumpRightState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = true;
            if (mario.MarioPowerUpState is MarioBigState)
            {
                sprite = MarioFactory.Instance.CreateMarioBigJumpRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState)
            {
                sprite = MarioFactory.Instance.CreateMarioFireJumpRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallJumpRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallInvincibleUpRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleUpRightSprite();
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
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }

        public void Idle()
        {
            //not used in this case
        }

        public void Left()
        {
            mario.MarioAnimatedState = new MarioJumpLeftState(mario);
        }

        public void Right()
        {
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }

        public void Up()
        {
            //not used in this case
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (mario.MarioPhysics.IsGround)
            {
                mario.MarioAnimatedState = new MarioIdleRightState(mario);
            }
        }
    }
}
