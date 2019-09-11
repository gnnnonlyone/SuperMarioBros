using TreeNewBee.Interfaces;
using TreeNewBee.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMarioBros.Factories
{
    class PropFactory
    {
        private static readonly PropFactory instance = new PropFactory();
        private Texture2D fireballLeftsheet;
        private Texture2D fireballRightsheet;
        private Texture2D flagPolesheet;
        private Texture2D castlesheet;

        public static PropFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PropFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            fireballLeftsheet = content.Load<Texture2D>("Fireball_Left");
            fireballRightsheet = content.Load<Texture2D>("Fireball_Right");
            flagPolesheet = content.Load<Texture2D>("Flagpole");
            castlesheet = content.Load<Texture2D>("Castle");
        }

        public ISprite CreateFireballLeft()
        {
            return new AnimatedSprite(fireballLeftsheet, Constant.Constant.Instance.InitialAnimatedFrameIndex, Constant.Constant.Instance.NumOfFireballFrame, true);
        }

        public ISprite CreateFireballRight()
        {
            return new AnimatedSprite(fireballRightsheet, Constant.Constant.Instance.InitialAnimatedFrameIndex, Constant.Constant.Instance.NumOfFireballFrame, true);
        }
        public ISprite CreateFlagPole()
        {
            return new AnimatedSprite(flagPolesheet, Constant.Constant.Instance.InitialAnimatedFrameIndex, Constant.Constant.Instance.NumOfFlagFrame, false);
        }
        public ISprite CreateCastle()
        {
            return new StaticSprite(castlesheet, new Rectangle(0, 0, castlesheet.Width, castlesheet.Height));
        }
    }
}
