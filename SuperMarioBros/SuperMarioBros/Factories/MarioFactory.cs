using TreeNewBee.Interfaces;
using TreeNewBee.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using SuperMarioBros.Constant;

namespace TreeNewBee.Factory
{
    class MarioFactory
    {
        private Texture2D marioDeadSpritesheet;
        private Texture2D marioSmallIdleRightSpritesheet;
        private Texture2D marioSmallIdleLeftSpritesheet;
        private Texture2D marioSmallRunRightSpritesheet;
        private Texture2D marioSmallRunLeftSpritesheet;
        private Texture2D marioSmallJumpRightSpritesheet;
        private Texture2D marioSmallJumpLeftSpritesheet;
        private Texture2D marioBigIdleRightSpritesheet;
        private Texture2D marioBigIdleLeftSpritesheet;
        private Texture2D marioBigRunRightSpritesheet;
        private Texture2D marioBigRunLeftSpritesheet;
        private Texture2D marioBigJumpRightSpritesheet;
        private Texture2D marioBigJumpLeftSpritesheet;
        private Texture2D marioBigCrouchRightSpritesheet;
        private Texture2D marioBigCrouchLeftSpritesheet;
        private Texture2D marioFireIdleRightSpritesheet;
        private Texture2D marioFireIdleLeftSpritesheet;
        private Texture2D marioFireRunRightSpritesheet;
        private Texture2D marioFireRunLeftSpritesheet;
        private Texture2D marioFireJumpRightSpritesheet;
        private Texture2D marioFireJumpLeftSpritesheet;
        private Texture2D marioFireCrouchRightSpritesheet;
        private Texture2D marioFireCrouchLeftSpritesheet;
        private Texture2D marioSmallInvincibleIdleRightSpritesheet;
        private Texture2D marioSmallInvincibleIdleLeftSpritesheet;
        private Texture2D marioSmallInvincibleRunRightSpritesheet;
        private Texture2D marioSmallInvincibleRunLeftSpritesheet;
        private Texture2D marioSmallInvincibleUpRightSpritesheet;
        private Texture2D marioSmallInvincibleUpLeftSpritesheet;
        private Texture2D marioSuperInvincibleIdleRightSpritesheet;
        private Texture2D marioSuperInvincibleIdleLeftSpritesheet;
        private Texture2D marioSuperInvincibleRunRightSpritesheet;
        private Texture2D marioSuperInvincibleRunLeftSpritesheet;
        private Texture2D marioSuperInvincibleUpRightSpritesheet;
        private Texture2D marioSuperInvincibleUpLeftSpritesheet;
        private Texture2D marioSuperInvincibleDownRightSpritesheet;
        private Texture2D marioSuperInvincibleDownLeftSpritesheet;
        private Texture2D marioSmallSwimLeftSpritesheet;
        private Texture2D marioSmallSwimRightSpritesheet;
        private static readonly MarioFactory instance = new MarioFactory();
        public static MarioFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            marioDeadSpritesheet = content.Load<Texture2D>("mario_dead");
            marioSmallIdleRightSpritesheet = content.Load<Texture2D>("mario_small_idle_right");
            marioSmallIdleLeftSpritesheet = content.Load<Texture2D>("mario_small_idle_left");
            marioSmallRunRightSpritesheet = content.Load<Texture2D>("mario_small_run_right");
            marioSmallRunLeftSpritesheet = content.Load<Texture2D>("mario_small_run_left");
            marioSmallJumpRightSpritesheet = content.Load<Texture2D>("mario_small_up_right");
            marioSmallJumpLeftSpritesheet = content.Load<Texture2D>("mario_small_up_left");
            marioBigIdleRightSpritesheet = content.Load<Texture2D>("mario_big_idle_right");
            marioBigIdleLeftSpritesheet = content.Load<Texture2D>("mario_big_idle_left");
            marioBigRunRightSpritesheet = content.Load<Texture2D>("mario_big_run_right");
            marioBigRunLeftSpritesheet = content.Load<Texture2D>("mario_big_run_left");
            marioBigJumpRightSpritesheet = content.Load<Texture2D>("mario_big_up_right");
            marioBigJumpLeftSpritesheet = content.Load<Texture2D>("mario_big_up_left");
            marioBigCrouchRightSpritesheet = content.Load<Texture2D>("mario_big_down_right");
            marioBigCrouchLeftSpritesheet = content.Load<Texture2D>("mario_big_down_left");
            marioFireIdleRightSpritesheet = content.Load<Texture2D>("mario_fire_idle_right");
            marioFireIdleLeftSpritesheet = content.Load<Texture2D>("mario_fire_idle_left");
            marioFireRunRightSpritesheet = content.Load<Texture2D>("mario_fire_run_right");
            marioFireRunLeftSpritesheet = content.Load<Texture2D>("MarioFireMovingLeft");
            marioFireJumpRightSpritesheet = content.Load<Texture2D>("mario_fire_up_right");
            marioFireJumpLeftSpritesheet = content.Load<Texture2D>("mario_fire_up_left");
            marioFireCrouchRightSpritesheet = content.Load<Texture2D>("mario_fire_down_right");
            marioFireCrouchLeftSpritesheet = content.Load<Texture2D>("mario_fire_down_left");
            marioSmallInvincibleIdleRightSpritesheet = content.Load<Texture2D>("MarioSmallInvincibleIdleRight");
            marioSmallInvincibleIdleLeftSpritesheet = content.Load<Texture2D>("MarioSmallInvincibleIdleLeft");
            marioSmallInvincibleRunRightSpritesheet = content.Load<Texture2D>("MarioSmallInvincibleRunRight");
            marioSmallInvincibleRunLeftSpritesheet = content.Load<Texture2D>("MarioSmallInvincibleRunLeft");
            marioSmallInvincibleUpRightSpritesheet = content.Load<Texture2D>("MarioSmallInvincibleUpRight");
            marioSmallInvincibleUpLeftSpritesheet = content.Load<Texture2D>("MarioSmallInvincibleUpLeft");
            marioSuperInvincibleIdleRightSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleIdleRight");
            marioSuperInvincibleIdleLeftSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleIdleLeft");
            marioSuperInvincibleRunRightSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleRunRight");
            marioSuperInvincibleRunLeftSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleRunLeft");
            marioSuperInvincibleUpRightSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleUpRight");
            marioSuperInvincibleUpLeftSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleUpLeft");
            marioSuperInvincibleDownRightSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleDownRight");
            marioSuperInvincibleDownLeftSpritesheet = content.Load<Texture2D>("MarioSuperInvincibleDownLeft");
            marioSmallSwimLeftSpritesheet = content.Load<Texture2D>("underwater/small_mario_swim_left");
            marioSmallSwimRightSpritesheet = content.Load<Texture2D>("underwater/small_mario_swim_right");
    }
        public ISprite CreateSmallMarioSwimLeftSprite()
        {
            return new AnimatedSprite(marioSmallSwimLeftSpritesheet, 1, 6, true);
        }
        public ISprite CreateSmallMarioSwimRightSprite()
        {
            return new AnimatedSprite(marioSmallSwimRightSpritesheet, 1, 6, true);
        }
        public ISprite CreateMarioDeadSprite()
        {
            return new StaticSprite(marioDeadSpritesheet,new Rectangle(0,0, marioDeadSpritesheet.Width, marioDeadSpritesheet.Height));
        }

