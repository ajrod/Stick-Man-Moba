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
    public class Sprite
    {
        public int numberOfFramesHeight;
        public int numberOfFramesWidth;
        public float scale = 1;
        public int frameWidth;
        public int frameHeight;
        public int currentFrameHeight;
        public int currentFrameWidth;
        public Texture2D picture;
        public Vector2 pivot;
        public Color tint = Color.White;
        public bool hasAnimation;
        public float delay;
        //Counter for the animation of a sprite
        public float counter = 0;

          public Sprite(String asset, int frameCountH = 1, int frameCountW = 1, float scale = 1, bool hasAnimation = false, float delay = 1)
        {
            this.scale = scale;
            this.picture =MetaGame.content.Load<Texture2D>(asset);
            this.numberOfFramesHeight = frameCountH;
            this.numberOfFramesWidth = frameCountW;
            this.frameWidth = picture.Width / frameCountW;
            this.frameHeight = picture.Height / frameCountH;
            this.pivot = new Vector2(frameWidth / 2, frameHeight / 2);
            this.hasAnimation = hasAnimation;
            this.delay = delay;
        }

        public void animate()
        {
            counter++;
            if (counter < delay)
            {
                return;
            }
            else
            {
                counter = 0;
            }
            if (!hasAnimation)
            {
                return;
            }
            currentFrameWidth += 1;
            if (currentFrameWidth == numberOfFramesWidth)
            {
                currentFrameWidth = 0;
                currentFrameHeight += 1;
            }
            if (currentFrameHeight == numberOfFramesHeight)
            {
                currentFrameHeight = 0;
                currentFrameWidth = 0;
            }
        }

        public void draw(SpriteBatch sprite, Vector2 drawLocation, float angle = 0)
        {
            Rectangle sourceRectangle = new Rectangle(frameWidth * currentFrameWidth, frameHeight * currentFrameHeight, frameWidth, frameHeight);
            sprite.Draw(picture, drawLocation - StickGame.viewOffset, sourceRectangle, tint, MathHelper.ToRadians(angle), pivot, scale, SpriteEffects.None, 1);
        }
    }
 }

