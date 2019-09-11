using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;

namespace TreeNewBee.Command
{
    public class MarioSmallCommand :ICommand
    {
        private IMario mario;

        public MarioSmallCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MarioPowerUpState = new MarioSmallState();
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }
    }
}
