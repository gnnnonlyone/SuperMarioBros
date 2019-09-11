using SuperMarioBros.Constant;
using SuperMarioBros.Factories;
using TreeNewBee.Interfaces;
using TreeNewBee.Items;
using TreeNewBee.States.MarioStates;

namespace TreeNewBee.Collision
{
    public static class MarioItemCollisionHandler
    {
        public static void HandleCollision(IMario mario, IItem item)
        {
            if (!item.Collided)
            {
                if(item is Coin)
                {
                    MarioItemCollision(item);
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Instance.HitItemReward;
                    TreeNewBee.SuperMarioBros.Instance.ScManager.NumOfCoins += Constant.Instance.OneCoin;
                    SoundFactory.Instance.CreateCoinCollectedSound();
                }
                else if(item is GreenMushroom)
                {
                    MarioItemCollision(item);
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Instance.HitItemReward;
                    SuperMarioBros.Instance.ScManager.RemainingLife += Constant.Instance.OneRemainingLife;
                    //SuperMarioBros.Instance.RemainingLife += Constant.Instance.OneRemainingLife;
                    SoundFactory.Instance.CreatePlusLifeSound();
                }
                else if(item is FireFlower)
                {
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Instance.HitItemReward;
                    MarioFireFlowerCollision(mario, item);
                }
                else if(item is RedMushroom)
                {
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Instance.HitItemReward;
                    MarioRedMushroomCollision(mario, item);
                }
                else if(item is Star)
                {
                    TreeNewBee.SuperMarioBros.Instance.ScManager.Score += Constant.Instance.HitItemReward;
                    MarioStarCollision(mario, item);
                }
            }
        }
        private static void MarioStarCollision(IMario mario, IItem item)
        {
            item.Collided = true;
            if (mario.MarioPowerUpState is MarioSmallState)
            {
                mario.MarioPowerUpState = new MarioSmallInvincibleState();
                SoundFactory.Instance.CreateTransactionSound();
            }
            else if (mario.MarioPowerUpState is MarioBigState || mario.MarioPowerUpState is MarioFireState)
            {
                mario.MarioPowerUpState = new MarioSuperInvincibleState();
                SoundFactory.Instance.CreatePowerUpSound();
            }
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }

        private static void MarioRedMushroomCollision(IMario mario, IItem item)
        {
            item.Collided = true;
            if (mario.MarioPowerUpState is MarioSmallInvincibleState)
            {
                mario.MarioPowerUpState = new MarioSuperInvincibleState();
                SoundFactory.Instance.CreatePowerUpSound();
            }
            else if (!(mario.MarioPowerUpState is MarioSuperInvincibleState))
            {
                mario.MarioPowerUpState = new MarioBigState();
                SoundFactory.Instance.CreateTransactionSound();
            }
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }

        private static void MarioFireFlowerCollision(IMario mario, IItem item)
        {
            item.Collided = true;
            if (mario.MarioPowerUpState is MarioSmallInvincibleState)
            {
                mario.MarioPowerUpState = new MarioSuperInvincibleState();
                SoundFactory.Instance.CreatePowerUpSound();
            }
            else if (!(mario.MarioPowerUpState is MarioSuperInvincibleState))
            {
                mario.MarioPowerUpState = new MarioFireState();
                SoundFactory.Instance.CreateTransactionSound();
            }
            mario.MarioAnimatedState = new MarioIdleRightState(mario);
        }
        private static void MarioItemCollision(IItem item)
        {
            item.Collided = true;
        }
    }
}
