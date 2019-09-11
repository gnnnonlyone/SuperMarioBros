using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Factories;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.Props
{
    class FlagPole : IProps
    {
        public bool ShouldLowerFlag { get; set; }
        private ISprite sprite;
        private Vector2 position;
        public FlagPole(Vector2 position)
        {
            this.position = position;
            sprite = PropFactory.Instance.CreateFlagPole();
            ShouldLowerFlag = false;
        }

        public void Update(GameTime gameTime)
        {
            if (ShouldLowerFlag)
            {
                sprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
        public Rectangle PropsBox => new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
    }
}
