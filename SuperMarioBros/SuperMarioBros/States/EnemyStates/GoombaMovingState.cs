using TreeNewBee.Enemies;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TreeNewBee.States.EnemyStates
{
    class GoombaMovingState : IEnemyState
    {
        private Goomba goomba;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Removal { get; set; }

        public GoombaMovingState(Goomba goomba)
        {
            this.goomba = goomba;
            sprite = EnemyFactory.Instance.CreateGoombaMovingLeftSprite();
            Width = sprite.Width;
            Height = sprite.Height;
            Removal = false;
        }

        public void BeFlipped()
        {
            goomba.State = new GoombaFlippedState();
        }

        public void BeStomped()
        {
            goomba.State = new GoombaStompedState(goomba);
        }

        public void ChangeDirection()
        {
            goomba.EnemyPhysics.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            goomba.EnemyPhysics.Update(gameTime);
        }

        public void TakeDamage()
        {
            goomba.State = new GoombaFlippedState();
        }
    }
}