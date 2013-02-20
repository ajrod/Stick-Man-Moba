using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class Screen
    {
        //Stores the PlayerIndex for the controlling player, i.e. Player One
        protected static PlayerIndex PlayerOne;
        public String menuTitle = "Main Menu";
        public SpriteFont MenuFont;
        public bool hasMenu = false;
        public int selectionIndex = -1;
        public float TransitionAlpha = 0;
        public float TransitionPosition = 1.0f;
        public List<MenuEntry> menuEntries;
        public float selectionDelayCt = 300;
        public float SelectionDelay = 150;
        public const float TOTAL_FADE_TIME = 500;
        public float FadeTime = TOTAL_FADE_TIME;
        public float Fade = 1.0f;
        public bool fadingOut = false;
        public bool fadingIn = false;
        public Color backGroundTint = Color.White;

        //The event associated with the Screen. This event is used to raise events
        //back in the main game class to notify the game that something has changed
        //or needs to be changed
        protected EventHandler ScreenEvent;

        public virtual void Reset()
        {
            this.TransitionAlpha = 0;
            this.TransitionPosition = 1.0f;
            this.selectionDelayCt = 300;
            this.FadeTime = TOTAL_FADE_TIME;
            this.Fade = 1.0f;
            this.fadingOut = false;
            this.fadingIn = false;
        }

        public void startFadingOut()
        {
            this.fadingOut = true;
            this.Fade = 1.0f;
            this.FadeTime = TOTAL_FADE_TIME;
        }

        public void startFadingIn()
        {
            this.fadingIn = true;
            this.Fade = 0;
            this.FadeTime = TOTAL_FADE_TIME;
        }

        public Screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
            MenuFont = MetaGame.content.Load<SpriteFont>("MenuFont");
            menuEntries = new List<MenuEntry>();
        }

        //Update any information specific to the screen
        public virtual void Update(GameTime theTime)
        {
            if (fadingOut)
            {
                this.FadeTime -= theTime.ElapsedGameTime.Milliseconds;
                this.Fade = this.FadeTime / TOTAL_FADE_TIME;
                if (this.Fade < 0)
                {
                    this.Fade = 0;
                    this.fadingOut = false;
                }
            }

            if (fadingIn)
            {
                this.FadeTime -= theTime.ElapsedGameTime.Milliseconds;
                this.Fade = 1 - this.FadeTime / TOTAL_FADE_TIME;
                if (this.Fade > 1)
                {
                    this.Fade = 1;
                    this.fadingIn = false;
                }
            }
            selectionDelayCt -= theTime.ElapsedGameTime.Milliseconds;
            if (TransitionPosition > 0)
            {
                TransitionPosition -= (theTime.ElapsedGameTime.Milliseconds / 1000f + (float)Math.Pow(100, TransitionPosition) / 1000f);
            }

            if (TransitionPosition < 0)
            {
                TransitionPosition = 0;
            }
            TransitionAlpha = 1 - TransitionPosition;
        }

        public virtual void checkMenuInput()
        {
            if (!hasMenu || this.selectionDelayCt > 0 || this.fadingOut || this.fadingIn) return;
            KeyboardState State = Keyboard.GetState();
            MouseState MState = Mouse.GetState();

            if (State.IsKeyDown(Keys.W) || State.IsKeyDown(Keys.Up))
            {
                this.menuEntries[selectionIndex].isSelected = false;
                this.selectionIndex -= 1;
                if (selectionIndex < 0) { selectionIndex = this.menuEntries.Count - 1; }
                this.menuEntries[selectionIndex].isSelected = true;
                this.selectionDelayCt = this.SelectionDelay;
            }

            else if (State.IsKeyDown(Keys.S) || State.IsKeyDown(Keys.Down))
            {
                this.menuEntries[selectionIndex].isSelected = false;
                this.selectionIndex += 1;
                if (selectionIndex >= this.menuEntries.Count) { selectionIndex = 0; }
                this.menuEntries[selectionIndex].isSelected = true;
                this.selectionDelayCt = this.SelectionDelay;
            }
            else if (State.IsKeyDown(Keys.Space) || State.IsKeyDown(Keys.Enter))
            {
                Enter(MState);
            }
        }

        public virtual void Enter(MouseState MState)
        {
            ScreenEvent.Invoke(this, new EventArgs());
            this.selectionDelayCt = this.SelectionDelay;
        }

        public void drawMenuEntries(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < menuEntries.Count; i++)
            {
                menuEntries[i].Draw(spriteBatch);
            }
        }

        //Draw any objects specific to the screen
        public virtual void Draw(SpriteBatch theBatch)
        {
        }

        protected virtual void UpdateMenuEntry(GameTime gameTime)
        {
            // Make the menu slide into place during transitions, using a
            // power curve to make things look more interesting (this makes
            // the movement slow down as it nears the end).
            float transitionOffset = (float)Math.Pow(TransitionPosition, 2);

            // start at Y = 175; each X value is generated per entry
            Vector2 position = new Vector2(0f, 175f);

            // update each menu entry's location in turn
            for (int i = 0; i < menuEntries.Count; i++)
            {
                MenuEntry menuEntry = menuEntries[i];

                // each entry is to be centered horizontally
                position.X = MetaGame.RESOLUTION_WIDTH / 2 - menuEntry.GetWidth() / 2;

                if (this.TransitionPosition > 0)
                    position.X -= transitionOffset * 256 * 2;
                else
                    position.X += transitionOffset * 512 * 2;

                // set the entry's position
                menuEntry.position = position;

                // move down for the next entry the size of this entry
                position.Y += menuEntry.GetHeight();
                menuEntries[i].Update(gameTime);
            }
        }
    }
}