using Microsoft.Xna.Framework;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class MarioCrouchCommand:ICommand
    {
        private IMario mario;
        public MarioCrouchCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Down();
        }
    }
}
