using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Controller;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.GameState
{
    class PauseState : IGameState
    {
        private IWorld world;
        private GameStateManager thisManager;
        public PauseState(GameStateManager manager)
        {
            world = manager.World;
            TreeNewBee.SuperMarioBros.Instance.GlobalController = new KeyboardController();
            TreeNewBee.SuperMarioBros.Instance.AddCommand(TreeNewBee.SuperMarioBros.Instance.GlobalController, world.Mario);
            TreeNewBee.SuperMarioBros.RemoveCommand(TreeNewBee.SuperMarioBros.Instance.GlobalController);
            thisManager = manager;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (thisManager.IsHiddenWorld)
            {
                TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Clear(Color.Blue);
            }
            else
            {
                TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            world.Draw(spriteBatch);
        }


        public void Update(GameTime gameTime)
        {
            //not update during pause
        }
    }
}
