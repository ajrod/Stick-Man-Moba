using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class ControllerDetectScreen : Screen
    {
        //Background texture for the screen
        Texture2D mControllerDetectScreenBackground;
        SpriteFont font;
        public const string message = "Press any key to continue...";

        public ControllerDetectScreen(EventHandler theScreenEvent)
            : base(theScreenEvent)
        {
            //Load the background texture for the screen

            mControllerDetectScreenBackground = MetaGame.content.Load<Texture2D>("Screens/ControllerDetectScreen");
            font = MetaGame.content.Load<SpriteFont>("StartUpFont");
            MetaGame.metaGame.IsMouseVisible = false;
        }

        //Update all of the elements that need updating in the Controller Detect Screen
        public override void Update(GameTime theTime)
        {
            //Poll all the gamepads (and the keyboard) to check to see
            //which controller will be the player one controller. When the controlling
            //controller is detected, call the screen event associated with this screen
            for (int aPlayer = 0; aPlayer < 4; aPlayer++)
            {
                if (GamePad.GetState((PlayerIndex)aPlayer).Buttons.A == ButtonState.Pressed || Keyboard.GetState().GetPressedKeys().Length > 0)
                {
                    PlayerOne = (PlayerIndex)aPlayer;
                    if (this.fadingOut || this.fadingIn) return;
                    ScreenEvent.Invoke(this, new EventArgs());
                    return;
                }
            }

            base.Update(theTime);
        }

        //Draw all of the elements that make up the Controller Detect Screen
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(mControllerDetectScreenBackground, Vector2.Zero, Color.White * this.Fade);
            theBatch.DrawString(font, message, new Vector2(MetaGame.RESOLUTION_WIDTH / 2 - font.MeasureString(message).X / 2, MetaGame.RESOLUTION_HEIGHT - 35), Color.DarkGray * this.Fade);
            base.Draw(theBatch);
        }
    }
}