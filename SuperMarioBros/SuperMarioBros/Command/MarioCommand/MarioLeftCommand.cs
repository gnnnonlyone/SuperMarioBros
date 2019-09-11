using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class MarioLeftCommand:ICommand
    {
        private IMario mario;

        public MarioLeftCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Left();
        }
    }
}
