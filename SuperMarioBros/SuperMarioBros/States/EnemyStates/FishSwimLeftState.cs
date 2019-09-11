using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.States.EnemyStates
{
    class FishSwimLeftState:IEnemyState
    {
        private Fish fish;
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Removal { get; set; }

        public FishSwimLeftState(Fish fish)
        {
            this.fish = fish;
            sprite = EnemyFactory.Instance.CreateFishSwimLeft();
            Width = sprite.Width;
            Height = sprite.Height;
            Removal = false;
        }

        public void BeFlipped()
        {
            fish.State = new FishFlippedState();
        }

        public void ChangeDirection()
        {
            fish.State = new FishSwimRightState(fish);
            fish.EnemyPhysics.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            fish.EnemyPhysics.Update(gameTime);
        }

        public void TakeDamage()
        {
            fish.State = new FishFlippedState();
        }

        public void BeStomped()
        {

        }
    }
}
