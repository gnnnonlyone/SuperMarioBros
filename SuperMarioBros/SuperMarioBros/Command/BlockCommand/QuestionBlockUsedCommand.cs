using TreeNewBee.Blocks;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command.BlockCommand
{
    public class QuestionBlockUsedCommand : ICommand
    {
        private QuestionBlock questionBlock;

        public QuestionBlockUsedCommand(QuestionBlock block)
        {
            questionBlock = block;
        }
        public void Execute()
        {
            questionBlock.BecomeUsed();
        }
    }
}
