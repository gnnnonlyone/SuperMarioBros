using System.Collections.Generic;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SuperMarioBros;

namespace TreeNewBee.Controller
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyboardControllerMap;
        
        public KeyboardController()
        {
            keyboardControllerMap = new Dictionary<Keys, ICommand>();
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
           keyboardControllerMap.Add(key, command);
        }
        public void UnRigisterCommand(Keys key)
        {
            keyboardControllerMap.Remove(key);
        }
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            foreach (KeyValuePair<Keys, ICommand> keyboardControllerMapPair in keyboardControllerMap)
            {
                if (keyboardState.IsKeyDown(keyboardControllerMapPair.Key))
                {
                    keyboardControllerMapPair.Value.Execute();
                    
                }
                if (keyboardState.IsKeyUp(Keys.Left) && keyboardState.IsKeyUp(Keys.A) && keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.D) && keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.S))
                {
                    foreach (KeyValuePair<Keys, ICommand> keyboarMapPair in keyboardControllerMap)
                    {
                        if(keyboarMapPair.Key==Keys.M)
                        {
                            keyboarMapPair.Value.Execute();
                        }
                    }
                }
            }
        }
    }
}