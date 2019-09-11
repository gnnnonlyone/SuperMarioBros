using Microsoft.Xna.Framework;
using TreeNewBee.Interfaces;
using TreeNewBee.Factories;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.Scenery
{
   public class BigCloud : IScenery
    {
        public Vector2 position { get; set; }
        public Rectangle ScenerayBox { get; }
        private ISprite sprite;

        public BigCloud(Vector2 position)
        {
            this.position = position;
            sprite = SceneryFactory.Instance.CreateHugeCloud();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
        }
        public Rectangle SceneryBox => new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
    }
}