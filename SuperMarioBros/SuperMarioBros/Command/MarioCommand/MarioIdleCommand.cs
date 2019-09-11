using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class MarioIdleCommand:ICommand
    {
        private IMario mario;

        public MarioIdleCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Idle();
        }
    }
}
