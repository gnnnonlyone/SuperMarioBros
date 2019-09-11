using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TreeNewBee.Command;
using TreeNewBee.Interfaces;
using System.Collections.Generic;

namespace TreeNewBee.Controller
{
    public class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> gamePadControllerMap;
        public GamePadController(SuperMarioBros gameClass)
        {
            SuperMarioBros superMarioBros = gameClass;
            IMario mario = superMarioBros.World.Mario;
            gamePadControllerMap = new Dictionary<Buttons, ICommand>
            {
                { Buttons.Start, new QuitCommand(superMarioBros) },
                { Buttons.LeftThumbstickUp, new MarioUpCommand(mario) },
                { Buttons.LeftThumbstickDown, new MarioCrouchCommand(mario) },
                { Buttons.LeftThumbstickLeft, new MarioLeftCommand(mario) },
                { Buttons.LeftThumbstickRight, new MarioRightCommand(mario) },
                { Buttons.A, new MarioSmallCommand(mario) },
                { Buttons.B, new MarioBigCommand(mario) },
                { Buttons.X, new MarioFireCommand(mario) },
                { Buttons.Y, new MarioDeadCommand(mario) },
               // { Buttons.Back, new ResetCommand(superMarioBros)},
            };
        }
        public void Update()
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            foreach (KeyValuePair<Buttons, ICommand> buttonCommandPair in gamePadControllerMap)
            {
                if (state.IsButtonDown(buttonCommandPair.Key))
                {
                    buttonCommandPair.Value.Execute();
                }
            }
        }
    }
}
