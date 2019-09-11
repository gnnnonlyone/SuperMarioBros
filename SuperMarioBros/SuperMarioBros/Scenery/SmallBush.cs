using Microsoft.Xna.Framework;
using TreeNewBee.Interfaces;
using TreeNewBee.Factories;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.Scenery
{
    public class SmallBush : IScenery
    {
        public Vector2 position { get; set; }
        public Rectangle ScenerayBox { get; }
        private ISprite sprite;

        public SmallBush(Vector2 position)
        {
            this.position = position;
            sprite = SceneryFactory.Instance.CreateSmallBush();

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