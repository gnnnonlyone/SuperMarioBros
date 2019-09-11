using Microsoft.Xna.Framework;
using TreeNewBee.Blocks;
using TreeNewBee.Interfaces;
using System;
using SuperMarioBros.Collision;
using SuperMarioBros.Props;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Constant;

namespace TreeNewBee.Collision
{
    public class CollisionDetection
    {
        public enum CollisionSide { Left, Right, Top, Bottom };
        public IWorld Level { get; set; }
        public CollisionDetection(IWorld world)
        {
            Level = world;
        }

        public void DetectAllCollisions()
        {
            DetectMarioItemCollision();
            DetectMarioEnemyCollision();
            DetectMarioBlockCollision();
            DetectItemBlockCollision();
            DetectEnemyBlockCollision();
            DectectEnemyEnemyCollision();
            DetectFireballEnemyCollision();
            DetectFireballBlockCollision();
            DetectMarioPropsCollision();
        }

        public static bool HorizontalCollision(CollisionSide side)
        {
            if ((side == CollisionSide.Left) || (side == CollisionSide.Right))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void DetectMarioEnemyCollision()
        {
            
            foreach(IEnemy enemy in Level.EnemyList)
            {
                Rectangle enemyBox = enemy.EnemyBox;
                Rectangle marioBox = Level.Mario.MarioBox;
                Rectangle intersection = Rectangle.Intersect(marioBox, enemyBox);
                if (!intersection.IsEmpty)
                {
                    CollisionSide side = GetCollisionSide(intersection, marioBox, enemyBox);
                    MarioEnemyCollisionHandler.HandleCollision(Level.Mario, enemy, side);
                }
            }
        }

        private void DetectMarioPropsCollision()
        {
            foreach (IProps props in Level.PropsList)
            {
                Rectangle propsBox = props.PropsBox;
                Rectangle marioBox = Level.Mario.MarioBox;
                Rectangle intersection = Rectangle.Intersect(marioBox, propsBox);
                if (!intersection.IsEmpty)
                {
                    MarioPropsCollisionHandler.HandleCollision(Level.Mario, props);
                }
            }
        }

        private void DetectMarioItemCollision()
        {
            foreach(IItem item in Level.ItemList)
            {
                Rectangle itemBox = item.ItemBox;
                Rectangle marioBox = Level.Mario.MarioBox;
                Rectangle intersection = Rectangle.Intersect(marioBox, itemBox);
                if (!intersection.IsEmpty)
                {
                    MarioItemCollisionHandler.HandleCollision(Level.Mario, item);
                }
            }
            
        }

        private void DetectMarioBlockCollision()
        {
            IBlock block = new GroundBlock(new Vector2(0, 0));
            float marioLocationX = Level.Mario.MarioPhysics.Position.X;
            float marioLocationY = Level.Mario.MarioPhysics.Position.Y;
            int blocksWidth = block.BlockBox.Width;
            int blocksHeight = block.BlockBox.Height;
            int blockIndexX = (int)Math.Ceiling(marioLocationX / blocksWidth);
            int blockIndexY = (int)Math.Ceiling(marioLocationY / blocksHeight);
            for (int blockIndexOffsetX = Constant.Instance.BlockIndexOffset; blockIndexOffsetX < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetX++)
            {
                for (int blockIndexOffsetY = Constant.Instance.BlockIndexOffset; blockIndexOffsetY < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetY++)
                {
                    CheckMarioBlockCollision(blockIndexX + blockIndexOffsetX, blockIndexY + blockIndexOffsetY);
                }
            }
        }

        private void DetectItemBlockCollision()
        {
            foreach (IItem item in Level.ItemList)
            {
                IBlock block = new GroundBlock(new Vector2(0, 0));
                float itemLocationX = item.ItemPhysics.Position.X;
                float itemLocationY = item.ItemPhysics.Position.Y;
                int blocksWidth = block.BlockBox.Width;
                int blocksHeight = block.BlockBox.Height;
                int blockIndexX = (int)Math.Ceiling(itemLocationX / blocksWidth);
                int blockIndexY = (int)Math.Ceiling(itemLocationY / blocksHeight);
                for (int blockIndexOffsetX = Constant.Instance.BlockIndexOffset; blockIndexOffsetX < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetX++)
                {
                    for (int blockIndexOffsetY = Constant.Instance.BlockIndexOffset; blockIndexOffsetY < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetY++)
                    {
                        CheckItemBlockCollision(blockIndexX + blockIndexOffsetX, blockIndexY + blockIndexOffsetY, item);
                    }
                }
            }
        }

        private void DetectFireballBlockCollision()
        {
            foreach (Fireball fireball in Level.FireballList)
            {
                IBlock block = new GroundBlock(new Vector2(0, 0));
                float fireballLocationX = fireball.FireballPhysics.Position.X;
                float fireballLocationY = fireball.FireballPhysics.Position.Y;
                int blocksWidth = block.BlockBox.Width;
                int blocksHeight = block.BlockBox.Height;
                int blockIndexX = (int)Math.Ceiling(fireballLocationX / blocksWidth);
                int blockIndexY = (int)Math.Ceiling(fireballLocationY / blocksHeight);
                for (int blockIndexOffsetX = Constant.Instance.BlockIndexOffset; blockIndexOffsetX < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetX++)
                {
                    for (int blockIndexOffsetY = Constant.Instance.BlockIndexOffset; blockIndexOffsetY < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetY++)
                    {
                        CheckFireballBlockCollision(blockIndexX + blockIndexOffsetX, blockIndexY + blockIndexOffsetY, fireball);
                    }
                }
            }
        }

        private void DetectEnemyBlockCollision()
        {
            foreach (IEnemy enemy in Level.EnemyList)
            {
                IBlock block = new GroundBlock(new Vector2(0, 0));
                float enemyLocationX = enemy.EnemyPhysics.Position.X;
                float enemyLocationY = enemy.EnemyPhysics.Position.Y;
                int blocksWidth = block.BlockBox.Width;
                int blocksHeight = block.BlockBox.Height;
                int blockIndexX = (int)Math.Ceiling(enemyLocationX / blocksWidth);
                int blockIndexY = (int)Math.Ceiling(enemyLocationY / blocksHeight);
                for (int blockIndexOffsetX = Constant.Instance.BlockIndexOffset; blockIndexOffsetX < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetX++)
                {
                    for (int blockIndexOffsetY = Constant.Instance.BlockIndexOffset; blockIndexOffsetY < Constant.Instance.BlockIndexOffsetLimit; blockIndexOffsetY++)
                    {
                        CheckEnemyBlockCollision(blockIndexX + blockIndexOffsetX, blockIndexY + blockIndexOffsetY, enemy);
                    }
                }
            }
        }

        private void DetectFireballEnemyCollision()
        {
            foreach (IEnemy enemy in Level.EnemyList)
            {
                foreach (Fireball fireball in Level.FireballList)
                {
                        Rectangle enemyBox = enemy.EnemyBox;
                        Rectangle fireballBox = fireball.PropsBox;
                        Rectangle intersection = Rectangle.Intersect(enemyBox, fireballBox);
                        if (!intersection.IsEmpty)
                        {
                        FireballEnemyCollisionHandler.HandleFireballEnemyCollision(fireball, enemy);
                        }
                }
            }
        }

        private void DectectEnemyEnemyCollision()
        {
            foreach (IEnemy enemy1 in Level.EnemyList)
            {
                foreach (IEnemy enemy2 in Level.EnemyList)
                {
                    if (enemy1 != enemy2)
                    {
                        Rectangle enemy1Box = enemy1.EnemyBox;
                        Rectangle enemy2Box = enemy2.EnemyBox;
                        Rectangle intersection = Rectangle.Intersect(enemy1Box, enemy2Box);
                        CollisionSide enemy1Side = GetCollisionSide(intersection, enemy1Box, enemy2Box);
                        CollisionSide enemy2Side = GetCollisionSide(intersection, enemy2Box, enemy1Box);
                        if (!intersection.IsEmpty)
                        {
                            EnemyEnemyCollisionHandler.HandleEnemyEnemyCollision(enemy1, enemy2, enemy1Side, enemy2Side);
                        }
                    }
                }
            }
        }


        private void CheckMarioBlockCollision(int blockIndexX, int blockIndexY)
        {
            bool marioIsInHorizontalScope = blockIndexX >= Constant.Instance.BlockIndexInitialValue && blockIndexX < Level.Width;
            bool marioIsInVerticalScope = blockIndexY >= Constant.Instance.BlockIndexInitialValue && blockIndexY < Level.Height;
            if (marioIsInHorizontalScope && marioIsInVerticalScope)
            {
                IBlock block = Level.Blocks[blockIndexX][blockIndexY];
                Rectangle marioHitbox = Level.Mario.MarioBox;
                if (block != null)
                {
                    Rectangle blockHitbox = block.BlockBox;
                    Rectangle intersection = Rectangle.Intersect(marioHitbox, blockHitbox);

                    if (!intersection.IsEmpty)
                    {
                        CollisionSide side = GetCollisionSide(intersection, marioHitbox, blockHitbox);
                        MarioBlockCollisionHandler.HandleCollision(Level.Mario, block, side);
                    }
                }
            }
        }

        private void CheckItemBlockCollision(int blockIndexX, int blockIndexY, IItem item)
        {
            bool itemIsInHorizontalScope = blockIndexX >= Constant.Instance.BlockIndexInitialValue && blockIndexX < Level.Width;
            bool itemIsInVerticalScope = blockIndexY >= Constant.Instance.BlockIndexInitialValue && blockIndexY < Level.Height;
            if (itemIsInHorizontalScope && itemIsInVerticalScope)
            {
                IBlock block = Level.Blocks[blockIndexX][blockIndexY];
                Rectangle itemHitBox = item.ItemBox;
                if (block != null)
                {
                    Rectangle blockHitbox = block.BlockBox;
                    Rectangle intersection = Rectangle.Intersect(itemHitBox, blockHitbox);

                    if (!intersection.IsEmpty)
                    {
                        CollisionSide side = GetCollisionSide(intersection, itemHitBox, blockHitbox);
                        ItemBlockCollisionHandler.HandleCollision(block,item, side);
                    }
                }
            }
        }

        private void CheckEnemyBlockCollision(int blockIndexX, int blockIndexY, IEnemy enemy)
        {
            bool enemyIsInHorizontalScope = blockIndexX >= Constant.Instance.BlockIndexInitialValue && blockIndexX < Level.Width;
            bool enemyIsInVerticalScope = blockIndexY >= Constant.Instance.BlockIndexInitialValue && blockIndexY < Level.Height;
            if (enemyIsInHorizontalScope && enemyIsInVerticalScope)
            {
                IBlock block = Level.Blocks[blockIndexX][blockIndexY];
                Rectangle itemHitBox = enemy.EnemyBox;
                if (block != null)
                {
                    Rectangle blockHitbox = block.BlockBox;
                    Rectangle intersection = Rectangle.Intersect(itemHitBox, blockHitbox);

                    if (!intersection.IsEmpty)
                    {
                        CollisionSide side = GetCollisionSide(intersection, itemHitBox, blockHitbox);
                        EnemyBlockCollisionHandler.HandleCollision(block, enemy, side);
                    }
                }
            }
        }

        private void CheckFireballBlockCollision(int blockIndexX, int blockIndexY, Fireball fireball)
        {
            bool fireballIsInHorizontalScope = blockIndexX >= Constant.Instance.BlockIndexInitialValue && blockIndexX < Level.Width;
            bool fireballIsInVerticalScope = blockIndexY >= Constant.Instance.BlockIndexInitialValue && blockIndexY < Level.Height;
            if (fireballIsInHorizontalScope && fireballIsInVerticalScope)
            {
                IBlock block = Level.Blocks[blockIndexX][blockIndexY];
                Rectangle fireballHitBox = fireball.PropsBox;
                if (block != null)
                {
                    Rectangle blockHitbox = block.BlockBox;
                    Rectangle intersection = Rectangle.Intersect(fireballHitBox, blockHitbox);

                    if (!intersection.IsEmpty)
                    {
                        FireballBlockCollisionHandler.HandleFireballBlockCollision(block, fireball);
                    }
                }
            }
        }

        private static CollisionSide GetCollisionSide(Rectangle intersection, Rectangle marioBox, Rectangle objectBox)
        {
            if(intersection.Width >= intersection.Height)
            {
                return marioBox.Top <= objectBox.Top ? CollisionSide.Top : CollisionSide.Bottom;
            }
            else
            {
                return marioBox.Left >= objectBox.Left ? CollisionSide.Right : CollisionSide.Left;
            }
        }
    }
}
