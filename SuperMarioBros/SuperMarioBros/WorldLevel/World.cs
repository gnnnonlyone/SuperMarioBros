using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TreeNewBee.Interfaces;
using TreeNewBee.MarioClass;
using TreeNewBee;
using SuperMarioBros;
using System.Collections.Generic;
using SuperMarioBros.Props;
using SuperMarioBros.PhysicalState;
using TreeNewBee.Collision;
using SuperMarioBros.Interfaces;
using TreeNewBee.Blocks;
using SuperMarioBros.MarioClass;

namespace TreeNewBee.WorldLevel
{
    public class World:IWorld
    {
        public IList<IItem> ItemList { get; }
        public IList<IEnemy> EnemyList { get; }
        public IList<IScenery> SceneryList { get; }
        public IList<IProps> PropsList { get; }
        public IMario Mario { set; get; }
        
        public IList<IProps> FireballList { get; }
        public int Height { get;set; }
        public int Width { get; set; }
        private CollisionDetection collisionDetection;
        private IList<IItem> ItemColliedList;
        private IList<IEnemy> EnemyRemovaList;
        private IList<IProps> DeadFireballList;
        private static World instance;
        public static World Instance { get => instance; }
        
        public IBlock[][] Blocks { get; set; }
        public World(int width, int height)
        {
            Height = height;
            Width = width;
            instance = this;
            Mario = new Mario();
            ItemList = new List<IItem>();
            ItemColliedList = new List<IItem>();
            EnemyList = new List<IEnemy>();
            EnemyRemovaList = new List<IEnemy>();
            SceneryList = new List<IScenery>();
            PropsList = new List<IProps>();
            FireballList = new List<IProps>();
            DeadFireballList = new List<IProps>();
            Blocks = new IBlock[Width][];
            for (int i = 0; i < Width; i++)
            {
                Blocks[i] = new IBlock[Height];
            }
            collisionDetection = new CollisionDetection(this);   
        }

        public void Update(GameTime gameTime)
        {
            
            foreach (IItem item in ItemList)
            {
                item.Update(gameTime);
                if (item.Collided || (item.ItemPhysics as ItemPhysics).OutOfBoundary)
                {
                    ItemColliedList.Add(item);
                }
            }
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Update(gameTime);
                if(enemy.EnemyPhysics.OutOfBoundary || enemy.State.Removal)
                {
                    EnemyRemovaList.Add(enemy);
                }
            }
            foreach (IScenery sceneray in SceneryList)
            {
                sceneray.Update(gameTime);
            }
            foreach (IProps props in PropsList)
            {
                props.Update(gameTime);
            }
            foreach (IProps fireball in FireballList)
            {
                fireball.Update(gameTime);
                if((fireball as Fireball).Dead)
                {
                    DeadFireballList.Add(fireball);
                }
            }
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Blocks[i][j] != null)
                    {
                        Blocks[i][j].Update(gameTime);
                    }
                }
            }
            
            if (!Mario.MarioPhysics.Dead)
            {

                Mario.Update(gameTime);
            }
            
            collisionDetection.DetectAllCollisions();
            
            RemoveGameObjects();
        }

       
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IItem item in ItemList)
            {
                item.Draw(spriteBatch);
            }
            foreach (IScenery sceneray in SceneryList)
            {
                sceneray.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IProps fireball in FireballList)
            {
                fireball.Draw(spriteBatch);
            }
            foreach (IProps props in PropsList)
            {
                props.Draw(spriteBatch);
            }

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Blocks[i][j] != null && Blocks[i][j].Collided==false)
                    {
                        Blocks[i][j].Draw(spriteBatch);
                    }
                }
            }
            Mario.Draw(spriteBatch);
            
        }

        private void RemoveGameObjects()
        {
            RemoveItems();
            RemoveEnemies();
            RemoveFireball();
            //consider handle all remove game objects operations in this method in the future
        }

        private void RemoveItems()
        {
            foreach(IItem item in ItemColliedList)
            {
                ItemList.Remove(item);
            }
            ItemColliedList.Clear();
        }

        private void RemoveEnemies()
        {
            foreach (IEnemy enemy in EnemyRemovaList)
            {
                EnemyList.Remove(enemy);
            }
            EnemyRemovaList.Clear();
        }

        private void RemoveFireball()
        {
            foreach (IProps fireball in DeadFireballList)
            {
                FireballList.Remove(fireball);
            }
            DeadFireballList.Clear();
        }
    }
}
