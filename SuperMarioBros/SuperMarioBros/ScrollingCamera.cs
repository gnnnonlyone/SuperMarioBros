
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNewBee.WorldLevel;
namespace SuperMarioBros
{
    public static class ScrollingCamera
    {
        
        public static Matrix scrollingCamera()
        {
            Matrix Camera = new Matrix();
            //World world = new World(100,100);
            //int width;
            //int ObjectWidth = 16;
            //width = 450;
            Camera = CameraMoving();
            //Camera = CameraStaying(); Not use in this case, Save 
            return Camera;
        }
        public static Matrix CameraMoving()
        {
            //private GraphicsDevice graphics ;
            //World world = new World(208, 16);
            Matrix Camera;
            float marioWidth = TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Viewport.Width;
            float marioHeight = TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Viewport.Height;
            float worldWidth = World.Instance.Width;
            float pX = World.Instance.Mario.MarioPhysics.Position.X;
            float x;
            float y;
            float z;
            float a;
            float b;
            float c;
            
            int objectWidth = Constant.Constant.Instance.ObjectWidth;
            if (pX <= marioWidth/2)
            {
                x = -marioWidth/2;
                y =  marioHeight/ 2 - Constant.Constant.Instance.BoundaryY;
                z = Constant.Constant.Instance.CameraCoordinateInitial;
                a = marioWidth * 0.5f;
                b = marioHeight * 0.5f;
                c = Constant.Constant.Instance.CameraCoordinateInitial;
            }
            else if (pX >= worldWidth * objectWidth - marioWidth/2)
            {
                x = -worldWidth * objectWidth + marioWidth / 2;
                y = marioHeight / 2 - Constant.Constant.Instance.BoundaryY;
                z = Constant.Constant.Instance.CameraCoordinateInitial;
                a = marioWidth * 0.5f;
                b = marioHeight * 0.5f;
                c = Constant.Constant.Instance.CameraCoordinateInitial;
            }
            else
            {
                x = -pX;
                y = marioHeight / 2 - Constant.Constant.Instance.BoundaryY;
                z = Constant.Constant.Instance.CameraCoordinateInitial;
                a = marioWidth * 0.5f;
                b = marioHeight * 0.5f;
                c = Constant.Constant.Instance.CameraCoordinateInitial; 
            }
            //Matrix Camera = Matrix.CreateTranslation(x, y, z);
            Camera = Matrix.CreateTranslation(new Vector3(x, y, z)) * Matrix.CreateTranslation(new Vector3(a, b, c));
            return Camera;
        }
        public static Matrix CameraStaying()
        {
            Matrix Camera;
            float marioWidth = TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Viewport.Width;
            float marioHeight = TreeNewBee.SuperMarioBros.Instance.GraphicsDevice.Viewport.Height;
            float worldWidth = World.Instance.Width;
            float pX = World.Instance.Mario.MarioPhysics.Position.X;
            float x;
            float y;
            float z;
            float a;
            float b;
            float c;

            int objectWidth = Constant.Constant.Instance.ObjectWidth;
            if (pX <= marioWidth / 2)
            {
                x = -marioWidth/2;
                y = marioHeight / 2 - Constant.Constant.Instance.BoundaryY;
                z = Constant.Constant.Instance.CameraCoordinateInitial;
                a = marioWidth * 0.5f;
                b = marioHeight * 0.5f;
                c = Constant.Constant.Instance.CameraCoordinateInitial;

            }
            else if (pX >= worldWidth * objectWidth - marioWidth / 2)
            {
                x = -worldWidth * objectWidth + marioWidth / 2;
                y = marioHeight / 2 - Constant.Constant.Instance.BoundaryY;
                z = Constant.Constant.Instance.CameraCoordinateInitial;
                a = marioWidth * 0.5f;
                b = marioHeight * 0.5f;
                c = Constant.Constant.Instance.CameraCoordinateInitial;

            }
            else
            {
                x = -pX;
                y = marioHeight / 2 - Constant.Constant.Instance.BoundaryY;
                z = Constant.Constant.Instance.CameraCoordinateInitial;
                a = marioWidth * 0.5f;
                b = marioHeight * 0.5f;
                c = Constant.Constant.Instance.CameraCoordinateInitial;

            }
            //Matrix Camera = Matrix.CreateTranslation(x, y, z);
            Camera = Matrix.CreateTranslation(new Vector3(x, y, z)) * Matrix.CreateTranslation(new Vector3(a, b, c));
            return Camera;
        }
        

    }
}
