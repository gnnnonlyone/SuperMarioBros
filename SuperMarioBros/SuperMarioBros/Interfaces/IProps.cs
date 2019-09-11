using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Interfaces
{
    public interface IProps
    {
        Rectangle PropsBox { get; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
