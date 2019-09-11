using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;

namespace TreeNewBee.Interfaces
{
    public interface IBlock
    {
        Rectangle BlockBox { get;}
        IPhysics BlockPhysics { get; set; }
        IBlockState StateMachine { get; set; }
        bool Collided { get; set; }
        bool Broken { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}