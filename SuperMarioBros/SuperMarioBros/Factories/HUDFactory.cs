using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Factories
{
    class HUDFactory
    {

        private static readonly HUDFactory instance = new HUDFactory();
        public SpriteFont spriteFont { get; private set; }
       

        public static HUDFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private HUDFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("HUD");
           
        }

       
    }
}
