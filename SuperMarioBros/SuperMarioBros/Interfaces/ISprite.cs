using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TreeNewBee.Interfaces
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
