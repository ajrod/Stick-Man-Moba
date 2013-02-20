using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class MainGameScreen : Screen
    {
        public bool pause = false;

        public MainGameScreen(EventHandler theScreenEvent)
            : base(theScreenEvent)
        {
        }

        public void checkGlobalInput()
        {
            if (selectionDelayCt > 0) return;
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Escape))
            {
                ScreenEvent.Invoke(this, new EventArgs());
                this.selectionDelayCt = this.SelectionDelay;
            }
        }

        public override void Reset()
        {
            pause = false;
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            checkGlobalInput();
            if (pause) return;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}