using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;

namespace SuperMarioBros.States.MarioStates
{
    class MarioSwimIdleRightState:IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioSwimIdleRightState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = true;

           sprite = MarioFactory.Instance.CreateSmallMarioSwimRightSprite();
            

            Width = sprite.Width;
            Height = sprite.Height;
        }
        public void Down()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Walk()
        {
            mario.MarioPowerUpState = new MarioBigState();
            mario.MarioAnimatedState = new MarioMovingRightState(mario);
        }

        public void Idle()
        {

        }

        public void Left()
        {
            mario.MarioAnimatedState = new MarioSwimIdleLeftState(mario);
        }

        public void Right()
        {
            mario.MarioAnimatedState = new MarioSwimRightState(mario);
        }

        public void Up()
        {

        }

        public void Update(GameTime gameTime)
        {

            sprite.Update(gameTime);
        }
    }
}
