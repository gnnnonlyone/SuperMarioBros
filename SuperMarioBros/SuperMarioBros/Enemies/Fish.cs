using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.States.EnemyStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;
using static TreeNewBee.Collision.CollisionDetection;

namespace SuperMarioBros.Enemies
{
    class Fish:IEnemy
    {
        public IEnemyState State { get; set; }
        public Rectangle EnemyBox => new Rectangle((int)EnemyPhysics.Position.X, (int)EnemyPhysics.Position.Y, State.Width, State.Height);
        public IEnemyPhysics EnemyPhysics { get; set; }
        public bool Collidable { get; set; }
        public bool Flipped { get; set; }

        public Fish(Vector2 position)
        {
            State = new FishSwimLeftState(this);
            EnemyPhysics = new SwimFishPhysics(position);
            Collidable = true;
            Flipped = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, EnemyPhysics.Position);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void ChangeDirection(CollisionSide side)
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
