using Microsoft.Xna.Framework;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class MarioRightCommand:ICommand
    {
        private IMario mario;

        public MarioRightCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Right();
        }
    }
}
