using TreeNewBee.Enemies;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.States.EnemyStates
{
    public class KoopaRevivingState:IEnemyState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Removal { get; set; }
        private Koopa koopa;
        private ISprite sprite;

        public KoopaRevivingState(Koopa koopa)
        {
            this.koopa = koopa;
            sprite = EnemyFactory.Instance.CreateKoopaRevivingSprite();
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
            
        }

        public void BeRivived()
        {
            koopa.State = new KoopaRevivingState(koopa);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch,position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void TakeDamage()
        {
            koopa.State = new KoopaFlippedState();
        }
    }
}
