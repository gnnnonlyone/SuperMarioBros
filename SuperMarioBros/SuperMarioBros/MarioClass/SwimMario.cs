using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Factories;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using SuperMarioBros.Props;
using SuperMarioBros.States.MarioStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;

namespace SuperMarioBros.MarioClass
{
    public class SwimMario : IMario
    {
        public IMarioAnimatedState MarioAnimatedState { get; set; }
        public IMarioPowerUpState MarioPowerUpState { get; set; }
        public IMarioPhysics MarioPhysics { get; set; }
        public Vector2 OriginalPosition { get; set; }
        public bool Invincible { get; set; }
        public bool IsFaceRight { get; set; }
        public bool Fetch { get; set; }

        private bool action;
        private readonly double delay = Constant.Constant.Instance.MarioDelay;
        private double time;
        public Rectangle MarioBox => new Rectangle((int)MarioPhysics.Position.X, (int)MarioPhysics.Position.Y, MarioAnimatedState.Width, MarioAnimatedState.Height);

        public SwimMario()
        {
            MarioPowerUpState = new MarioSmallState();
            MarioAnimatedState = new MarioSwimIdleRightState(this);
            MarioPhysics = new SwimMarioPhysics(OriginalPosition);
            time = Constant.Constant.Instance.InitialTime;
            action = true;
            Invincible = false;
            Fetch = false;
            MarioPhysics.IsRunning = false;
        }
        public void Down()
        {
            if (!(MarioAnimatedState is MarioDeadState))
            {
                MarioPhysics.IsRunning = true;               
                MarioPhysics.Down();
            }
        }

        public void Up()
        {
            if (!(MarioAnimatedState is MarioDeadState))
            {
                MarioPhysics.IsRunning = true;
                MarioAnimatedState.Up();
                MarioPhysics.Jump();
            }
        }
        public void FetchFlag()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            MarioAnimatedState.Draw(spriteBatch, MarioPhysics.Position);
        }

        public void Shoot()
        {
            if (!(MarioAnimatedState is MarioDeadState))
             {
                 if (TreeNewBee.SuperMarioBros.Instance.World.FireballList.Count == 0)
                 {
                    TreeNewBee.SuperMarioBros.Instance.World.FireballList.Add(new Fireball(this.IsFaceRight, MarioPhysics.Position + new Vector2(Constant.Constant.Instance.FireballPositionOffset, 0)));
                     SoundFactory.Instance.CreateShootSound();
                 }
             }
        }
        public void Idle()
        {
             if (!(MarioAnimatedState is MarioDeadState))
             {
                MarioPhysics.IsRunning = false;
                MarioAnimatedState.Idle();
                MarioPhysics.Idle();
             }
        }

        public void Left()
        {
            if (!(MarioAnimatedState is MarioDeadState))
            {
                MarioPhysics.IsRunning = true;
                MarioAnimatedState.Left();
                MarioPhysics.MoveLeft();
            }
        }

        public void Right()
        {
            if (!(MarioAnimatedState is MarioDeadState))
            {
                MarioPhysics.IsRunning = true;
                MarioAnimatedState.Right();
                MarioPhysics.MoveRight();
            }
        }

          public void CheckDead()
          {
              if (MarioPhysics.Position.Y > Constant.Constant.Instance.MarioDeadPosition)
              {
                  MarioPhysics.Dead = true;

                  MarioAnimatedState = new MarioDeadState(this);
                  SoundFactory.Instance.CreateMarioDeadSound();
                TreeNewBee.SuperMarioBros.Instance.ScManager.RemainingLife -= Constant.Constant.Instance.OneRemainingLife;
                TreeNewBee.SuperMarioBros.Instance.Manager.SetDelay();
                  if (TreeNewBee.SuperMarioBros.Instance.ScManager.RemainingLife <= Constant.Constant.Instance.NoRemainingLife)
                  {

                    TreeNewBee.SuperMarioBros.Instance.Manager.LostGame();
                      SoundFactory.Instance.CreateGameOverSound();
                  }

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
                    TreeNewBee.SuperMarioBros.Instance.Manager.SetDelay();
                    SoundFactory.Instance.CreateMarioDeadSound();
                    TreeNewBee.SuperMarioBros.Instance.ScManager.RemainingLife -= Constant.Constant.Instance.OneRemainingLife;
                    if (TreeNewBee.SuperMarioBros.Instance.ScManager.RemainingLife <= Constant.Constant.Instance.NoRemainingLife)
                    {
                        TreeNewBee.SuperMarioBros.Instance.Manager.LostGame();
                        SoundFactory.Instance.CreateGameOverSound();
                    }
                }
                else if (MarioPowerUpState is MarioBigState)
                {
                    MarioPowerUpState = new MarioSmallState();
                }
            }
            

            
        }

            public void Update(GameTime gameTime)
            {
                MarioAnimatedState.Update(gameTime);
                CheckDead();

                MarioPhysics.Update(gameTime);
                time += gameTime.ElapsedGameTime.TotalSeconds;
                if (time > delay)
                {
                    action = true;
                    time = Constant.Constant.Instance.InitialTime;
                }
            }
        }
    }