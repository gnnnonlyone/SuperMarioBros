using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using SuperMarioBros.PhysicalState;
using TreeNewBee.Collision;
using TreeNewBee.Interfaces;
using static TreeNewBee.Collision.CollisionDetection;

namespace SuperMarioBros.Collision
{
    public static class EnemyEnemyCollisionHandler
    {
        public static void HandleEnemyEnemyCollision(IEnemy enemy1, IEnemy enemy2, CollisionSide enemy1Side, CollisionSide enemy2Side)
        {
            if (enemy1.Collidable && enemy2.Collidable && !enemy1.Flipped && !enemy2.Flipped)
            {
                enemy1.ChangeDirection(enemy1Side);
                enemy2.ChangeDirection(enemy2Side);
                NewLocation(enemy1, enemy2, enemy2Side);
                NewLocation(enemy2, enemy1, enemy1Side);
                enemy1.EnemyPhysics.InCollision = true;
                enemy2.EnemyPhysics.InCollision = true;
            }
        }

        public static void NewLocation(IEnemy enemy1, IEnemy enemy2, CollisionDetection.CollisionSide side)
        {
            if (side == CollisionDetection.CollisionSide.Left)
            {
                enemy2.EnemyPhysics.Position = new Vector2(enemy1.EnemyPhysics.Position.X - enemy2.EnemyBox.Width, enemy2.EnemyPhysics.Position.Y);
                enemy2.EnemyPhysics.Acceleration = new Vector2(0, enemy2.EnemyPhysics.Acceleration.Y);
            }
            else if (side == CollisionDetection.CollisionSide.Right)
            {
                enemy2.EnemyPhysics.Position = new Vector2(enemy1.EnemyPhysics.Position.X + enemy1.EnemyBox.Width, enemy2.EnemyPhysics.Position.Y);
                enemy2.EnemyPhysics.Acceleration = new Vector2(0, enemy2.EnemyPhysics.Acceleration.Y);
            }
        }
    }
}
