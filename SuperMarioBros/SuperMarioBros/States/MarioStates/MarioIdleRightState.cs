using System;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.States.MarioStates;

namespace TreeNewBee.States.MarioStates
{
    class MarioIdleRightState : IMarioAnimatedState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private IMario mario;
        private ISprite sprite;

        public MarioIdleRightState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = true;
            if (mario.MarioPowerUpState is MarioBigState)
            {
                sprite = MarioFactory.Instance.CreateMarioBigIdleRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState)
            {
                sprite = MarioFactory.Instance.CreateMarioFireIdleRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallIdleRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSmallInvincibleIdleRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleIdleRightSprite();
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
                mario.MarioAnimatedState = new MarioCrouchRightState(mario);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
           sprite.Draw(spriteBatch,position);
            
        }

        public void Idle()
        {
            //not use in this case
        }

        public void Left()
        {
            mario.MarioAnimatedState = new MarioIdleLeftState(mario);
        }

        public void Right()
        {
            mario.MarioAnimatedState = new MarioMovingRightState(mario);
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
