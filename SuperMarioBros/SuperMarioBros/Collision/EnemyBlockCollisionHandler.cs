using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Collision;
using TreeNewBee.Interfaces;
using static TreeNewBee.Collision.CollisionDetection;

namespace SuperMarioBros.Collision
{
    class EnemyBlockCollisionHandler
    {
        public static void HandleCollision(IBlock block,IEnemy enemy, CollisionDetection.CollisionSide side)
        {
            if (CollisionDetection.EnemyCollision(side))
            {
                enemy.ChangeDirection(side);
                NewLocation(block, enemy, side);
            }
        }

        public static void NewLocation(IBlock block, IEnemy enemy, CollisionSide side)
        {
            if (side == CollisionSide.Left)
            {
                enemy.Position = new Vector2(block.SpriteLocation.X - enemy.EnemyBox.Width, enemy.Position.Y);
            }
            else if (side == CollisionSide.Right)
            {
                enemy.Position = new Vector2(block.SpriteLocation.X + block.BlockBox.X, enemy.Position.Y);
            }
        }
    }
}
