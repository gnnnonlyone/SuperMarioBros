using System;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.States.MarioStates;

namespace TreeNewBee.States.MarioStates
{
    class MarioMovingRightState : IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioMovingRightState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = true;
            if (mario.MarioPowerUpState is MarioBigState)
            {
                sprite = MarioFactory.Instance.CreateMarioBigRunRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState)
            {
                sprite = MarioFactory.Instance.CreateMarioFireRunRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallRunRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallInvincibleRunRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleRunRightSprite();
            }
            Width = sprite.Width;
            Height = sprite.Height;
        }
        public void Down()
        {
            if (!(mario.MarioPowerUpState is MarioSmallState) && !(mario.MarioPowerUpState is MarioSmallInvincibleState))
            {
                mario.MarioAnimatedState = new MarioCrouchRightState(mario);
            }
           
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }
        public void Walk()
        {
            //not use in this case
        }

        public void Idle()
        {
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }

        public void Left()
        {
            mario.MarioAnimatedState = new MarioIdleLeftState(mario);
        }

        public void Right()
        {
            //not used in this case
        }

        public void Up()
        {
            if (TreeNewBee.SuperMarioBros.Instance.Manager.IsHiddenWorld)
            {
                mario.MarioAnimatedState = new MarioSwimRightState(mario);
            }
            else
            {
                mario.MarioAnimatedState = new MarioJumpRightState(mario);
            }
           
        }

        public void Update(GameTime gameTime)
        {
         
            sprite.Update(gameTime);
        }
    }
}
