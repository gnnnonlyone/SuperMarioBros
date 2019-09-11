using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Factories;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.Score
{
    class HiddenWorldScore:IScoreState
    {
        private SpriteFont sprite;
        private ISprite coin;
        private int totalScore;
        private int numOfCoins;
        private int remainingLife;
        private ScoreManager manager;
        private string world;
        public double Time { get; set; }
        private string timeStr;
        public Vector2 Position { get; set; }
        public HiddenWorldScore(ScoreManager manager, Vector2 position)
        {
            this.manager = manager;
            this.Position = position;
            numOfCoins = manager.NumOfCoins;
            coin = ItemFactory.Instance.CreateCoinItem();
            sprite = HUDFactory.Instance.spriteFont;
            world = Constant.Constant.Instance.WordHidden;
            Time = manager.Time;
            timeStr = Constant.Constant.Instance.ScoreTimeString;
            remainingLife = manager.RemainingLife;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(sprite, Constant.Constant.Instance.Mario + totalScore.ToString(), Position - Constant.Constant.Instance.TotalScoreAdjustPosition, Color.White);
            coin.Draw(spriteBatch, Position - Constant.Constant.Instance.CoinAdjustPosition);
            spriteBatch.DrawString(sprite, Constant.Constant.Instance.X + numOfCoins.ToString(), Position - Constant.Constant.Instance.NumOfCoinsAdjustPosition, Color.White);
            spriteBatch.DrawString(sprite, Constant.Constant.Instance.World + world.ToString(), Position - Constant.Constant.Instance.WorldAdjustPosition, Color.White);
            spriteBatch.DrawString(sprite, Constant.Constant.Instance.Life + remainingLife.ToString(), Position - Constant.Constant.Instance.LifeAdjustPosition, Color.White);
            spriteBatch.DrawString(sprite, Constant.Constant.Instance.Time + timeStr, Position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Position = manager.Position;
            totalScore = manager.Score;
            numOfCoins = manager.NumOfCoins;
            remainingLife = manager.RemainingLife;
            coin.Update(gameTime);
            //manager.ScoreMoving();
            Time -= gameTime.ElapsedGameTime.TotalSeconds;
            if (Time <= Constant.Constant.Instance.TimeLowBoundary)
            {
                TreeNewBee.SuperMarioBros.Instance.Manager.LostGame();
                SoundFactory.Instance.CreateGameOverSound();
            }
            if (Time.ToString().IndexOf(Constant.Constant.Instance.TimeSeparator) != Constant.Constant.Instance.TimeStrIndexBoundary)
            {
                timeStr = Time.ToString().Substring(0, Time.ToString().IndexOf(Constant.Constant.Instance.TimeSeparator));
            }
        }
    }
}
