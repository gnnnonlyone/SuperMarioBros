using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;

namespace TreeNewBee.Interfaces
{

    public interface IMario
    {
        IMarioPowerUpState MarioPowerUpState { get; set; }
        IMarioAnimatedState MarioAnimatedState { get; set; }
        IMarioPhysics MarioPhysics { get; set; }
        Vector2 OriginalPosition { get; set; }
        Rectangle MarioBox { get; }
        bool Invincible { get; set; }
        bool Fetch { get; set; }
        void Idle();
        void Up();
        void Down();
        void Left();
        void Right();
        void Update(GameTime gameTime);
        void Reset();
        void Draw(SpriteBatch spriteBatch);
        void TakeDamage();
        void Shoot();
        bool IsFaceRight { get; set; }

        void FetchFlag();
    }
}
