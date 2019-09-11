using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TreeNewBee.Enemies;
using SuperMarioBros.Constant;

namespace TreeNewBee.States.EnemyStates
{
    class GoombaStompedState : IEnemyState
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public bool Removal { get; set; }
        private ISprite sprite;
        private Goomba goomba;
        private double time;
        public GoombaStompedState(Goomba goomba)
        {
            this.goomba = goomba;
            sprite = EnemyFactory.Instance.CreateGoombaStompedSprite();
            Width = sprite.Width;
            Height = sprite.Height;
            time = Constant.Instance.MarioDelay;
            Removal = false;
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
             sprite.Draw(spriteBatch, position);  
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
            goomba.State = new GoombaFlippedState();
        }
    }
}
