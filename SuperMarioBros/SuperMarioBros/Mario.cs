using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FooBarHappyHour.Interfaces;
using FooBarHappyHour.States;
using System;

namespace Game1
{
    public class Mario:IMario
    {
        public IMarioState MarioState { get; set; }

        public Mario()
        {
            MarioState = new MarioSmallIdelRightState(this);
        }
        void Idle()
        {
            MarioState.Idle();
        }
        void Up()
        {
            MarioState.Up();
        }
        void Down()
        {
            MarioState.Down();
        }
        void Left()
        {
            MarioState.Left();
        }
        void Right()
        {
            MarioState.Right();
        }
        void Update()
        {
            MarioState.Update();
        }
        void Draw(SpriteBatch spriteBatch);
    }
}