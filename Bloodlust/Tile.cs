using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework;

namespace Bloodlust
{
    public enum TileType { Dirt, Stone, Water };
    class Tile
    {
        Sprite sprite = new Sprite();

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

    }
}
