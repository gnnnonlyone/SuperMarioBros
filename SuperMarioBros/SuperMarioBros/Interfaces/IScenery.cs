using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeNewBee.Interfaces
{
    public interface IScenery
    {
        Vector2 position { get; set; }
        Rectangle ScenerayBox { get; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
