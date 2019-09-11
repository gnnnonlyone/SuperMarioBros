using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Collision;
using TreeNewBee.Interfaces;
using TreeNewBee.Items;
using static TreeNewBee.Collision.CollisionDetection;

namespace SuperMarioBros.Collision
{
    public static class ItemBlockCollisionHandler
    {

        public static void HandleCollision(IBlock block, IItem item, CollisionDetection.CollisionSide side)
        {
            if (!item.Collided && !block.Collided)
            {
                if (side == CollisionDetection.CollisionSide.Right || side == CollisionDetection.CollisionSide.Right)
                {
                    NewLocation(block, item, side);
                }
                else
                {
                    NewLocation(block, item, side);
                }
            }
        }

        public static void NewLocation(IBlock block, IItem item, CollisionDetection.CollisionSide side)
        {
            if (side == CollisionDetection.CollisionSide.Left)
            {
                item.ItemPhysics.Position = new Vector2(block.BlockPhysics.Position.X - item.ItemBox.Width, item.ItemPhysics.Position.Y);
                item.ItemPhysics.Acceleration = new Vector2(0, item.ItemPhysics.Acceleration.Y);
            }
            else if (side == CollisionDetection.CollisionSide.Right)
            {
                item.ItemPhysics.Position = new Vector2(block.BlockPhysics.Position.X + item.ItemBox.Width, item.ItemPhysics.Position.Y);
                item.ItemPhysics.Acceleration = new Vector2(0, item.ItemPhysics.Acceleration.Y);
            }
            else if (side == CollisionDetection.CollisionSide.Bottom)
            {
                item.ItemPhysics.Position = new Vector2(item.ItemPhysics.Position.X, block.BlockPhysics.Position.Y + block.BlockBox.Height);
            }
            else if (side == CollisionDetection.CollisionSide.Top)
            {
                item.ItemPhysics.Position = new Vector2(item.ItemPhysics.Position.X, block.BlockPhysics.Position.Y - block.BlockBox.Height);
            }
        }

    }
}
