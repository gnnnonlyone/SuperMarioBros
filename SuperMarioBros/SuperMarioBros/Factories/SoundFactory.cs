using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBros.Factories
{
    class SoundFactory
    {
        
        private static readonly SoundFactory instance = new SoundFactory();
        private SoundEffect background;
        private SoundEffect underwaterBackground;

        private SoundEffect powerUpAppearance;
        private SoundEffect fireballShot;
        private SoundEffect brickBreak;
        private SoundEffect marioDie;
        private SoundEffect enemyStomp;
        private SoundEffect coinCollect;
        private SoundEffect plusLife;
        private SoundEffect jumpSmall;
        private SoundEffect transaction;
        //private SoundEffect pause;
        private SoundEffect gameOver;
        private SoundEffect flagpole;
        private SoundEffect stageClear;

        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private SoundFactory()
        {
            
        }

        public void LoadAllTextures(ContentManager content)
        {
            background = content.Load<SoundEffect>("marioBackgroundMusic");
            underwaterBackground = content.Load<SoundEffect>("underwater/Mario-Sheet-Music-Underwater-Theme");

            powerUpAppearance = content.Load<SoundEffect>("powerUpAppearance");
            fireballShot = content.Load<SoundEffect>("smbFireball");
            brickBreak = content.Load<SoundEffect>("smbBreakBlock");
            marioDie = content.Load<SoundEffect>("smbMarioDie");
            enemyStomp = content.Load<SoundEffect>("smbStomp");
            coinCollect = content.Load<SoundEffect>("smbCoin");
            plusLife = content.Load<SoundEffect>("smb1Up");
            jumpSmall = content.Load<SoundEffect>("smbJumpSmall");
            transaction = content.Load<SoundEffect>("smbPipeDown");
            //pause = content.Load<SoundEffect>("smbPause");
            gameOver = content.Load<SoundEffect>("smbGameOver");
            flagpole = content.Load<SoundEffect>("smbFlagpole");
            stageClear = content.Load<SoundEffect>("smbStageClear");
        }
        public void CreateJumpSmallSound()
        {
            jumpSmall.Play();
        }
        public void CreateMarioDeadSound()
        {
            marioDie.Play();
        }
        public void CreatePowerUpSound()
        {
            powerUpAppearance.Play();
        }
        public void CreateShootSound()
        {
            fireballShot.Play();
        }
        public void CreateBreakBlockSound()
        {
            brickBreak.Play();
        }
        public void CreateCoinCollectedSound()
        {
            coinCollect.Play();
        }
        public void CreateStompSound()
        {
            enemyStomp.Play();
        }
        public void CreateFlagPoleSound()
        {
            flagpole.Play();
        }
        public void CreateStageClearSound()
        {
            stageClear.Play();
        }
        public void CreateGameOverSound()
        {
            gameOver.Play();
        }
        public void CreatePlusLifeSound()
        {
            plusLife.Play();
        }
        public void CreateTransactionSound()
        {
            transaction.Play();
        }
        public SoundEffectInstance CreateBackgroundMusic()
        {
            SoundEffectInstance back = background.CreateInstance();
            return back;
        }
        public SoundEffectInstance CreateUnderwaterBackgroundMusic()
        {
            return underwaterBackground.CreateInstance();
        }

    }
}
