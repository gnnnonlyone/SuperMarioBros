using Microsoft.Xna.Framework;
using SuperMarioBros.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.Command
{
    class PauseCommand : ICommand
    {
        private GameStateManager gameStateManager;
        public PauseCommand(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }
        public void Execute()
        {
            gameStateManager.Pause();
        }
    }
}
