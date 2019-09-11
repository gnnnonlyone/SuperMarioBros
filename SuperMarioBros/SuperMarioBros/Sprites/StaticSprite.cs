using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.Sprites
{
    class StaticSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle sourceRectangle;

        public StaticSprite(Texture2D texture, Rectangle sourceRectangle)
        {
            Texture = texture;
            Width = texture.Width;
            Height = texture.Height;
            this.sourceRectangle = sourceRectangle;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
