using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;

namespace TreeNewBee.Command
{
    public class MouseBasedCommand : ICommand
    {
        private SuperMarioBros superMarioBros;

        public MouseBasedCommand(SuperMarioBros superMarioBros)
        {
            this.superMarioBros = superMarioBros;
        }

        public void Execute()
        {
            //superMarioBros.MouseBasedController = !superMarioBros.MouseBasedController;
        }
    }
}
