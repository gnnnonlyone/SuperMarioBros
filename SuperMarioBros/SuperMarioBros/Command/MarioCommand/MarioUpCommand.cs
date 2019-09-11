using Microsoft.Xna.Framework;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class MarioUpCommand :ICommand
    {
        private IMario mario;

        public MarioUpCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Up();
        }
    }
}