        public ISprite CreateMarioSmallIdleRightSprite()
        {
            return new StaticSprite(marioSmallIdleRightSpritesheet,new Rectangle(0,0, marioSmallIdleRightSpritesheet.Width, marioSmallIdleRightSpritesheet.Height));
        }

        public ISprite CreateMarioSmallIdleLeftSprite()
        {
            return new StaticSprite(marioSmallIdleLeftSpritesheet,new Rectangle(0,0, marioSmallIdleLeftSpritesheet.Width, marioSmallIdleLeftSpritesheet.Height));
        }

        public ISprite CreateMarioSmallRunRightSprite()
        {
            return new AnimatedSprite(marioSmallRunRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfMarioFireFrame, true);
        }

        public ISprite CreateMarioSmallRunLeftSprite()
        {
            return new AnimatedSprite(marioSmallRunLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfMarioFireFrame, true);
        }

        public ISprite CreateMarioSmallJumpRightSprite()
        {
            return new StaticSprite(marioSmallJumpRightSpritesheet,new Rectangle(0,0, marioSmallJumpRightSpritesheet.Width, marioSmallJumpRightSpritesheet.Height));
        }

        public ISprite CreateMarioSmallJumpLeftSprite()
        {
            return new StaticSprite(marioSmallJumpLeftSpritesheet,new Rectangle(0,0, marioSmallJumpLeftSpritesheet.Width, marioSmallJumpLeftSpritesheet.Height));
        }

        public ISprite CreateMarioBigIdleRightSprite()
        {
            return new StaticSprite(marioBigIdleRightSpritesheet,new Rectangle(0,0, marioBigIdleRightSpritesheet.Width, marioBigIdleRightSpritesheet.Height));
        }

        public ISprite CreateMarioBigIdleLeftSprite()
        {
            return new StaticSprite(marioBigIdleLeftSpritesheet,new Rectangle(0,0, marioBigIdleLeftSpritesheet.Width, marioBigIdleLeftSpritesheet.Height));
        }

