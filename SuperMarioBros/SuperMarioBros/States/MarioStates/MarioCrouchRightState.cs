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
    class MarioCrouchRightState : IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioCrouchRightState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = true;

            if (mario.MarioPowerUpState is MarioBigState)
            {
                sprite = MarioFactory.Instance.CreateMarioBigCrouchRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState)
            {
                sprite = MarioFactory.Instance.CreateMarioFireCrouchRightSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleDownRightSprite();
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
            //not use is this case
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
            mario.MarioAnimatedState = new MarioCrouchLeftState(mario);
        }

        public void Right()
        {
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }

        public void Up()
        {
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }


        public void Update(GameTime gameTime)
        {

            sprite.Update(gameTime);
        }
    }
}
