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
    class WonScore :IScoreState
    {
        private SpriteFont sprite;
        private string timeStr;
        public double Time { get; set; }
        public Vector2 Position { get; set; }
        public WonScore(Vector2 position)
        {
            this.Position = position;
            timeStr = Constant.Constant.Instance.ScoreTimeString;
            sprite = HUDFactory.Instance.spriteFont;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            timeStr = Constant.Constant.Instance.WinString;
            spriteBatch.DrawString(sprite, timeStr, Position, Color.White);
        }

        public void Update(GameTime gameTime)
        {

            //no need update here
        }
    }
}
