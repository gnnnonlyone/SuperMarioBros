using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.MarioStates
{
    class MarioCrouchLeftState : IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioCrouchLeftState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = false;

            if (mario.MarioPowerUpState is MarioBigState)
            {
                sprite = MarioFactory.Instance.CreateMarioBigCrouchLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState)
            {
                sprite = MarioFactory.Instance.CreateMarioFireCrouchLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleDownLeftSprite();
            }
            Width = sprite.Width;
            Height = sprite.Height;
        }
        public void Down()
        {
            //not use in this case
        }
        public void Walk()
        {
            //not use in this case
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
            mario.MarioAnimatedState = new MarioIdleLeftState(mario);
        }

        public void Right()
        {
            mario.MarioAnimatedState = new MarioCrouchRightState(mario);
        }

        public void Up()
        {
            mario.MarioAnimatedState = new MarioIdleLeftState(mario);
        }
        
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
