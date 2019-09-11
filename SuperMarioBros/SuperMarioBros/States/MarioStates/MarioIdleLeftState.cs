
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.States.MarioStates;

namespace TreeNewBee.States.MarioStates
{
    class MarioIdleLeftState : IMarioAnimatedState
    {
        private IMario mario;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioIdleLeftState(IMario mario)
        {
            this.mario = mario;
            mario.IsFaceRight = false;

            if (mario.MarioPowerUpState is MarioBigState) {
                sprite = MarioFactory.Instance.CreateMarioBigIdleLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioFireState) {
                sprite = MarioFactory.Instance.CreateMarioFireIdleLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallState) { 
                sprite = MarioFactory.Instance.CreateMarioSmallIdleLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSmallInvincibleState) {
                sprite = MarioFactory.Instance.CreateMarioSmallInvincibleIdleLeftSprite();
            }
            else if (mario.MarioPowerUpState is MarioSuperInvincibleState) {
                sprite = MarioFactory.Instance.CreateMarioSuperInvincibleIdleLeftSprite();
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
            if(!(mario.MarioPowerUpState is MarioSmallState) && !(mario.MarioPowerUpState is MarioSmallInvincibleState))
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
            //not used is this case
        }

        public void Left()
        {
            mario.MarioAnimatedState = new MarioMovingLeftState(mario);
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
