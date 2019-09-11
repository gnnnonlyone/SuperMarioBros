using TreeNewBee.Blocks;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command.BlockCommand
{
    public class BrickBlockBrokenCommand : ICommand
    {
        private BrickBlock brickBlock;

        public BrickBlockBrokenCommand(BrickBlock block)
        {
            brickBlock = block;
        }
        public void Execute()
        {
            brickBlock.BecomeBroken();
        }
    }
}
