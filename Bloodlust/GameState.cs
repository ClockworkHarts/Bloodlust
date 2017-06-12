using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;using MonoGame.Extended.ViewportAdapters;using MonoGame.Extended;

namespace Bloodlust
{
    public class GameState : AIE.State
    {
        public static GameState current;

        //GameState variables
        bool isLoaded = false;
        SpriteFont font = null;

        //general

        //player
        public Player player = new Player();

        //NPCs
        List<NPC> Batches = new List<NPC>();
        

        //tiles 
        public Texture2D dirtTile;
        public Texture2D stoneTile;
        public Texture2D waterTile;

        //public gamewide variables
        public static float tile = 64;
        public static float meter = tile;
        public static Vector2 maxVelocity = new Vector2(meter * 15, meter * 15);
        public static float acceleration = (maxVelocity.X * 2);
        public static float friction = (maxVelocity.X * 8);
        public float deltaTime;

        //debugging stuff
        Texture2D debugMap;

        
        public GameState() : base()
        {
            current = this;
        }

        private void LoadNPCs(int numberOfNPCs, int RectX, int RectY, int RectWidth, int RectHeight, Color colour)
        {
            NPC Batch = new NPC();
            Batch.batchNumber = numberOfNPCs;
            Batch.CreateNPCLocation(RectX, RectY, RectWidth, RectHeight);
            Batch.colour = colour;
            Batches.Add(Batch);

        }

        

        public override void Update(ContentManager Content, GameTime gameTime)
        {

            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (isLoaded == false)
            {
                isLoaded = true;

                //general
                font = Content.Load<SpriteFont>("Arial");

                //player
                player.Load(Content);
                player.Position = new Vector2(10, 10);
                player.scale = new Vector2(1000, 1000);

                //NPCs
                LoadNPCs(5, 10, 10, 300, 300, Color.Blue);
                LoadNPCs(3, 400, 400, 300, 300, Color.Green);
                
                foreach(NPC B in Batches)
                {
                    B.Load(Content);
                }
                

                //debugging
                debugMap = Content.Load<Texture2D>("maria");


            }

            player.Update(deltaTime);
            Game1.current.camera.Position = player.Position - new Vector2(Game1.current.ScreenWidth / 2, Game1.current.ScreenHeight / 2);


            //if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            //{
            //    AIE.StateManager.ChangeState("GAMEOVER");
            //}

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            var t = Game1.current.camera.GetViewMatrix();
            //here i am drawing in random noise to see if you can still see the player movement 
            //but we need to draw the map we generate in here


            spriteBatch.Begin(transformMatrix : t);
            //spriteBatch.DrawString(font, "Game State", new Vector2(200, 200), Color.White);
            spriteBatch.Draw(debugMap, new Vector2(0, 0), Color.White);

            player.Draw(spriteBatch);

            foreach(NPC B in Batches)
            {
                B.Draw(spriteBatch);
            }

            spriteBatch.End();

            //GUI below
            spriteBatch.Begin();
            
            spriteBatch.End();
        }

        public override void CleanUp()
        {
            font = null;
            isLoaded = false;
        }
    }
}
