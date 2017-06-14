using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Bloodlust
{
    public class Map
    {
        Tile[,] tileMap;
        public int mapWidth = 100;
        public int mapHeight = 100;
        public Texture2D genericTile;
        public Texture2D dirtTile;
        public Texture2D stoneTile;
        public Texture2D waterTile;


        public void Load(ContentManager Content)
        {
            genericTile = Content.Load<Texture2D>("Tile64");

            GenerateMap();
        }
        public void GenerateMap()
        {
            tileMap = new Tile[mapWidth, mapHeight];
            SimplexNoise1 noise = new SimplexNoise1();
            noise.setSeed(345347);
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    tileMap[x, y] = new Tile();
                    tileMap[x, y].position = new Vector2(x * 64, y * 64);
                    
                    float h = noise.getPerlinNoise(x, y, 100, 64);
                    if (h >= 60)
                    {
                        //is mountain
                        tileMap[x, y].type = TileType.Stone;
                    }
                    else if (h >= 45)
                    {
                        //is dirt
                        tileMap[x, y].type = TileType.Dirt;
                        SimplexNoise1 treeNoise = new SimplexNoise1(); //make tree stuff
                    }
                    else if (h >= 0)
                    {
                        //is water
                        tileMap[x, y].type = TileType.Water;
                    } 
                }
            }
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    switch (tileMap[x, y].type)
                    {
                        case TileType.Dirt:
                            spriteBatch.Draw(genericTile, tileMap[x, y].position, Color.SaddleBrown);
                            break;

                        case TileType.Water:
                            spriteBatch.Draw(genericTile, tileMap[x, y].position, Color.Blue);
                            break;

                        case TileType.Stone:
                            spriteBatch.Draw(genericTile, tileMap[x, y].position, Color.Pink);
                            break;
          
                    }

                }
            }
        }

    }
}
