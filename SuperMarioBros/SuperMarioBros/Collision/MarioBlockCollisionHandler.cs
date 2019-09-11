using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Factories;
using TreeNewBee.Blocks;
using TreeNewBee.Interfaces;
using TreeNewBee.States.MarioStates;
using static TreeNewBee.Collision.CollisionDetection;

namespace TreeNewBee.Collision
{

    public static class MarioBlockCollisionHandler
    {
       

        public static void HandleCollision(IMario mario, IBlock block, CollisionSide side)
        {
            if(side ==CollisionSide.Top)
            {
                mario.MarioPhysics.IsGround = true;
            }

            if(block is BrickBlock)
            {
                BrickBlockMarioCollision(mario, block, side);
            }
            else if(block is HiddenBlock)
            {
                HiddenBlockMarioCollision(mario, block, side);
            }
            else if(block is QuestionBlock)
            {
                QuestionBlockMarioCollision(mario, (QuestionBlock)block, side);
            }
            else if (block is Pipe)
            {
                if (side == CollisionSide.Top)
                {
                    if (!TreeNewBee.SuperMarioBros.Instance.Manager.IsHiddenWorld)
                    {
                        TreeNewBee.SuperMarioBros.Instance.Manager.GetInHidden();
                    }
                    else
                    {
                        TreeNewBee.SuperMarioBros.Instance.Manager.GetInMainWorld();
                    }
                    
                }else if(side == CollisionSide.Bottom)
                {
                    if (TreeNewBee.SuperMarioBros.Instance.Manager.IsHiddenWorld)
                    {
                        TreeNewBee.SuperMarioBros.Instance.Manager.GetInMainWorld();
                    }
                    
                }
                else
                {
                    NewLocation(block, mario, side);
                }
            }
            else if (block is UnderwaterBlock || block is Coral)
            {
                if(side == CollisionSide.Top)
                {
                    mario.MarioAnimatedState.Walk();
                }
                GeneralBlockMarioCollision(mario, block, side);
            }
            else
            {
                GeneralBlockMarioCollision(mario, block, side);
            }
        }

        public static void NewLocation(IBlock block, IMario mario, CollisionSide side)
        {
            switch (side)
            {
                case CollisionSide.Top:
                    mario.MarioPhysics.Position = new Vector2(mario.MarioPhysics.Position.X, block.BlockPhysics.Position.Y - mario.MarioBox.Height);
                    mario.MarioPhysics.Velocity = new Vector2(0, 0);
                    break;
                case CollisionSide.Left:
                    mario.MarioPhysics.Position = new Vector2(block.BlockPhysics.Position.X - mario.MarioBox.Width, mario.MarioPhysics.Position.Y);
                    mario.MarioPhysics.Velocity = new Vector2(0, mario.MarioPhysics.Velocity.Y);
                    break;
                case CollisionSide.Right:
                    mario.MarioPhysics.Position = new Vector2(block.BlockPhysics.Position.X + block.BlockBox.Width, mario.MarioPhysics.Position.Y);
                    mario.MarioPhysics.Velocity = new Vector2(0, mario.MarioPhysics.Velocity.Y);
                    break;
                case CollisionSide.Bottom:
                    mario.MarioPhysics.Position = new Vector2(mario.MarioPhysics.Position.X, block.BlockPhysics.Position.Y + block.BlockBox.Height);
                    mario.MarioPhysics.Velocity = new Vector2(mario.MarioPhysics.Velocity.X, 0);
                    break;
                default:
                    break;
            }
        }

        private static void GeneralBlockMarioCollision(IMario mario, IBlock block, CollisionSide side)
        {
            NewLocation(block, mario, side);
        }

        private static void BrickBlockMarioCollision(IMario mario, IBlock block, CollisionSide side)
        {
            if (mario != null)
            {
                if (!block.Collided)
                {
                    if (side == CollisionSide.Bottom)
                    {
                        block.Collided = true;
                        block.StateMachine.BecomeBroken();
                        SoundFactory.Instance.CreateBreakBlockSound();
                    }
                    else
                    {
                        NewLocation(block, mario, side);
                    }
                }
            }
        }

        private static void HiddenBlockMarioCollision(IMario mario, IBlock block, CollisionSide side)
        {
            if (block.StateMachine.IsUsed)
            {
                NewLocation(block, mario, side);
            }
            else if (side == CollisionSide.Bottom && mario.MarioAnimatedState is MarioJumpRightState || mario.MarioAnimatedState is MarioJumpLeftState)
            {
                block.StateMachine.BecomeUsed();
                NewLocation(block, mario, side);
            }
        }

        private static void QuestionBlockMarioCollision(IMario mario, QuestionBlock block, CollisionSide side)
        {
           
            if (!block.Broken && side == CollisionSide.Bottom)
            {
                (block as QuestionBlock).CreateItem();
                block.BecomeUsed();
                NewLocation(block, mario, side);
            }
            else
            {
                NewLocation(block, mario, side);
            }
        }
    }
}
