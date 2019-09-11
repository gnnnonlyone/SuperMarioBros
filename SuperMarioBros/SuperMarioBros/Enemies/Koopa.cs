using TreeNewBee.Interfaces;
using TreeNewBee.States.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Interfaces;

namespace TreeNewBee.Enemies
{
    public class Koopa : IEnemy
    {
        public IEnemyState State { get; set; }
        public Rectangle EnemyBox => new Rectangle((int)EnemyPhysics.Position.X, (int)EnemyPhysics.Position.Y, State.Width, State.Height);
        public IEnemyPhysics EnemyPhysics { get; set; }
        public bool Collidable { get; set; }

        public bool Flipped { get; set; }

        public Koopa(Vector2 position)
        {
            State = new KoopaMovingState(this);
            EnemyPhysics = new EnemyPhysics(position);
            Collidable = true;
            Flipped = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch,EnemyPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void ChangeDirection(Collision.CollisionDetection.CollisionSide side)
        {
            State.ChangeDirection();
        }

        public void BeStomped()
        {
            State.BeStomped();
            Collidable = false;
        }

        public void BeFlipped()
        {
            Flipped = true;
            State.BeFlipped();
        }
    }
}
