
using TreeNewBee.Enemies;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using TreeNewBee.States.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TreeNewBee.States.EnemyStates
{
    class KoopaMovingState : IEnemyState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Removal { get; set; }
        private Koopa koopa;
        private ISprite sprite;

        public KoopaMovingState(Koopa koopa)
        {
            this.koopa = koopa;
            sprite = EnemyFactory.Instance.CreateKoopaMovingSprite();
            Width = sprite.Width;
            Height = sprite.Height;
            Removal = false;
        }

        public void BeFlipped()
        {
            koopa.State = new KoopaFlippedState();
        }

        public void BeStomped()
        {
            koopa.State = new KoopaStompedState(koopa);
        }

        public void ChangeDirection()
        {
            koopa.EnemyPhysics.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            koopa.EnemyPhysics.Update(gameTime);
            koopa.EnemyPhysics.Walk();
        }

        public void TakeDamage()
        {
            koopa.State = new KoopaFlippedState();
        }
    }
}
