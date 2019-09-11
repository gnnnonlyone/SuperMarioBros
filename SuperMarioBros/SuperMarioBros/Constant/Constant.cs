using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Constant
{
    public class Constant
    {
        private int generalGravity = 300;
        private int marioRunningSpeedLimit = 400;
        private int marioAccelerationLeft = -100;
        private int marioAccelerationRight = 100;
        private int marioAirLeftSpeedLimit = -35;
        private int marioAirRightSpeedLimit = 35;
        private int marioJumpSpeed = -210;
        private int marioRunningRightSpeed = 100;
        private int marioRunningLeftSpeed = -100;
        private int fireballFloatAcceleration = 150;
        private int fireballLeftSpeed = -400;
        private int fireballRightSpeed = 400;
        private int boundaryX = 3400;
        private int boundaryY = 256;
        private int mushroomUpSpeed = 25;
        private int redMushroomWalkSpeed = 20;
        private int greenMushroomWalkSpeed = -20;
        private int boundaryOrigin = 0;
        private int enemyWalkSpeed = -33;
        private int enemyDwonSpeed = 100;
        private int enemyJumpSpeed = -70;
        private int blockIndexOffset = -2;
        private int blockIndexOffsetLimit = 2;
        private int blockIndexInitialValue = 0;
        private int hitGoombaReward = 100;
        private int hitItemReward = 50;
        private int oneCoin = 1;
        private int blockSidePixels = 16;
        private double marioDelay = 1d;
        private double initialTime = 0d;
        private int fireballPositionOffset = 3;
        private int marioDeadPosition = 265;
        private int oneRemainingLife = 1;
        private int noRemainingLife = 0;
        private double scoreTime = 300;
        private float marioWidth = 16;
        private int marioScoreMovingPosition = 200;
        private int remainingLife = 3;
        private int score = 0;
        private int numOfCoinsInitial = 0;
        private double pauseTime = 2;
        private double resetPauseTime = 5;
        private double changeWorldPause = 4;
        private double winPauseTime = 0.5;
        private double gameOverPauseTime = 0.5;
        private double timeBoundary = 0;
        private int objectWidth = 16;
        private float cameraCoordinateInitial = 0;
        private int initialAnimatedFrameIndex = 1;
        private int numOfQuesBlockFrame = 3;
        private int numOfGoombaMovingFrame = 2;
        private int numOfItemFrame = 4;
        private int numOfMarioFireFrame = 3;
        private int numOfGeneralMarioFrame = 4;
        private int numOfFireballFrame = 4;
        private int numOfFlagFrame = 5;
        private int kllEnemyReward = 50;
        private int scoreWindowInitialPosY = -200;
        private int timeLowBoundary = 0;
        private int timeStrIndexBoundary = -1;
        private int randomMax = 40;
        private int targetNumber = 5;
        private string word11 = "1-1";
        private string wordHidden = "Hidden";
        private string winString = "Congratulations! You win";
        private string loseString = "With great power comes great responsibility";
        private string mario = "MARIO\n";
        private string x = "x";
        private string world = "WORLD\n";
        private string life = "LIFE\n";
        private string time = "TIME\n";
        private string scoreTimeString = "0";
        private string timeSeparator = ".";
        private int swimGravityY = 50;
        private int swimSpeedRight = 70;
        private int swimSpeedLeft = -70;
        private int swimJumpSpeed = -70;
        private int negativeOne = -1;
        private Vector2 swimFishSpeed = new Vector2(20, 30);
        private Vector2 swimJellyFishSpeed = new Vector2(-10, -10);
        private Vector2 swimGravity = new Vector2(0, 50);
        private Vector2 totalScoreAdjustPosition = new Vector2(300, 0);
        private Vector2 coinAdjustPosition = new Vector2(220, 0);
        private Vector2 numOfCoinsAdjustPosition = new Vector2(205, 0);
        private Vector2 worldAdjustPosition = new Vector2(85, 0);
        private Vector2 lifeAdjustPosition = new Vector2(145, 0);
        

        public int GeneralGravity { get => generalGravity; }
        public int MarioRunningSpeedLimit { get => marioRunningSpeedLimit; }
        public int MarioAccelerationLeft { get => marioAccelerationLeft; }
        public int MarioAccelerationRight { get => marioAccelerationRight; }
        public int MarioAirLeftSpeedLimit { get => marioAirLeftSpeedLimit; }
        public int MarioAirRightSpeedLimit { get => marioAirRightSpeedLimit; }
        public int MarioJumpSpeed { get => marioJumpSpeed; }
        public int MarioRunningRightSpeed { get => marioRunningRightSpeed; }
        public int MarioRunningLeftSpeed { get => marioRunningLeftSpeed; }
        public int FireballFloatAcceleration { get => fireballFloatAcceleration; }
        public int FireballLeftSpeed { get => fireballLeftSpeed; }
        public int FireballRightSpeed { get => fireballRightSpeed; }
        public int BoundaryX { get => boundaryX; }
        public int BoundaryY { get => boundaryY; }
        public int BoundaryOrigin { get => boundaryOrigin; }
        public int MushroomUpSpeed { get => mushroomUpSpeed; }
        public int RedMushroomWalkSpeed { get => redMushroomWalkSpeed; }
        public int GreenMushroomWalkSpeed { get => greenMushroomWalkSpeed; }
        public int EnemyWalkSpeed { get => enemyWalkSpeed; }
        public int EnemyDownSpeed { get => enemyDwonSpeed; }
        public int BlockIndexOffset { get => blockIndexOffset; }
        public int BlockIndexOffsetLimit { get => blockIndexOffsetLimit; }
        public int BlockIndexInitialValue { get => blockIndexInitialValue; }
        public int HitGoombaReward { get => hitGoombaReward; }
        public int HitItemReward { get => hitItemReward; }
        public int FireballKillEnemyReward { get => kllEnemyReward; }
        public int OneCoin { get => oneCoin; }
        public double MarioDelay { get => marioDelay; }
        public double InitialTime { get => initialTime; }
        public int FireballPositionOffset { get => fireballPositionOffset; }
        public int MarioDeadPosition { get => marioDeadPosition; }
        public int OneRemainingLife { get => oneRemainingLife; }
        public int NoRemainingLife { get => noRemainingLife; }
        public double ScoreTime { get => scoreTime; }
        public int MarioScoreMovingPosition { get => marioScoreMovingPosition; }
        public float MarioWidth { get => marioWidth; }
        public string Word11 { get => word11; }
        public int EnmeyJumpSpeed { get => enemyJumpSpeed; }
        public string WordHidden { get => wordHidden; }
        public string WinString { get => winString; }
        public string LoseString { get => loseString; }
        public string Mario { get => mario; }
        public string Life { get => life; }
        public string World { get => world; }
        public string ScoreTimeString { get => scoreTimeString; }
        public string X { get => x; }
        public string Time { get => time; }

        public int RandomTargetNumber { get => targetNumber; }
        public int RandomMaxNumber { get => randomMax; }
        public int RemainingLife { get => remainingLife; }
        public int Score { get => score; }
        public int NumOfCoinsInitial { get => numOfCoinsInitial; }
        public double PauseTime { get => pauseTime; }
        public double ResetPauseTime { get => resetPauseTime; }
        public double ChangeWorldPause { get => changeWorldPause; }
        public double WinPauseTime { get => winPauseTime; }
        public double GameOverPauseTime { get => gameOverPauseTime; }
        public double TimeBoundary { get => timeBoundary; }
        public int ObjectWidth { get => objectWidth; }
        public float CameraCoordinateInitial { get => cameraCoordinateInitial; }
        public int BlockSidePixels { get => blockSidePixels; }
        public int InitialAnimatedFrameIndex { get => initialAnimatedFrameIndex; }
        public int NumOfQuesBlockFrame { get => numOfQuesBlockFrame; }
        public int NumOfGoombaMovingFrame { get => numOfGoombaMovingFrame; }
        public int NumOfItemFrame { get => numOfItemFrame; }
        public int NumOfMarioFireFrame { get => numOfMarioFireFrame; }
        public int NumOfGeneralMarioFrame { get => numOfGeneralMarioFrame; }
        public int NumOfFireballFrame { get => numOfFireballFrame; }
        public int NumOfFlagFrame { get => numOfFlagFrame; }
        public int ScoreWindowInitialPosY { get => scoreWindowInitialPosY; }
        public int TimeLowBoundary { get => timeLowBoundary; }
        public int TimeStrIndexBoundary { get => timeStrIndexBoundary; }
        public string TimeSeparator { get => timeSeparator; }
        public int SwimGravityY { get => swimGravityY; }
        public int SwimSpeedRight { get => swimSpeedRight; }
        public int SwimSpeedLeft { get => swimSpeedLeft; }
        public int SwimJumpSpeed{ get => swimJumpSpeed; }
        public int NegativeOne { get => negativeOne; }

        public Vector2 TotalScoreAdjustPosition { get => totalScoreAdjustPosition; }
        public Vector2 CoinAdjustPosition { get => coinAdjustPosition; }
        public Vector2 NumOfCoinsAdjustPosition { get => numOfCoinsAdjustPosition; }
        public Vector2 WorldAdjustPosition { get => worldAdjustPosition; }
        public Vector2 LifeAdjustPosition { get => lifeAdjustPosition; }
        public Vector2 SwimGravity { get => swimGravity; }
        public Vector2 SwimJellyFishSpeed { get => swimJellyFishSpeed; }
        public Vector2 SwimFishSpeed { get => swimFishSpeed; }





        private static Constant instance = new Constant();
        public static Constant Instance { get => instance; set { instance = value; } }
        private Constant()
        {

        }
    }
}
