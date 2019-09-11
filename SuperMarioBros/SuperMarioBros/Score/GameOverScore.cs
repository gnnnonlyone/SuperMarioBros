using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Factories;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Score
{
    class GameOverScore:IScoreState
    {
        private SpriteFont sprite;
        private string timeStr;
        public Vector2 Position { get; set; }
        public double Time { get; set; }

        public GameOverScore(Vector2 position)
        {
            this.Position = position;
            timeStr = Constant.Constant.Instance.ScoreTimeString;
            sprite = HUDFactory.Instance.spriteFont;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            timeStr = Constant.Constant.Instance.LoseString;
            spriteBatch.DrawString(sprite, timeStr, Position, Color.White);
        }

        public void Update(GameTime gameTime)
        {

            //no need update here
        }
    }
}
