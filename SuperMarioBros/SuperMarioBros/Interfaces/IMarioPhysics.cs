using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interfaces
{
    public interface IMarioPhysics
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        bool IsGround { get; set; }
        Vector2 Gravity { get; set; }
        void Update(GameTime gameTime);

        bool Dead { get; set; }

        void Down();
        void MoveRight();
        void MoveLeft();

        bool IsRunning { get; set; }

        void Jump();
        void Idle();
    }
}
