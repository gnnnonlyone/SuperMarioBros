using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.Interfaces
{
    public interface IBlockState
    {
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        int Width { get; set; }
        int Height { get; set; }
        bool IsUsed { get; set; }
        void BecomeBroken();
        void BecomeUsed();
        void Hit();
        void Update(GameTime gameTime);
    }
}
