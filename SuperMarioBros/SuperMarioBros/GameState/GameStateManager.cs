using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.MarioClass;
using SuperMarioBros.Score;
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
    public class GameStateManager
    {
        public IGameState State { get; set; }
        public IWorld World { get; private set; }
        public bool IsHiddenWorld { get; set; }
        public bool WonFlag { get; set; }
        public bool GameOver { get; set; }
        public bool PauseFlag { get; private set; }
        public bool Delay { get; private set; }
        public SoundEffectInstance Background { get; set; }
        private IGameState prestate; 

        public GameStateManager()
        {
            World = LevelLoader.CreateWorld11();
            State = new MainWorldState(this);
            Background = (State as MainWorldState).Background;
            Background.Play();
            Background.IsLooped = true;
            IsHiddenWorld = false;
            PauseFlag = false;
            Delay = false;
            WonFlag = false;
            GameOver = false;
            prestate = State;
        }

        public void Pause()
        {
            if (!PauseFlag)
            {
                prestate = State;
                State = new PauseState(this);
                Background.Pause();
                PauseFlag = true;
            }
        }

        public void Resume()
        {
            if (PauseFlag)
            {
                State = prestate;
                TreeNewBee.SuperMarioBros.Instance.GlobalController = new KeyboardController();
                TreeNewBee.SuperMarioBros.Instance.AddCommand(TreeNewBee.SuperMarioBros.Instance.GlobalController, World.Mario);
                Background.Resume();
                PauseFlag = false;
            }
        }



        public void GetInHidden()
        {
            World = LevelLoader.CreateHiddenWorld();
            World.Mario = new SwimMario();
            TreeNewBee.SuperMarioBros.Instance.World = World;
            State = new HiddenWorldState(this);
            IsHiddenWorld = true;
            TreeNewBee.SuperMarioBros.Instance.ScManager.ScoreState = new HiddenWorldScore(TreeNewBee.SuperMarioBros.Instance.ScManager, TreeNewBee.SuperMarioBros.Instance.ScManager.Position);
            PauseFlag = false;
            WonFlag = false;
            GameOver = false;
            Background.Stop();
            Background = (State as HiddenWorldState).Background;
            Background.Play();
            Background.IsLooped = true;
        }

        public void GetInMainWorld()
        {
            World = LevelLoader.CreateWorld11();
            TreeNewBee.SuperMarioBros.Instance.World = World;
            State = new MainWorldState(this);
            IsHiddenWorld = false;
            TreeNewBee.SuperMarioBros.Instance.ScManager.ScoreState = new MainWorldScore(TreeNewBee.SuperMarioBros.Instance.ScManager, TreeNewBee.SuperMarioBros.Instance.ScManager.Position);
            PauseFlag = false;
            WonFlag = false;
            GameOver = false;
            Background.Stop();
            Background = (State as MainWorldState).Background;
            Background.Play();
            Background.IsLooped = true;
        }

        public void SetDelay()
        {
           Delay = true;
           State = new DelayState();
           Background.Stop();
            
        }

        public void FinishedGame()
        {
            WonFlag = true;
            TreeNewBee.SuperMarioBros.Instance.ScManager.ScoreState = new WonScore(TreeNewBee.SuperMarioBros.Instance.ScManager.Position);
            State = new GameOverState();
            Background.Stop();
        }
        public void LostGame()
        {
            GameOver = true;
            TreeNewBee.SuperMarioBros.Instance.ScManager.ScoreState = new GameOverScore(TreeNewBee.SuperMarioBros.Instance.ScManager.Position);
            State = new GameOverState();
            Background.Stop();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }
    }
}
