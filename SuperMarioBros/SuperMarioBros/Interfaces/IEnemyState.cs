using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TreeNewBee.Interfaces
{
    public interface IEnemyState
    {
        int Width { get; set; }
        int Height { get; set; }

        bool Removal { get; set; }
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void Update(GameTime gameTime);
        void TakeDamage();
    }
}
