using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.States.MarioStates;

namespace TreeNewBee.States.MarioStates
{
    class MarioMovingLeftState : IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioMovingLeftState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = false;

            if (mario.MarioPowerUpState is MarioBigState)
            {
                sprite = MarioFactory.Instance.CreateMarioBigRunLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState)
            {
                sprite = MarioFactory.Instance.CreateMarioFireRunLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallRunLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallInvincibleRunLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleRunLeftSprite();
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
            if (!(mario.MarioPowerUpState is MarioSmallState) && !(mario.MarioPowerUpState is MarioSmallInvincibleState))
            {
                mario.MarioAnimatedState = new MarioCrouchLeftState(mario);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }

        public void Idle()
        {
            mario.MarioAnimatedState = new MarioIdleLeftState(mario);
        }

        public void Left()
        {
           //not used in this case
        }

        public void Right()
        {
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }

        public void Up()
        {
            if (TreeNewBee.SuperMarioBros.Instance.Manager.IsHiddenWorld)
            {
                mario.MarioAnimatedState = new MarioSwimLeftState(mario);
            }
            else
            {
                mario.MarioAnimatedState = new MarioJumpLeftState(mario);
            }
           
        }

        public void Update(GameTime gameTime)
        {
    
            sprite.Update(gameTime);
        }
    }
}
