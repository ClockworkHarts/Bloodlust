using System;
using System.Collections;
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

        Tree[,] treeMap;
        public Texture2D pineTexture;
        public Texture2D oakTexture;
        public Texture2D spruceTexture;
        public Texture2D cedarTexture;



        public void Load(ContentManager Content)
        {
            genericTile = Content.Load<Texture2D>("Tile64");

            GenerateMap();
        }
        public void GenerateMap()
        {
            tileMap = new Tile[mapWidth, mapHeight];
            SimplexNoise1 noise = new SimplexNoise1();
            noise.setSeed(531594);
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    tileMap[x, y] = new Tile();
                    tileMap[x, y].position = new Vector2(x * 64, y * 64);
                    
                    float h = noise.getPerlinNoise(x, y, 100, 64);
                    if (h >= 58)
                    {
                        //is mountain
                        tileMap[x, y].type = TileType.Stone;
                    }
                    else if (h >= 35)
                    {
                        //is dirt
                        tileMap[x, y].type = TileType.Dirt;

                        //making da trees
                        /*treeMap = new Tree[mapWidth, mapHeight];
                        SimplexNoise1 treeNoise = new SimplexNoise1();
                        treeNoise.setSeed(515438);
                        for (int xtree = 0; xtree < mapHeight; xtree++)
                        {
                            for (int ytree = 0; ytree < mapWidth; ytree++)
                            {
                                treeMap[xtree, ytree] = new Tree();
                                treeMap[xtree, ytree].position = new Vector2(((xtree * 64) - 32), ((ytree * 64) - 32));

                                float i = treeNoise.getPerlinNoise(xtree, ytree, 100, 128);
                                if (i >= 80)
                                {
                                    treeMap[xtree, ytree].type = TreeType.Cedar;
                                }

                                if (i >= 60)
                                {
                                    treeMap[xtree, ytree].type = TreeType.Oak;
                                }

                                if (i >= 40)
                                {
                                    treeMap[xtree, ytree].type = TreeType.Pine;
                                }

                                if (i >= 20)
                                {
                                    treeMap[xtree, ytree].type = TreeType.Spruce;
                                }
                            }
                        }*/
                        
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

            /*for (int xtree = 0; xtree < mapWidth; xtree++)
            {
                for (int ytree = 0; ytree < mapHeight; ytree++)
                {
                    switch (treeMap[xtree, ytree].type)
                    {
                        case TreeType.Cedar:
                            spriteBatch.Draw(genericTile, treeMap[xtree, ytree].position, Color.GreenYellow);
                            break;

                        case TreeType.Oak:
                            spriteBatch.Draw(genericTile, treeMap[xtree, ytree].position, Color.LawnGreen);
                            break;

                        case TreeType.Pine:
                            spriteBatch.Draw(genericTile, treeMap[xtree, ytree].position, Color.ForestGreen);
                            break;

                        case TreeType.Spruce:
                            spriteBatch.Draw(genericTile, treeMap[xtree, ytree].position, Color.Green);
                            break;
                    }
                }
            }*/
        }

    }
}
