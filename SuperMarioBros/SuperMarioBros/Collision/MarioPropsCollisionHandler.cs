using SuperMarioBros.Factories;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Props;
using TreeNewBee.Interfaces;
using static TreeNewBee.Collision.CollisionDetection;

namespace SuperMarioBros.Collision
{
    public static class MarioPropsCollisionHandler
    {
        public static void HandleCollision(IMario mario, IProps props)
        {
            if (props is FlagPole)
            {
                (props as FlagPole).ShouldLowerFlag = true;
                mario.Fetch = true;
                SoundFactory.Instance.CreateFlagPoleSound();
            }
            if(props is Castle)
            {
                TreeNewBee.SuperMarioBros.Instance.Manager.FinishedGame();
                //TreeNewBee.SuperMarioBros.Instance.Manager.WonFlag = true;
                SoundFactory.Instance.CreateStageClearSound();
            }
        }
    }
}
