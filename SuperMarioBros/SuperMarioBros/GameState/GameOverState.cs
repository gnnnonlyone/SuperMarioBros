using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.GameState
{
    class GameOverState : IGameState
    {
        public GameOverState()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Clear(Color.Black);
        }


        public void Update(GameTime gameTime)
        {
            //not update when game over
        }
    }
}
