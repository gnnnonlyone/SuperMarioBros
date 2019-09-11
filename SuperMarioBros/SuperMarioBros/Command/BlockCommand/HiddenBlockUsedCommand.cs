using TreeNewBee.Blocks;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command.BlockCommand
{
    public class HiddenBlockUsedCommand : ICommand
    {
        private HiddenBlock hiddenBlock;

        public HiddenBlockUsedCommand(HiddenBlock block)
        {
            hiddenBlock = block;
        }
        public void Execute()
        {
            hiddenBlock.BecomeUsed();
        }
    }
}
