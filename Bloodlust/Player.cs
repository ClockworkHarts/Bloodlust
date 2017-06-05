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
    class Player
    {
        Sprite sprite = new Sprite();

        public Vector2 velocity = Vector2.Zero;
        public float speed = 0f;
        public Vector2 direction = Vector2.Zero;

        public Vector2 position
        {
            set
            {
                sprite.position = value;
            }

            get
            {
                return sprite.position;
            } 
        }

        public void Load(ContentManager Content)
        {

        }

        public void Update(float deltaTime)
        {
            UpdateInput(deltaTime);
            sprite.Update(deltaTime);
        }

        private void UpdateInput(float deltaTime)
        {
           if (Keyboard.GetState().IsKeyDown(Keys.W) == true)
            {

            }

           if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {

            }

           if (Keyboard.GetState().IsKeyDown(Keys.S) == true)
            {

            }

           if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {

            }
        

        }

       public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    
     }     
    

}

    

