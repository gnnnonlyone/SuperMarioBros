using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TreeNewBee.Sprites
{
    public class AnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private readonly int totalFrames;
        private readonly int updatesPerFrame = 10;
        private int currentUpdate;
        private bool loop;

        public AnimatedSprite(Texture2D texture, int rows, int columns,bool loop)
        {
            Texture = texture;
            this.Rows = rows;
            this.Columns = columns;
            currentFrame = 0;
            currentUpdate = 0;
            totalFrames = this.Rows * this.Columns;
            Width = texture.Width/columns;
            Height = texture.Height/rows;
            this.loop = loop;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            currentUpdate++;
            if (currentUpdate == updatesPerFrame)
            {
                currentUpdate = 0;
                if (loop)
                {
                    currentFrame++;

                    if (currentFrame == totalFrames)
                    {

                        currentFrame = 0;
                    }
                }
                else
                {
                    if (currentFrame < totalFrames-1)
                    {
                        currentFrame++;
                    }
                }
                
                    
            }
        }
    }
}
