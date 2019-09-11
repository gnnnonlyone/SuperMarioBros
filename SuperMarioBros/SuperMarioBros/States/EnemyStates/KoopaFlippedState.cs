
using TreeNewBee.Enemies;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Constant;

namespace TreeNewBee.States.EnemyStates
{
    class KoopaFlippedState:IEnemyState
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public bool Removal { get; set; }
        private double time;
        private ISprite sprite;

        public KoopaFlippedState()
        {
            sprite = EnemyFactory.Instance.CreateKoopaFlippedSprite();
            Width = sprite.Width;
            Height = sprite.Height;
            Removal = false;
            time = Constant.Instance.MarioDelay;
        }

        public void BeFlipped()
        {
            
        }

        public void BeStomped()
        {
            
        }

        public void ChangeDirection()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }

        public void Update(GameTime gameTime)
        {
            time -= gameTime.ElapsedGameTime.TotalSeconds;
            if (time > Constant.Instance.InitialTime)
            {
                sprite.Update(gameTime);

            }
            else
            {
                Removal = true;
            }
        }

        public void TakeDamage()
        {
            //do nothing
        }
    }
}
