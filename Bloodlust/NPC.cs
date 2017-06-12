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
    public class NPC
    {

        List<Enemy> NPCs = new List<Enemy>();
        public int batchNumber;                       // will be used to specify how many NPCs are spawned in this location batch
        public Color colour;
        Random random = new Random();
        Rectangle NPCLocation = new Rectangle();


        //will create a NPC Location rectangle in which NPCs reside when not patrolling
        public void CreateNPCLocation(int OriginX, int OriginY, int Width, int Height)
        {

            //much better code can be written here once the map is working
            //which will set the npc rectangle  
            Rectangle rect = new Rectangle(OriginX, OriginY, Width, Height);
            NPCLocation = rect;
        }

        //return a random location within the NPC Location rectangle
        private Vector2 NPCPosition()
        {
            int PositionX = random.Next(NPCLocation.X, NPCLocation.X + NPCLocation.Width);
            int PositionY = random.Next(NPCLocation.Y, NPCLocation.Y + NPCLocation.Height);

            return new Vector2(PositionX, PositionY);
        }

        //Spawns an enemy and adds to list of enemies call NPCs
        private void SpawnEnemy(ContentManager Content)
        {
            Enemy enemy = new Enemy();
            enemy.Load(Content, "Tile32", 1, 0);
            enemy.Position = NPCPosition();
            enemy.speed = 
            enemy.sprite.colour = colour;
            NPCs.Add(enemy);
        }
      

        public void Load(ContentManager Content)
        {
            
            for (int NPCBatchIdx = 0; NPCBatchIdx < batchNumber; NPCBatchIdx++)
            {
                SpawnEnemy(Content);
            }

        }

        public void Update(float deltaTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy NPC in NPCs)
            {
                NPC.Draw(spriteBatch);
            }
        }
    }
}
