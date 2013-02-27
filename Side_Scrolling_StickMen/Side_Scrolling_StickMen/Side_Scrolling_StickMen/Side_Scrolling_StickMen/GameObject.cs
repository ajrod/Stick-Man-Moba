using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Side_Scrolling_StickMen
{
    public class GameObject
    {
        public Vector2 position;
        public Sprite sprite;
        public float scale = 1;
        public float speed;
        public float angle;
        public float radius;
        public double maxHP = 1;
        public double curHP = 1;
        public int turnDir = 0;
        // Boolean deciding if the Object should be drawn or not
        public bool toDraw = true;

        public GameObject(Sprite sprite, Vector2 position)
        {
            this.position = position;
            this.sprite = sprite;
            speed = 100;
        }


        public void setHealth(double maxHP)
        {
            this.maxHP = maxHP;
            this.curHP = maxHP;
        }

        public virtual void Update(GameTime gameTime)
        {
            move(gameTime.ElapsedGameTime.Milliseconds / 1000f);
        }

        public void Animate()
        {
        }


        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (toDraw)
            {
                sprite.draw(spriteBatch, position, -angle);
            }
        }

        public virtual void  applyGravity(float time)
        {
            this.position.Y += 0;
        }

        public void move(float time)
        {
            this.position.X += turnDir * speed * time ;
            //this.position.Y += ...
            applyGravity(time);
        }
    }
}
