using SuperMarioBros.GameState;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class ResetCommand : ICommand
    {
        private SuperMarioBros superMarioBros;
        //private WorldStateManager worldStateManager;

        public ResetCommand(SuperMarioBros superMarioBros)
        {
            this.superMarioBros = superMarioBros;
        }

        public void Execute()
        {
            superMarioBros.Reset();
        }
    }
}
