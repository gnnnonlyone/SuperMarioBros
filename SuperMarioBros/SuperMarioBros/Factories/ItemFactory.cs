using TreeNewBee.Interfaces;
using TreeNewBee.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TreeNewBee.Items;
using System.Collections.Generic;
using System;
using SuperMarioBros.Constant;

namespace TreeNewBee.Factory
{
    class ItemFactory
    {
        private Texture2D coinSpriteSheet;
        private Texture2D rdMshrmSpriteSheet;
        private Texture2D gnMshrmSpriteSheet;
        private Texture2D flowerSpriteSheet;
        private Texture2D starSpriteSheet;

        private static readonly ItemFactory instance = new ItemFactory();
        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }
        
        private ItemFactory()
        {
        
        }

        public void LoadAllTextures(ContentManager content)
        {
            coinSpriteSheet = content.Load<Texture2D>("Coin");
            rdMshrmSpriteSheet = content.Load<Texture2D>("RedMushroom");
            gnMshrmSpriteSheet = content.Load<Texture2D>("GreenMushroom");
            flowerSpriteSheet = content.Load<Texture2D>("Flower");
            starSpriteSheet = content.Load<Texture2D>("Star");
            
        }
        public ISprite CreateCoinItem()
        {
            return new AnimatedSprite(coinSpriteSheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfItemFrame, true);
        }

        public ISprite CreateRdMshrmItem()
        {
            return new StaticSprite(rdMshrmSpriteSheet, new Rectangle(0, 0, rdMshrmSpriteSheet.Width, rdMshrmSpriteSheet.Height));
        }
        
        public ISprite CreateGnMshrmItem()
        {
            return new StaticSprite(gnMshrmSpriteSheet, new Rectangle(0, 0, gnMshrmSpriteSheet.Width, gnMshrmSpriteSheet.Height));
        }
        
        public ISprite CreateFlowerItem()
        {
            return new AnimatedSprite(flowerSpriteSheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfItemFrame, true);
        }

        public ISprite CreateStarItem()
        {
            return new AnimatedSprite(starSpriteSheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfItemFrame, true);
        }

        public static void CreateItem(Vector2 position)
        {
            Random ran = new Random();
            int n = ran.Next(5);
            switch (n)
            {
                case 0:
                    SuperMarioBros.Instance.World.ItemList.Add(new Coin(position));
                    break;
                case 1:
                    SuperMarioBros.Instance.World.ItemList.Add(new FireFlower(position));
                    break;
                case 2:
                    SuperMarioBros.Instance.World.ItemList.Add(new GreenMushroom(position));
                    break;
                case 3:
                    SuperMarioBros.Instance.World.ItemList.Add(new RedMushroom(position));
                    break;
                case 4:
                    SuperMarioBros.Instance.World.ItemList.Add(new Star(position));
                    break;
                default:
                    break;
            }
        }
    }
}
