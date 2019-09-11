using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.States.EnemyStates
{
    class JellyfishSwimState : IEnemyState
    {
        private Jellyfish jellyfish;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Removal { get; set; }

        public JellyfishSwimState(Jellyfish jellyfish)
        {
            this.jellyfish = jellyfish;
            sprite = EnemyFactory.Instance.CreateSwimJellyfish();
            Width = sprite.Width;
            Height = sprite.Height;
            Removal = false;
        }

        public void BeFlipped()
        {
            jellyfish.State = new JellyfishFlippedState();
        }

        public void ChangeDirection()
        {
            jellyfish.EnemyPhysics.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            jellyfish.EnemyPhysics.Update(gameTime);
        }

        public void TakeDamage()
        {
            jellyfish.State = new JellyfishFlippedState();
        }

        public void BeStomped()
        {
            
        }
    }
}
