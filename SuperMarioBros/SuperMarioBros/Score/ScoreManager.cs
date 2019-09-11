using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.GameState;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Score
{
    public class ScoreManager
    {
        private float windowWidth;
        //public ScoreClass ScoreObj { get; set; }
        public double Time { get; set; }
        public int Score { get; set; }
        public int NumOfCoins { get; set; }
        public int RemainingLife { get; set; }
        public Vector2 Position { get; private set; }
        public IScoreState ScoreState { get; set; }
        //public Vector2 Position { get; internal set; }

        public ScoreManager()
        {
            //ScoreObj = new ScoreClass(this);
            Score = Constant.Constant.Instance.Score;
            NumOfCoins = Constant.Constant.Instance.NumOfCoinsInitial;
            RemainingLife = Constant.Constant.Instance.RemainingLife;
            Time= Constant.Constant.Instance.ScoreTime;
            windowWidth = TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Viewport.Width;
            Position = new Vector2(windowWidth / 2, Constant.Constant.Instance.ScoreWindowInitialPosY);
            ScoreState = new MainWorldScore(this, Position);
        }

        public void ScoreMoving()
        {
            float marioX = TreeNewBee.SuperMarioBros.Instance.World.Mario.MarioPhysics.Position.X;
            
            float worldWidth = TreeNewBee.SuperMarioBros.Instance.World.Width;
            float marioWidth = Constant.Constant.Instance.MarioWidth;
            if (marioX <= windowWidth / 2)
            {
                Position = new Vector2(windowWidth / 2, Constant.Constant.Instance.ScoreWindowInitialPosY);
            }
            else if (marioX >= worldWidth * marioWidth - windowWidth / 2)
            {
                Position = new Vector2(worldWidth * marioWidth - windowWidth / 2, Constant.Constant.Instance.ScoreWindowInitialPosY);
            }
            else
            {
                Position = new Vector2(marioX, Constant.Constant.Instance.ScoreWindowInitialPosY);
            }
        }

        public void Update(GameTime gameTime)
        {
            ScoreMoving();
            Time = ScoreState.Time;
            //Position = ScoreState.Position;
           if (!TreeNewBee.SuperMarioBros.Instance.Manager.Delay&&!TreeNewBee.SuperMarioBros.Instance.Manager.PauseFlag)
            {
                ScoreState.Update(gameTime);
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            ScoreState.Draw(spriteBatch);
        }
    }
}