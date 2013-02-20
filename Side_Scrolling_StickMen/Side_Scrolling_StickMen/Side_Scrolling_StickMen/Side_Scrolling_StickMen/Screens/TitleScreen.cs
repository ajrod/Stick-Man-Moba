using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class TitleScreen : Screen
    {
        //Background texture for the Title screen
        public Texture2D background;

        public TitleScreen(EventHandler theScreenEvent)
            : base(theScreenEvent)
        {
            //Load the background texture for the screen
            background = MetaGame.content.Load<Texture2D>("Screens/ControllerDetectScreen");
            // Create our menu entries.
            MenuEntry playGameMenuEntry = new MenuEntry(this, "Play Game");
            MenuEntry optionsMenuEntry = new MenuEntry(this, "Options");
            MenuEntry exitMenuEntry = new MenuEntry(this, "Exit");
            // Add entries to the menu.
            menuEntries.Add(playGameMenuEntry);
            menuEntries.Add(optionsMenuEntry);
            menuEntries.Add(exitMenuEntry);
            this.hasMenu = true;
            this.selectionIndex = 0;
            this.menuEntries[0].isSelected = true;
        }

        //Update all of the elements that need updating in the Title Screen
        public override void Update(GameTime theTime)
        {
            //Check to see if the Player one controller has pressed the "B" button, if so, then
            //call the screen event associated with this screen
            if (GamePad.GetState(PlayerOne).Buttons.B == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                ScreenEvent.Invoke(this, new EventArgs());
            }
            checkMenuInput();
            UpdateMenuEntry(theTime);
            base.Update(theTime);
        }

        //Draw all of the elements that make up the Title Screen
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(background, Vector2.Zero, this.backGroundTint * this.Fade);

            // Draw the menu title centered on the screen
            Vector2 titlePosition = new Vector2(MetaGame.RESOLUTION_WIDTH / 2, 80 - 200 * TransitionPosition);
            Vector2 titleOrigin = MenuFont.MeasureString(menuTitle) / 2;
            Color titleColor = new Color(192, 192, 192) * TransitionAlpha * this.Fade;
            float titleScale = 1.25f;

            theBatch.DrawString(MenuFont, menuTitle, titlePosition, titleColor, 0,
                                   titleOrigin, titleScale, SpriteEffects.None, 0);
            drawMenuEntries(theBatch);
            base.Draw(theBatch);
        }
    }
}