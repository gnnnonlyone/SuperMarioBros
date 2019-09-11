using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.States.EnemyStates
{
    class JellyfishFlippedState:IEnemyState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Removal { get; set; }
        private double time;
        private ISprite sprite;

        public JellyfishFlippedState()
        {
            sprite = EnemyFactory.Instance.CreateFlippedJellyfish();
            Width = sprite.Width;
            Height = sprite.Height;
            Removal = false;
            time = Constant.Constant.Instance.MarioDelay;
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
            if (time > Constant.Constant.Instance.InitialTime)
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
