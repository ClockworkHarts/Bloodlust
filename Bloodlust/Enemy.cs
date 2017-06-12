﻿using System;
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
    class Enemy
    {
        public enum EnemyState { Idle, Patrol, Action, Asleep}

        public Sprite sprite = new Sprite();

        public Vector2 velocity = Vector2.Zero;
        public float speed = 0f;
        public Vector2 scale = new Vector2(1, 1);
        public float combatRadius = 0f;
        public float detectionRadius = 0f;
        public Vector2 Position
        {
            get { return sprite.position; }
            set { sprite.position = value; }
        }

        public Rectangle Bounds
        {
            get { return sprite.Bounds; }
        }

        public float CombatRadius()
        {
            float enemyRadius = Math.Min(Bounds.Height, Bounds.Width);
            return enemyRadius + combatRadius;
        }

        public float DetectionRadius()
        {
            float enemyRadius = Math.Min(Bounds.Height, Bounds.Width);
            return enemyRadius + detectionRadius;
        }


        public void Load(ContentManager Content, string texture, int frameCount, int framesPerSec)
        {
            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, scale, 1);
            animation.Load(Content, texture, frameCount, framesPerSec);
            sprite.Add(animation);
        }

        

        public void Update(float deltaTime)
        {
            sprite.Update(deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }


    }
}
