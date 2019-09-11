using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;
using TreeNewBee.MarioClass;

namespace SuperMarioBros.Interfaces
{
    public interface IPhysicalState
    {
        void Update(GameTime gameTime);
        void Jump(Mario mario);
        void Fall(Mario mario);
    }
}
