using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class QuitCommand : ICommand
    {
        private SuperMarioBros game;
        public QuitCommand(SuperMarioBros game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
