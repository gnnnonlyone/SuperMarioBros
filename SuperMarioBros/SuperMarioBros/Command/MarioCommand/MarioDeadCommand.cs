using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;

namespace TreeNewBee.Command
{
    public class MarioDeadCommand:ICommand
    {
        private IMario mario;

        public MarioDeadCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MarioAnimatedState = new MarioDeadState(mario);
        }
    }
}
