using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class MainGameScreen : Screen
    {
        public bool pause = false;
        public StickGame stickGame;

        public MainGameScreen(EventHandler theScreenEvent)
            : base(theScreenEvent)
        {
            stickGame = new StickGame();
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
            stickGame.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            stickGame.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}