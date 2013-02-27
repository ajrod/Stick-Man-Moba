﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class Player : GameObject
    {
        public KeyboardState currentKeyboardState;
        public KeyboardState previousKeyboardState;
        public MouseState currentMouseState;
        public MouseState previousMouseState;


        public Player(Sprite sprite, Vector2 position) : base(sprite, position)
        {
           
        }

        public override void Update(GameTime gameTime)
        {
            checkKeyboard();
            checkMouse();
            base.Update(gameTime);
        }

        public void checkKeyboard()
        {
            currentKeyboardState = Keyboard.GetState();
            //Moves the player to the right
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                this.position.X += 5;
            }
            //Moves the player to the left
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                this.position.X -= 5;
            }
            previousKeyboardState = currentKeyboardState;
        }

        public void checkMouse()
        {

        }
    }
}
