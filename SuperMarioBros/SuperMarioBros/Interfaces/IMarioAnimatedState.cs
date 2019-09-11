using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TreeNewBee.Interfaces
{
    public interface IMarioAnimatedState
    {
        int Width { get; set; }
        int Height { get; set; }
        void Idle();
        void Up();
        void Down();
        void Left();
        void Right();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch,Vector2 position);
        void Walk();
    }
}
