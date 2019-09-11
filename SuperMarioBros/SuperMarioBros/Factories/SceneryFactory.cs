using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TreeNewBee.Interfaces;
using TreeNewBee.Sprites;

namespace TreeNewBee.Factories
{
    class SceneryFactory
    {
        private static readonly SceneryFactory instance = new SceneryFactory();
        private Texture2D hugeBushSpriteSheet;
        private Texture2D hugeCloudSpriteSheet;
        private Texture2D hugeHillSpriteSheet;
        private Texture2D smallBushSpriteSheet;
        private Texture2D smallCloudSpriteSheet;
        private Texture2D smallHillSpriteSheet;

        public static SceneryFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SceneryFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            hugeBushSpriteSheet = content.Load<Texture2D>("Scenerary/BigBush");
            hugeCloudSpriteSheet = content.Load<Texture2D>("Scenerary/BigCloud");
            hugeHillSpriteSheet = content.Load<Texture2D>("Scenerary/BigHill");
            smallBushSpriteSheet = content.Load<Texture2D>("Scenerary/SmallBush");
            smallCloudSpriteSheet = content.Load<Texture2D>("Scenerary/SmallCloud");
            smallHillSpriteSheet = content.Load<Texture2D>("Scenerary/SmallHill");
   
        }

        public ISprite CreateHugeBush()
        {
            return new StaticSprite(hugeBushSpriteSheet, new Rectangle(0,0,hugeBushSpriteSheet.Width,hugeBushSpriteSheet.Height));
        }
        public ISprite CreateHugeCloud()
        {
            return new StaticSprite(hugeCloudSpriteSheet, new Rectangle(0, 0, hugeCloudSpriteSheet.Width, hugeCloudSpriteSheet.Height));
        }

        public ISprite CreateHugeHill()
        {
            return new StaticSprite(hugeHillSpriteSheet, new Rectangle(0, 0, hugeHillSpriteSheet.Width, hugeHillSpriteSheet.Height));
        }

        public ISprite CreateSmallBush()
        {
            return new StaticSprite(smallBushSpriteSheet, new Rectangle(0, 0, smallBushSpriteSheet.Width, smallBushSpriteSheet.Height));
        }

        public ISprite CreateSmallCloud()
        {
            return new StaticSprite(smallCloudSpriteSheet, new Rectangle(0, 0, smallCloudSpriteSheet.Width, smallCloudSpriteSheet.Height));
        }

        public ISprite CreateSmallHill()
        {
            return new StaticSprite(smallHillSpriteSheet, new Rectangle(0, 0, smallHillSpriteSheet.Width, smallHillSpriteSheet.Height));
        }


    }
}
