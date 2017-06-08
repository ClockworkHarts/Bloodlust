using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Bloodlust
{
    

    class Tile
    {
        public enum TileType { Dirt, Stone, Water };

        Sprite sprite = new Sprite();
        Texture2D texture = null;

        public Vector2 Position
        {
            get
            {
                return sprite.position;
            }

            set
            {
                sprite.position = value;
            }
        }

        public void Load(ContentManager Content)
        {
           
        }

    }
}
