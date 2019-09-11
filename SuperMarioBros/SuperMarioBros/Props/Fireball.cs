using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Factories;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.Props
{
    public class Fireball : IProps
    {
        private ISprite sprite;
        public FireballPhysics FireballPhysics { get; set; }
        public bool Dead { get; set; }
        public Fireball(bool faceRight, Vector2 Position)
        {
            Dead = false;
            FireballPhysics = new FireballPhysics(Position);
            if (faceRight)
            {
                sprite = PropFactory.Instance.CreateFireballRight();
            }
            else
            {
                sprite = PropFactory.Instance.CreateFireballLeft();
            }
            Shoot(faceRight);
        }


        public void Shoot(bool faceRight)
        {
            if (faceRight)
            {
                FireballPhysics.MoveRight();
            }
            else
            {
                FireballPhysics.MoveLeft();
            }

        }

        public void Update(GameTime gameTime)
        {
            FireballPhysics.Update(gameTime);
            if(FireballPhysics.OutOfBoundary)
            {
                Dead = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, FireballPhysics.Position);
        }

        public Rectangle PropsBox => new Rectangle((int)FireballPhysics.Position.X, (int)FireballPhysics.Position.Y, sprite.Width, sprite.Height);
    }
}
