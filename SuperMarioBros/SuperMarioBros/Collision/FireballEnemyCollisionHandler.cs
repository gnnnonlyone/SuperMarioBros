using SuperMarioBros.Constant;
using SuperMarioBros.Props;
using TreeNewBee.Interfaces;
using SuperMarioBros.Factories;
using TreeNewBee.Items;
using TreeNewBee.States.MarioStates;
using SuperMarioBros.Enemies;

namespace SuperMarioBros.Collision
{
    public static class FireballEnemyCollisionHandler
    {
        public static void HandleFireballEnemyCollision(Fireball fireball,IEnemy enemy)
        {
            if(enemy.Collidable)
            {
                if (enemy is Jellyfish || enemy is Fish)
                {
                    fireball.Dead = true;
                    enemy.BeFlipped();
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Constant.Instance.FireballKillEnemyReward;
                }
                else
                {
                    fireball.Dead = true;
                    enemy.BeStomped();
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Constant.Instance.FireballKillEnemyReward;
                }
            }
        }
    }
}
