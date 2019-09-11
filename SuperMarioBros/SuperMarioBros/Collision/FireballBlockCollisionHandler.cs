using SuperMarioBros.Props;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.Collision
{
    public static class FireballBlockCollisionHandler
    {
        public static void HandleFireballBlockCollision(IBlock block, Fireball fireball)
        {
            if (!block.Collided)
            {
                fireball.Dead = true;
            }
        }
    }
}
