using System;
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
        public GameObject player;

        public Player(Sprite sprite, Vector2 position) : base(sprite, position)
        {
           
        }

        public void Update()
        {
            checkKeyboard();
            checkMouse();
        }

        public void checkKeyboard()
        {
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                player.position.X += 1;
            }
            previousKeyboardState = currentKeyboardState;
        }

        public void checkMouse()
        {

        }
    }
}
