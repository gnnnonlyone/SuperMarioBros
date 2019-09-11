using TreeNewBee.Controller;
using TreeNewBee.Factory;
using TreeNewBee.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TreeNewBee.Collision;
using TreeNewBee.Factories;
using System;
using SuperMarioBros.Factories;
using SuperMarioBros;
using Microsoft.Xna.Framework.Input;
using TreeNewBee.Command;
using SuperMarioBros.GameState;
using SuperMarioBros.Command;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using SuperMarioBros.Score;

[assembly: CLSCompliant(false)]

namespace TreeNewBee
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SuperMarioBros : Game
    {
        public IWorld World { get; set; }
        public GameStateManager Manager{ get; set; }
        public ScoreManager ScManager { get; set; }
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public KeyboardController GlobalController { get; set; }
        private static SuperMarioBros instance;
        public static SuperMarioBros Instance { get => instance; }
        

        public SuperMarioBros()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            

        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            instance = this;
            
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.ApplyChanges();
            base.Initialize();
            Manager = new GameStateManager();
            World = Manager.World;
            ScManager = new ScoreManager();
            GlobalController = new KeyboardController();
            AddCommand(GlobalController,World.Mario);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);
            ItemFactory.Instance.LoadAllTextures(Content);
            EnemyFactory.Instance.LoadAllTextures(Content);
            MarioFactory.Instance.LoadAllTextures(Content);
            BlockFactory.Instance.LoadAllTextures(Content);
            SceneryFactory.Instance.LoadAllTextures(Content);
            PropFactory.Instance.LoadAllTextures(Content);
            HUDFactory.Instance.LoadAllTextures(Content);
            SoundFactory.Instance.LoadAllTextures(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Manager.Update(gameTime);          
            GlobalController.Update();
            ScManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, ScrollingCamera.scrollingCamera());
            Manager.Draw(spriteBatch);
            ScManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reset()
        {
            Manager.Background.Stop();
            Manager = new GameStateManager();
            ScManager = new ScoreManager();
            World = Manager.World;
            GlobalController = new KeyboardController();
            AddCommand(TreeNewBee.SuperMarioBros.Instance.GlobalController, World.Mario);
        }

        public void AddCommand(KeyboardController keyboardController, IMario mario)
        {
            
            keyboardController.RegisterCommand(Keys.A, new MarioLeftCommand(mario));
            keyboardController.RegisterCommand(Keys.Left, new MarioLeftCommand(mario));
            keyboardController.RegisterCommand(Keys.D, new MarioRightCommand(mario));
            keyboardController.RegisterCommand(Keys.Right, new MarioRightCommand(mario));
            keyboardController.RegisterCommand(Keys.W, new MarioUpCommand(mario));
            keyboardController.RegisterCommand(Keys.Up, new MarioUpCommand(mario));
            keyboardController.RegisterCommand(Keys.S, new MarioCrouchCommand(mario));
            keyboardController.RegisterCommand(Keys.Down, new MarioCrouchCommand(mario));
            keyboardController.RegisterCommand(Keys.Y, new MarioSmallCommand(mario));
            keyboardController.RegisterCommand(Keys.U, new MarioBigCommand(mario));
            keyboardController.RegisterCommand(Keys.I, new MarioFireCommand(mario));
            keyboardController.RegisterCommand(Keys.O, new MarioDeadCommand(mario));
            
            keyboardController.RegisterCommand(Keys.X, new MarioShootCommand(mario));
            keyboardController.RegisterCommand(Keys.M, new MarioIdleCommand(mario));
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboardController.RegisterCommand(Keys.R, new ResetCommand(this));
            keyboardController.RegisterCommand(Keys.P, new PauseCommand(Manager));
            keyboardController.RegisterCommand(Keys.E, new ResumeCommand(Manager));

        }
        public static void RemoveCommand(KeyboardController keyboardController)
        {
            keyboardController.UnRigisterCommand(Keys.A);
            keyboardController.UnRigisterCommand(Keys.Left);
            keyboardController.UnRigisterCommand(Keys.D);
            keyboardController.UnRigisterCommand(Keys.Right);
            keyboardController.UnRigisterCommand(Keys.W);
            keyboardController.UnRigisterCommand(Keys.Up);
            keyboardController.UnRigisterCommand(Keys.S);
            keyboardController.UnRigisterCommand(Keys.Down);
            keyboardController.UnRigisterCommand(Keys.Y);
            keyboardController.UnRigisterCommand(Keys.U);
            keyboardController.UnRigisterCommand(Keys.I);
            keyboardController.UnRigisterCommand(Keys.O);
            keyboardController.UnRigisterCommand(Keys.X);
            keyboardController.UnRigisterCommand(Keys.M);
            keyboardController.UnRigisterCommand(Keys.P);
        }
    }
}