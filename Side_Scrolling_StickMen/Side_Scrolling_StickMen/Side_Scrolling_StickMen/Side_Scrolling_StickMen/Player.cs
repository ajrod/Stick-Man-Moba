using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class Player
    {
        public KeyboardState currentKeyboardState;
        public KeyboardState previousKeyboardState;
        public MouseState currentMouseState;
        public MouseState previousMouseState;

        public Player()
        {

        }

        public void Update()
        {
            checkKeyboard();
            checkMouse();
        }

        public void checkKeyboard()
        {

        }

        public void checkMouse()
        {

        }
    }
}
