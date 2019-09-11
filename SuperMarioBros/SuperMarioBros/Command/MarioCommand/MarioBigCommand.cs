using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;

namespace TreeNewBee.Command
{
    public class MarioBigCommand : ICommand
    {
        private IMario mario;

        public MarioBigCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MarioPowerUpState = new MarioBigState();
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }
    }
}
