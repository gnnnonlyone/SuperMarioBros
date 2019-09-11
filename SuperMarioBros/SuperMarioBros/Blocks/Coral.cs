using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.States.BlockStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.Blocks
{
    class Coral:IBlock
    {
        public IBlockState StateMachine { get; set; }

        public bool Collided { get; set; }
        public IPhysics BlockPhysics { get; set; }
        public bool Broken { get; set; }
        public Coral(Vector2 position)
        {
            StateMachine = new CoralState();
            BlockPhysics = new BlockPhysics(position);
            Collided = false;
            Broken = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            StateMachine.Draw(spriteBatch, BlockPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
            StateMachine.Update(gameTime);
        }
        public Rectangle BlockBox => new Rectangle((int)BlockPhysics.Position.X, (int)BlockPhysics.Position.Y, StateMachine.Width, StateMachine.Height);
    }
}