        public ISprite CreateMarioBigRunRightSprite()
        {
            return new AnimatedSprite(marioBigRunRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfMarioFireFrame, true);
        }

        public ISprite CreateMarioBigRunLeftSprite()
        {
            return new AnimatedSprite(marioBigRunLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfMarioFireFrame, true);
        }

        public ISprite CreateMarioBigJumpRightSprite()
        {
            return new StaticSprite(marioBigJumpRightSpritesheet,new Rectangle(0,0, marioBigJumpRightSpritesheet.Width, marioBigJumpRightSpritesheet.Height));
        }

        public ISprite CreateMarioBigJumpLeftSprite()
        {
            return new StaticSprite(marioBigJumpLeftSpritesheet,new Rectangle(0,0, marioBigJumpLeftSpritesheet.Width, marioBigJumpLeftSpritesheet.Height));
        }

        public ISprite CreateMarioBigCrouchRightSprite()
        {
            return new StaticSprite(marioBigCrouchRightSpritesheet,new Rectangle(0,0, marioBigCrouchRightSpritesheet.Width, marioBigCrouchRightSpritesheet.Height));
        }

        public ISprite CreateMarioBigCrouchLeftSprite()
        {
            return new StaticSprite(marioBigCrouchLeftSpritesheet,new Rectangle(0,0, marioBigCrouchLeftSpritesheet.Width, marioBigCrouchLeftSpritesheet.Height));
        }

        public ISprite CreateMarioFireIdleRightSprite()
        {
            return new StaticSprite(marioFireIdleRightSpritesheet,new Rectangle(0,0, marioFireIdleRightSpritesheet.Width, marioFireIdleRightSpritesheet.Height));
        }

        public ISprite CreateMarioFireIdleLeftSprite()
        {
            return new StaticSprite(marioFireIdleLeftSpritesheet,new Rectangle(0,0, marioFireIdleLeftSpritesheet.Width, marioFireIdleLeftSpritesheet.Height));
        }

        public ISprite CreateMarioFireRunRightSprite()
        {
            return new AnimatedSprite(marioFireRunRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfMarioFireFrame, true);
        }

        public ISprite CreateMarioFireRunLeftSprite()
        {
            return new AnimatedSprite(marioFireRunLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfMarioFireFrame, true);
        }

        public ISprite CreateMarioFireJumpRightSprite()
        {
            return new StaticSprite(marioFireJumpRightSpritesheet,new Rectangle(0,0, marioFireJumpRightSpritesheet.Width, marioFireJumpRightSpritesheet.Height));
        }

        public ISprite CreateMarioFireJumpLeftSprite()
        {
            return new StaticSprite(marioFireJumpLeftSpritesheet,new Rectangle(0,0, marioFireJumpLeftSpritesheet.Width, marioFireJumpLeftSpritesheet.Height));
        }

        public ISprite CreateMarioFireCrouchRightSprite()
        {
            return new StaticSprite(marioFireCrouchRightSpritesheet,new Rectangle(0,0, marioFireCrouchRightSpritesheet.Width, marioFireCrouchRightSpritesheet.Height));
        }

        public ISprite CreateMarioFireCrouchLeftSprite()
        {
            return new StaticSprite(marioFireCrouchLeftSpritesheet,new Rectangle(0,0, marioFireCrouchLeftSpritesheet.Width, marioFireCrouchLeftSpritesheet.Height));
        }
        public ISprite CreateMarioSmallInvincibleIdleRightSprite()
        {
            return new AnimatedSprite(marioSmallInvincibleIdleRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSmallInvincibleIdleLeftSprite()
        {
            return new AnimatedSprite(marioSmallInvincibleIdleLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSmallInvincibleRunRightSprite()
        {
            return new AnimatedSprite(marioSmallInvincibleRunRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSmallInvincibleRunLeftSprite()
        {
            return new AnimatedSprite(marioSmallInvincibleRunLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSmallInvincibleUpRightSprite()
        {
            return new AnimatedSprite(marioSmallInvincibleUpRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSmallInvincibleUpLeftSprite()
        {
            return new AnimatedSprite(marioSmallInvincibleUpLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleIdleRightSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleIdleRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleIdleLeftSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleIdleLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleRunRightSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleRunRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleRunLeftSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleRunLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleUpRightSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleUpRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleUpLeftSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleUpLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleDownRightSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleDownRightSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

        public ISprite CreateMarioSuperInvincibleDownLeftSprite()
        {
            return new AnimatedSprite(marioSuperInvincibleDownLeftSpritesheet, Constant.Instance.InitialAnimatedFrameIndex, Constant.Instance.NumOfGeneralMarioFrame, true);
        }

    }
}
