using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.PhysicalState
{
    public class MarioPhysics : IMarioPhysics
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public bool IsGround { get; set; }
        public Vector2 Gravity { get; set; }
        public bool IsRunning { get; set; } 
        //to check if mario is running or not, save it for later implementation on accleration effect.
      
        public bool Dead { get; set; }
        public MarioPhysics(Vector2 position)
        {
            Position = position;
            Velocity = new Vector2();
            Acceleration = new Vector2();
            IsGround = true;
            IsRunning = false;
            Dead = false;
            Gravity = new Vector2(0, Constant.Constant.Instance.GeneralGravity);
        }
  
        public void Jump()
        {
            if (IsGround)
            {
                Velocity = new Vector2(Velocity.X, Constant.Constant.Instance.MarioJumpSpeed);
                IsGround = false;
            }
        }

        public void MoveRight()
        {
            if (IsGround)
            {
                Velocity = new Vector2(Constant.Constant.Instance.MarioRunningRightSpeed, Velocity.Y);
            }
            else
            {
                if (Velocity.X < Constant.Constant.Instance.MarioAirRightSpeedLimit)
                {
                    Velocity = new Vector2(Constant.Constant.Instance.MarioAirRightSpeedLimit, Velocity.Y);
                }
            }
        }

        public void MoveLeft()
        {
            if (IsGround)
            {
                Velocity = new Vector2(Constant.Constant.Instance.MarioRunningLeftSpeed, Velocity.Y);
            }
            else
            {
                if (Velocity.X >= Constant.Constant.Instance.MarioAirLeftSpeedLimit)
                {
                    Velocity = new Vector2(Constant.Constant.Instance.MarioAirLeftSpeedLimit, Velocity.Y);
                }
            }
            
        }
        
        public void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Velocity += Gravity * time;
            Position += Velocity * time;
        }

        public void Down()
        {
           
        }

        public void Idle()
        {
            
        }
    }
}
