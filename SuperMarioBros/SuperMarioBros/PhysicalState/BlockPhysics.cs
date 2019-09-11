using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PhysicalState
{
    public class BlockPhysics: IPhysics
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
    
        public BlockPhysics(Vector2 position)
        {
            Velocity = new Vector2();
            Acceleration = new Vector2();
            Position = position;
        }
        public void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Velocity * time;
        }
    }
}
