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
    class DelayState:IGameState
    {
        //private IWorld world;
        private double time;
        public DelayState()
        {
            //world = manager.World;
            TreeNewBee.SuperMarioBros.RemoveCommand(TreeNewBee.SuperMarioBros.Instance.GlobalController);
            time = Constant.Constant.Instance.ResetPauseTime;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           // world.Draw(spriteBatch);
        }

        
       public static void ReturnToStart()
        {
            TreeNewBee.SuperMarioBros.Instance.Manager = new GameStateManager();
            TreeNewBee.SuperMarioBros.Instance.World = TreeNewBee.SuperMarioBros.Instance.Manager.World;
            TreeNewBee.SuperMarioBros.Instance.GlobalController = new KeyboardController();
            TreeNewBee.SuperMarioBros.Instance.AddCommand(TreeNewBee.SuperMarioBros.Instance.GlobalController, TreeNewBee.SuperMarioBros.Instance.World.Mario);
        }

        public void Update(GameTime gameTime)
        {
           // world.Update(gameTime);
            if (time > Constant.Constant.Instance.TimeBoundary)
            {
                time -= gameTime.ElapsedGameTime.TotalSeconds;
                if (time <= Constant.Constant.Instance.TimeBoundary)
                {
                    ReturnToStart();
                }
            }
        }
    }
}
