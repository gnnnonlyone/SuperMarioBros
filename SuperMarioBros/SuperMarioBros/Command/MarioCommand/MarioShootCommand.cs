using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TreeNewBee.Interfaces;
using ICommand = TreeNewBee.Interfaces.ICommand;

namespace TreeNewBee.Command
{
    public class MarioShootCommand: ICommand
    {
        private IMario mario;

        public MarioShootCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Shoot();
        }
    }
}
