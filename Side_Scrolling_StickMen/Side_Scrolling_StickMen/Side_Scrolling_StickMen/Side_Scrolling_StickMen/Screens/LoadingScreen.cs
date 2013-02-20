using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Side_Scrolling_StickMen
{
    public class LoadingScreen : Screen
    {
        bool loadingIsSlow;
        public float fakeLoadCounter = 3.5f;

        public LoadingScreen(EventHandler theScreenEvent, bool loadingIsSlow = false)
            : base(theScreenEvent)
        {
            this.loadingIsSlow = loadingIsSlow;
            //TransitionOnTime = TimeSpan.FromSeconds(0.5);
        }

        public override void Reset()
        {
            fakeLoadCounter = 3.5f;
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            if (!loadingIsSlow) fakeLoadCounter = 0;
            fakeLoadCounter -= gameTime.ElapsedGameTime.Milliseconds / 1000f;

            if (fakeLoadCounter <= 0)
            {
                ScreenEvent.Invoke(this, new EventArgs());
            }
            base.Update(gameTime);
            //LOAD STUFF
            //...
            //...
            ///END LOAD

            // Use if load is going to take a significant amount of time
            //Reduces overhead lag
            //Game1.game.ResetElapsedTime();
        }

        /// <summary>
        /// Draws the loading screen.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            // The gameplay screen takes a while to load, so we display a loading
            // message while that is going on, but the menus load very quickly, and
            // it would look silly if we flashed this up for just a fraction of a
            // second while returning from the game to the menus. This parameter
            // tells us how long the loading is going to take, so we know whether
            // to bother drawing the message.
            if (loadingIsSlow)
            {
                const string message = "Loading...";

                // Center the text in the viewport.
                SpriteFont font = MetaGame.content.Load<SpriteFont>("gameFont");
                Vector2 viewportSize = new Vector2(MetaGame.RESOLUTION_WIDTH, MetaGame.RESOLUTION_HEIGHT);
                Vector2 textSize = font.MeasureString(message);
                Vector2 textPosition = (viewportSize - textSize) / 2;

                Color color = Color.White * TransitionAlpha * this.Fade;

                spriteBatch.DrawString(font, message, textPosition, color);
            }
        }
    }
}