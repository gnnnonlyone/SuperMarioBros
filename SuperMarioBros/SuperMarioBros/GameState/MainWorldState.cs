﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Factories;
using SuperMarioBros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.Controller;
using TreeNewBee.Factories;
using TreeNewBee.Interfaces;

namespace SuperMarioBros.GameState
{
    class MainWorldState:IGameState
    {
        public SoundEffectInstance Background { get; set; }
        private IWorld world;
        public MainWorldState(GameStateManager manager)
        {
            world = manager.World;
            TreeNewBee.SuperMarioBros.Instance.GlobalController = new KeyboardController();
            TreeNewBee.SuperMarioBros.Instance.AddCommand(TreeNewBee.SuperMarioBros.Instance.GlobalController, world.Mario);
            Background = SoundFactory.Instance.CreateBackgroundMusic();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Clear(Color.CornflowerBlue);
            world.Draw(spriteBatch);
        }


        public void Update(GameTime gameTime)
        {
            world.Update(gameTime);
        }
    }
}
