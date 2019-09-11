using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;

namespace TreeNewBee.Command
{
    public class MarioFireCommand:ICommand
    {
        private IMario mario;

        public MarioFireCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MarioPowerUpState = new MarioFireState();
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }
    }
}
