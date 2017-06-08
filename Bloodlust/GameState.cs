using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Bloodlust
{
    public class GameState : AIE.State
    {
        public static GameState current;

        //GameState variables
        bool isLoaded = false;
        SpriteFont font = null;

        //player
        Player player = new Player();

        //images for all tiles 
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
        

        
        public GameState() : base()
        {
            
        }

        

        public override void Update(ContentManager Content, GameTime gameTime)
        {

            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (isLoaded == false)
            {
                isLoaded = true;
                font = Content.Load<SpriteFont>("Arial");
                player.Load(Content);
                player.Position = new Vector2(100, 100);
                player.scale = new Vector2(1000, 1000);


            }

            player.Update(deltaTime);


            //if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            //{
            //    AIE.StateManager.ChangeState("GAMEOVER");
            //}

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //spriteBatch.DrawString(font, "Game State", new Vector2(200, 200), Color.White);
            player.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void CleanUp()
        {
            font = null;
            isLoaded = false;
        }
    }
}
