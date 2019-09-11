using TreeNewBee.Interfaces;
using TreeNewBee.WorldLevel;
using System.Xml;
using Microsoft.Xna.Framework;
using TreeNewBee.Items;
using TreeNewBee.Enemies;
using TreeNewBee.Scenery;
using TreeNewBee.Blocks;
using TreeNewBee.MarioClass;
using SuperMarioBros.Props;
using SuperMarioBros.Constant;
using SuperMarioBros.Blocks;
using SuperMarioBros.Enemies;

namespace TreeNewBee.Factories
{
    public static class LevelLoader
    {
        //private const int blockSidePixels = 16;


        public static IWorld CreateWorld11()
        {
            
            return Load("1-1.xml");
        }

        public static IWorld CreateHiddenWorld()
        {
            return Load("HiddenWorld.xml");
        }

        public static IWorld CreateWorld22()
        {
            return Load("2-2.xml");
        }
    

        private static IWorld Load(string level)
        {
            
            XmlReader reader = XmlReader.Create("Content/Configuration/" + level);
            reader.ReadToFollowing("Objects");
            reader.Read();
            reader.Read();
            IWorld world = new World(int.Parse(reader.GetAttribute("X")), int.Parse(reader.GetAttribute("Y")));
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    string name = reader.Name;
                    string type = reader.GetAttribute("Type");
                    float xPosition = float.Parse(reader.GetAttribute("X"));
                    float yPosition = float.Parse(reader.GetAttribute("Y"));
                    CreateObjects(world, name, type, xPosition, yPosition);
                }
            }
            return world;
        }

       

        private static void CreateObjects(IWorld world, string obj, string type, float xPosition, float yPosition)
        {
            switch (obj)
            {
                case "Block":
                    CreateBlock(world, type, xPosition, yPosition);
                    break;
                case "Player":
                    CreatePlayer(world, type, xPosition, yPosition);
                    break;
                case "Item":
                    CreateItem(world, type, xPosition, yPosition);
                    break;
                case "Enemy":
                    CreateEnemy(world, type, xPosition, yPosition);
                    break;
                case "Scenery":
                    CreateScenery(world, type, xPosition, yPosition);
                    break;
                case "Props":
                    CreateProps(world, type, xPosition, yPosition);
                    break;
                default:
                    break;
            }
        }


        private static void CreateProps(IWorld world, string type, float xPosition, float yPosition)
        {
            switch(type)
            {
                case nameof(Castle):
                    world.PropsList.Add(new Castle(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(FlagPole):
                    world.PropsList.Add(new FlagPole(new Vector2(xPosition, yPosition)));
                    break;
                default:
                    break;
            }
        }

        private static void CreateBlock(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case nameof(BeveledBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new BeveledBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(BrickBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new BrickBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(GroundBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new GroundBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(HiddenBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new HiddenBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(Pipe):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new Pipe(new Vector2(xPosition, yPosition));
                    break;
                case nameof(QuestionBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new QuestionBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(UsedBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new UsedBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(BlankBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new BlankBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(UnderwaterBlock):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new UnderwaterBlock(new Vector2(xPosition, yPosition));
                    break;
                case nameof(Coral):
                    world.Blocks[(int)xPosition / Constant.Instance.BlockSidePixels][(int)yPosition / Constant.Instance.BlockSidePixels] = new Coral(new Vector2(xPosition, yPosition));
                    break;
                default:
                    break;
            }
        }

        private static void CreatePlayer(IWorld world, string type, float xPosition, float yPosition)
        {
            switch(type)
            {
                case nameof(Mario):
                    world.Mario.OriginalPosition = new Vector2(xPosition,yPosition);
                    world.Mario.MarioPhysics.Position = new Vector2(xPosition, yPosition);
                    break;
                default:
                    break;
            }
        }

        private static void CreateItem(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case nameof(Coin):
                    world.ItemList.Add(new Coin(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(FireFlower):
                    world.ItemList.Add(new FireFlower(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(GreenMushroom):
                    world.ItemList.Add(new GreenMushroom(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(RedMushroom):
                    world.ItemList.Add(new RedMushroom(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(Star):
                    world.ItemList.Add(new Star(new Vector2(xPosition, yPosition)));
                    break;
                default:
                    break;
            }
        }

        private static void CreateEnemy(IWorld world, string type, float xPosition, float yPosistion)
        {
            switch(type)
            {
                case nameof(Goomba):
                    world.EnemyList.Add(new Goomba(new Vector2(xPosition, yPosistion)));
                    break;
                case nameof(Koopa):
                    world.EnemyList.Add(new Koopa(new Vector2(xPosition, yPosistion)));
                    break;
                case nameof(Jellyfish):
                    world.EnemyList.Add(new Jellyfish(new Vector2(xPosition, yPosistion)));
                    break;
                case nameof(Fish):
                    world.EnemyList.Add(new Fish(new Vector2(xPosition, yPosistion)));
                    break;
                default:
                    break;
            }
        }

        private static void CreateScenery(IWorld world, string type, float xPosition, float yPosition)
        {
            switch(type)
            {
                case nameof(BigBush):
                    world.SceneryList.Add(new BigBush(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(SmallBush):
                    world.SceneryList.Add(new SmallBush(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(BigCloud):
                    world.SceneryList.Add(new BigCloud(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(SmallCloud):
                    world.SceneryList.Add(new SmallCloud(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(BigHill):
                    world.SceneryList.Add(new BigHill(new Vector2(xPosition, yPosition)));
                    break;
                case nameof(SmallHill):
                    world.SceneryList.Add(new SmallHill(new Vector2(xPosition, yPosition)));
                    break;
                default:
                    break;
            }

        }   

    }
}
