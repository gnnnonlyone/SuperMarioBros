using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Props;
using System.Collections.Generic;

namespace TreeNewBee.Interfaces
{
    public interface IWorld
    {
        int Width { get;  }
        int Height { get; }
        IList<IItem> ItemList { get;}
        IList<IEnemy> EnemyList { get;}
        IList<IScenery> SceneryList { get; }
        IList<IProps> FireballList { get; }
        IList<IProps> PropsList { get; }
        IMario Mario { get; set; }
        IBlock[][] Blocks { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);

    }
}
