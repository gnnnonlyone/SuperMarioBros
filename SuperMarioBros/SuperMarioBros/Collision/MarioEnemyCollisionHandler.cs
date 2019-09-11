using SuperMarioBros.Constant;
using SuperMarioBros.Factories;
using TreeNewBee.Enemies;
using TreeNewBee.Interfaces;
using TreeNewBee.States.EnemyStates;
using TreeNewBee.States.MarioStates;
using SuperMarioBros.Enemies;
using static TreeNewBee.Collision.CollisionDetection;

namespace TreeNewBee.Collision
{
    public static class MarioEnemyCollisionHandler
    {
        public static void HandleCollision(IMario mario, IEnemy enemy, CollisionSide side)
        {
            if (!(mario.MarioAnimatedState is MarioDeadState)&&!mario.Invincible)
            { 
                if(enemy is Goomba)
                {
                    MarioGoombaCollision(mario, enemy, side);
                }
                else if(enemy is Koopa)
                {
                    MarioKoopaCollision(mario, enemy, side);
                }
                else if(enemy is Jellyfish || enemy is Fish)
                {
                    mario.TakeDamage();
                }
            }
        }

        private static void MarioGoombaCollision(IMario mario, IEnemy enemy, CollisionSide side)
        {
            if (mario.MarioPowerUpState is MarioSmallInvincibleState || mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                enemy.BeFlipped();
            }
            else
            {
                if (side == CollisionSide.Top && enemy.Collidable)
                {
                    enemy.BeStomped();
                    SoundFactory.Instance.CreateStompSound();
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Instance.HitGoombaReward;
                }
                else
                {
                    if (!(enemy.State is GoombaFlippedState || enemy.State is GoombaStompedState))
                    {
                        mario.TakeDamage();
                    }
                }
            }
        }

        private static void MarioKoopaCollision(IMario mario, IEnemy enemy, CollisionSide side)
        {
            if (mario.MarioPowerUpState is MarioSmallInvincibleState || mario.MarioPowerUpState is MarioSuperInvincibleState)
            {
                enemy.BeFlipped();
            }
            else
            {
                if (side == CollisionSide.Top && enemy.Collidable)
                {
                    enemy.BeStomped();
                    SoundFactory.Instance.CreateStompSound(); 
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Instance.HitGoombaReward;
                }
                else
                {
                    if (!(enemy.State is KoopaFlippedState ||
                       enemy.State is KoopaRevivingState || enemy.State is KoopaStompedState))
                    {
                        mario.TakeDamage();
                    }
                }
            }
        }
    }
}
