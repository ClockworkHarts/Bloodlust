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
    class NPC
    {

        public enum NPCState { Idle, Patrol, Attack, Asleep}
        

        List<Enemy> NPCs = new List<Enemy>();
        Random random = new Random();
        Vector2 mapSize = Vector2.Zero;


      

        public void Load(ContentManager Content)
        {
            

        }

        public void Update(float deltaTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
