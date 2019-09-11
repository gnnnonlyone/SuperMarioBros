using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PhysicalState
{
    class SwimMarioPhysics: IMarioPhysics
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public bool IsGround { get; set; }
        public Vector2 Gravity { get; set; }
        public bool IsRunning { get; set; }
        //to check if mario is running or not, save it for later implementation on accleration effect.

        public bool Dead { get; set; }
        public SwimMarioPhysics(Vector2 position)
        {
            Position = position;
            Velocity = Constant.Constant.Instance.SwimGravity;
            IsGround = true;
            IsRunning = false;
            Dead = false;
            Gravity = Constant.Constant.Instance.SwimGravity;
        }

        public void Down()
        {
            Velocity = new Vector2(Velocity.X, Constant.Constant.Instance.SwimGravityY);
        }
        public void MoveRight()
        {
             Velocity = new Vector2(Constant.Constant.Instance.SwimSpeedRight, Velocity.Y);

        }
        public void Idle()
        {
            Velocity = Gravity;
        }
        public void MoveLeft()
        {
            Velocity = new Vector2(Constant.Constant.Instance.SwimSpeedLeft, Velocity.Y);

        }

        public void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Velocity += Gravity * time;
            Position += Velocity * time;
        }

        public void Jump()
        {
            Velocity = new Vector2(Velocity.X, Constant.Constant.Instance.SwimJumpSpeed);
        }
    }
}
