using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using System;
using SuperMarioBros.Props;
using SuperMarioBros.GameState;
using SuperMarioBros.Factories;
using SuperMarioBros.Constant;

namespace TreeNewBee.MarioClass
{
    public class Mario : IMario
    {
        public IMarioAnimatedState MarioAnimatedState { get; set; }
        public IMarioPowerUpState MarioPowerUpState { get; set; }
        public IMarioPhysics MarioPhysics { get; set; }
        public Vector2 OriginalPosition { get; set; }
        public bool Invincible { get; set; }
        public bool IsFaceRight { get; set; }
        public bool Fetch{ get; set; }

        private bool action;
        private readonly double delay = Constant.Instance.MarioDelay;
        private double time;
        public Rectangle MarioBox => new Rectangle((int)MarioPhysics.Position.X, (int)MarioPhysics.Position.Y, MarioAnimatedState.Width, MarioAnimatedState.Height);

        public Mario()
        {
            MarioPowerUpState = new MarioSmallState();
            MarioAnimatedState = new MarioIdleRightState(this);
            MarioPhysics = new MarioPhysics(OriginalPosition);
            time = Constant.Instance.InitialTime;
            action = true;
            MarioPhysics.IsRunning = false;
            Invincible = false;
            Fetch = false;
        }
        public void Down()
        {
            if ( !(MarioAnimatedState is MarioDeadState))
            {
                MarioAnimatedState.Down();
            }
        }

        public void FetchFlag()
        {
            Invincible = true;
            MarioAnimatedState = new MarioMovingRightState(this);
            MarioPhysics.MoveRight();
        }
        public void Draw(SpriteBatch spriteBatch)
        {           
            MarioAnimatedState.Draw(spriteBatch, MarioPhysics.Position);
        }

        public void Shoot()
        {
            if ( !(MarioAnimatedState is MarioDeadState))
            {
                if (SuperMarioBros.Instance.World.FireballList.Count == 0)
                {
                    SuperMarioBros.Instance.World.FireballList.Add(new Fireball(this.IsFaceRight, MarioPhysics.Position + new Vector2(Constant.Instance.FireballPositionOffset, 0)));
                    SoundFactory.Instance.CreateShootSound();
                }
            }
        }
        public void Idle()
        {
            if ( !(MarioAnimatedState is MarioDeadState))
            {
                MarioAnimatedState.Idle();
                MarioPhysics.IsRunning = false;
            }
        }

        public void Left()
        {
            if (!(MarioAnimatedState is MarioDeadState))
            {
                MarioPhysics.IsRunning = true;
                MarioPhysics.MoveLeft();
                MarioAnimatedState.Left();
            }
        }

        public void Right()
        {
            if ( !(MarioAnimatedState is MarioDeadState))
            {
                MarioPhysics.IsRunning = true;
                MarioPhysics.MoveRight();
                MarioAnimatedState.Right();
            }
        }

        public void CheckDead()
        {
            if (MarioPhysics.Position.Y > Constant.Instance.MarioDeadPosition)
            {
                MarioPhysics.Dead = true;
                
                MarioAnimatedState = new MarioDeadState(this);
                SoundFactory.Instance.CreateMarioDeadSound();
                SuperMarioBros.Instance.ScManager.RemainingLife -= Constant.Instance.OneRemainingLife;
                SuperMarioBros.Instance.Manager.SetDelay();
                if (SuperMarioBros.Instance.ScManager.RemainingLife <= Constant.Instance.NoRemainingLife)
                {

                    SuperMarioBros.Instance.Manager.LostGame();
                    SoundFactory.Instance.CreateGameOverSound();
                }

            }
        }


        public void Up()
        {            
            if ( !(MarioAnimatedState is MarioDeadState))
            {
                if (MarioPhysics.IsGround)
                {
                    SoundFactory.Instance.CreateJumpSmallSound();
                }
                MarioPhysics.Jump();
                MarioAnimatedState.Up();
                MarioPhysics.IsGround = false;
            }
        }

        public void Reset()
        {
            
                MarioAnimatedState = new MarioIdleRightState(this);
                MarioPowerUpState = new MarioSmallState();
                MarioPhysics.Dead = false;
        }

        public void TakeDamage()
        {
            if (!(MarioPowerUpState is MarioSmallState))
            {

                MarioPowerUpState = new MarioSmallState();
                action = false;
            }
            if (action && !(MarioAnimatedState is MarioDeadState))
            {
                
                if (MarioPowerUpState is MarioSmallState)
                {
                   
                    MarioAnimatedState = new MarioDeadState(this);
                    SuperMarioBros.Instance.Manager.SetDelay();
                    SoundFactory.Instance.CreateMarioDeadSound();
                    SuperMarioBros.Instance.ScManager.RemainingLife -= Constant.Instance.OneRemainingLife;
                    if (SuperMarioBros.Instance.ScManager.RemainingLife <= Constant.Instance.NoRemainingLife)
                    {
                        SuperMarioBros.Instance.Manager.LostGame();
                        SoundFactory.Instance.CreateGameOverSound();
                    }
                }
                else if (MarioPowerUpState  is MarioBigState)
                {
                    MarioPowerUpState = new MarioSmallState();
                }   
            }
            
            
        }

        public void Update(GameTime gameTime)
        {
            MarioAnimatedState.Update(gameTime);
            CheckDead();
            if(action&Fetch)
            {
                FetchFlag();
            }
            
            MarioPhysics.Update(gameTime);
            time += gameTime.ElapsedGameTime.TotalSeconds;
            if (time > delay)
            {
                action = true;
                time = Constant.Instance.InitialTime;
            }
           

        }
    }
}
