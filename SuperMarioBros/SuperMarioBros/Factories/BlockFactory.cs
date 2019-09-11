using TreeNewBee.Interfaces;
using TreeNewBee.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Constant;

namespace TreeNewBee.Factory
{
    class BlockFactory
    {
        private Texture2D beveledBlockSheet;
        private Texture2D brickBlockSheet;
        private Texture2D usedBlockSheet;
        private Texture2D questionBlockSheet;
        private Texture2D hiddenBlockSheet;
        private Texture2D pipeSheet;
        private Texture2D groundBlockSpritesheet;
        private Texture2D blankBlockSpriteSheet;
        private Texture2D underwaterBlockSpriteSheet;
        private Texture2D underwaterCoralSpriteSheet;

        private static readonly BlockFactory instance = new BlockFactory();
        public static BlockFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            beveledBlockSheet = content.Load<Texture2D>("Beveled");
            brickBlockSheet = content.Load<Texture2D>("Brick");
            usedBlockSheet = content.Load<Texture2D>("Used");
            questionBlockSheet = content.Load<Texture2D>("Question");
            hiddenBlockSheet = content.Load<Texture2D>("Hidden");
            groundBlockSpritesheet = content.Load<Texture2D>("Ground");
            pipeSheet = content.Load<Texture2D>("MediumPipe");
            blankBlockSpriteSheet = content.Load<Texture2D>("Beveled");
            underwaterBlockSpriteSheet = content.Load<Texture2D>("underwater/underwaterblock");
            underwaterCoralSpriteSheet = content.Load<Texture2D>("underwater/coral");
        }

        public ISprite CreateCoral()
        {
            return new AnimatedSprite(underwaterCoralSpriteSheet, 3, 1, true);
        }
        public ISprite CreateUnderwaterBlock()
        {
            return new StaticSprite(underwaterBlockSpriteSheet, new Rectangle(0, 0, underwaterBlockSpriteSheet.Width, underwaterBlockSpriteSheet.Height));
        }
        public ISprite CreateBeveledBlock()
        {
            return new StaticSprite(beveledBlockSheet, new Rectangle(0, 0, beveledBlockSheet.Width, beveledBlockSheet.Height));
        }
        public ISprite CreateGroundBlockSprite()
        {
            return new StaticSprite(groundBlockSpritesheet, new Rectangle(0, 0, groundBlockSpritesheet.Width, groundBlockSpritesheet.Height));
        }

        public ISprite CreateBrickBlock()
        {
            return new StaticSprite(brickBlockSheet, new Rectangle(0, 0, brickBlockSheet.Width, brickBlockSheet.Height));
        }

        public ISprite CreateBrokenBlock()
        {
            return new StaticSprite(pipeSheet, new Rectangle(0, 0, usedBlockSheet.Width, usedBlockSheet.Height));
        }

        public ISprite CreateUsedBlock()
        {
            return new StaticSprite(usedBlockSheet, new Rectangle(0, 0, usedBlockSheet.Width, usedBlockSheet.Height));
        }

        public ISprite CreateQuestionBlock()
        {
            return new AnimatedSprite(questionBlockSheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfQuesBlockFrame, true);
        }
        public ISprite CreateHiddenBlock()
        {
            return new StaticSprite(hiddenBlockSheet, new Rectangle(0, 0, hiddenBlockSheet.Width, hiddenBlockSheet.Height));
        }

        public ISprite CreatePipe()
        {
            return new StaticSprite(pipeSheet, new Rectangle(0, 0, pipeSheet.Width, pipeSheet.Height));
        }

        public ISprite CreateBlankBlock()
        {
            return new StaticSprite(beveledBlockSheet, new Rectangle(0, 0, blankBlockSpriteSheet.Width, blankBlockSpriteSheet.Height));
        }
    }
}
