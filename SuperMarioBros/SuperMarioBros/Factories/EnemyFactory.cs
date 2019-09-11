using TreeNewBee.Interfaces;
using TreeNewBee.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Constant;

namespace TreeNewBee.Factory
{
    class EnemyFactory
    {
        private Texture2D goombaWalkingSpriteSheet;
        private Texture2D goombaStompedSpritesheet;
        private Texture2D goombaFlippedSpritesheet;
        private Texture2D koopaMovingSpritesheet;
        private Texture2D koopaStompedSpritesheet;
        private Texture2D koopaRevivingSpritesheet;
        private Texture2D koopaFlippedSpritesheet;
        private Texture2D jellyFishSwimSpritesheet;
        private Texture2D flippedJellyfishSpritesheet;
        private Texture2D fishSwimLeftSpritesheet;
        private Texture2D fishSwimRightSpritesheet;
        private Texture2D flippedFishSpritesheet;
        private static EnemyFactory instance = new EnemyFactory();

        public static EnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            goombaWalkingSpriteSheet = content.Load<Texture2D>("WalkingGoomba");
            goombaStompedSpritesheet = content.Load<Texture2D>("goomba_stomped");
            goombaFlippedSpritesheet = content.Load<Texture2D>("goomba_flipped");
            koopaMovingSpritesheet = content.Load<Texture2D>("koopa_walk_left");
            koopaStompedSpritesheet = content.Load<Texture2D>("koopa_stomped");
            koopaRevivingSpritesheet = content.Load<Texture2D>("koopa_revive");
            koopaFlippedSpritesheet = content.Load<Texture2D>("koopa_flipped");
            jellyFishSwimSpritesheet = content.Load<Texture2D>("underwater/jellyfish");
            flippedJellyfishSpritesheet = content.Load<Texture2D>("underwater/flipped_jellyfish");
            fishSwimLeftSpritesheet= content.Load<Texture2D>("underwater/fish");
            flippedFishSpritesheet = content.Load<Texture2D>("underwater/flipped_fish");
            fishSwimRightSpritesheet = content.Load<Texture2D>("underwater/fish_swim_right");
        }

        public ISprite CreateFishSwimRight()
        {
            return new AnimatedSprite(fishSwimRightSpritesheet, 1, 2, true);
        }
        public ISprite CreateFlippedFish()
        {
            return new AnimatedSprite(flippedFishSpritesheet, 1, 2, true);
        }
        public ISprite CreateFishSwimLeft()
        {
            return new AnimatedSprite(fishSwimLeftSpritesheet, 1, 2, true);
        }
        public ISprite CreateFlippedJellyfish()
        {
            return new StaticSprite(flippedJellyfishSpritesheet, new Rectangle(0, 0, flippedJellyfishSpritesheet.Width, flippedJellyfishSpritesheet.Height));
        }
        public ISprite CreateSwimJellyfish()
        {
            return new AnimatedSprite(jellyFishSwimSpritesheet, 1, 2, true);
        }
        public ISprite CreateGoombaMovingLeftSprite()
        {
            return new AnimatedSprite(goombaWalkingSpriteSheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGoombaMovingFrame, true);
        }

        public ISprite CreateGoombaStompedSprite()
        {
            return new StaticSprite(goombaStompedSpritesheet, new Rectangle(0, 0, goombaStompedSpritesheet.Width, goombaStompedSpritesheet.Height));
        }

        public ISprite CreateGoombaFlippedSprite()
        {
            return new StaticSprite(goombaFlippedSpritesheet, new Rectangle(0, 0, goombaStompedSpritesheet.Width, goombaStompedSpritesheet.Height));
        }

        public ISprite CreateKoopaMovingSprite()
        {
            return new AnimatedSprite(koopaMovingSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGoombaMovingFrame, true);
        }

        public ISprite CreateKoopaStompedSprite()
        {
            return new StaticSprite(koopaStompedSpritesheet, new Rectangle(0, 0, koopaStompedSpritesheet.Width, koopaStompedSpritesheet.Height));
        }

        public ISprite CreateKoopaRevivingSprite()
        {
            return new StaticSprite(koopaRevivingSpritesheet, new Rectangle(0, 0, koopaRevivingSpritesheet.Width, koopaRevivingSpritesheet.Height));
        }

        public ISprite CreateKoopaFlippedSprite()
        {
            return new StaticSprite(koopaFlippedSpritesheet, new Rectangle(0, 0, koopaFlippedSpritesheet.Width, koopaFlippedSpritesheet.Height));
        }
    }
}