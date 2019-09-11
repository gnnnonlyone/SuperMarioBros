using Microsoft.Xna.Framework;
using SuperMarioBros.Enemies;
using TreeNewBee.Blocks;
using TreeNewBee.Collision;
using TreeNewBee.Enemies;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.Collision
{
    public static class EnemyBlockCollisionHandler
    {
        public static void HandleCollision(IBlock block, IEnemy enemy, CollisionDetection.CollisionSide side)
        {
            if ((!block.Collided && enemy.Collidable)|| block is BlankBlock)
            {
                if (CollisionDetection.HorizontalCollision(side))
                {
                    enemy.ChangeDirection(side);
                    NewLocation(block, enemy, side);
                }
                else
                {
                    if (enemy is Goomba || enemy is Koopa)
                    {
                        enemy.EnemyPhysics.Velocity = new Vector2(enemy.EnemyPhysics.Velocity.X, 0);
                        enemy.EnemyPhysics.Gravity = false;
                        NewLocation(block, enemy, side);
                    }
                    else if (enemy is Jellyfish || enemy is Fish)
                    {
                        NewLocation(block, enemy, side);
                        enemy.EnemyPhysics.Velocity = new Vector2(enemy.EnemyPhysics.Velocity.X, -enemy.EnemyPhysics.Velocity.Y);
                    }
                }
            }
        }

        public static void NewLocation(IBlock block, IEnemy enemy, CollisionDetection.CollisionSide side)
        {
            if (side == CollisionDetection.CollisionSide.Left)
            {
                enemy.EnemyPhysics.Position = new Vector2(block.BlockPhysics.Position.X - enemy.EnemyBox.Width-1, enemy.EnemyPhysics.Position.Y);
                enemy.EnemyPhysics.Acceleration = new Vector2(0, enemy.EnemyPhysics.Acceleration.Y);
            }
            else if (side == CollisionDetection.CollisionSide.Right)
            {
                enemy.EnemyPhysics.Position = new Vector2(block.BlockPhysics.Position.X + block.BlockBox.Width +1, enemy.EnemyPhysics.Position.Y);
                enemy.EnemyPhysics.Acceleration = new Vector2(0, enemy.EnemyPhysics.Acceleration.Y);
            }
            else if (side == CollisionDetection.CollisionSide.Top)
            {
                enemy.EnemyPhysics.Position = new Vector2(enemy.EnemyPhysics.Position.X, block.BlockPhysics.Position.Y - enemy.EnemyBox.Height);
            }
            else if (side == CollisionDetection.CollisionSide.Bottom)
            {
                enemy.EnemyPhysics.Position = new Vector2(enemy.EnemyPhysics.Position.X, block.BlockPhysics.Position.Y + block.BlockBox.Height);
            }

        }
    }
}
