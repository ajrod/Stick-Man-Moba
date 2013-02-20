using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Side_Scrolling_StickMen
{
    public class ScreenManager
    {
        //The screens and the current screen
        ControllerDetectScreen mControllerScreen;
        TitleScreen mTitleScreen;
        Screen mCurrentScreen;
        Screen mOldScreen = null;
        LoadingScreen mLoadingScreen;
        MainGameScreen mMainGameScreen;
        GameMenuScreen mGameMenuScreen;

        public ScreenManager()
        {
            //Initialize the various screens in the game
            mControllerScreen = new ControllerDetectScreen(new EventHandler(ControllerDetectScreenEvent));
            mTitleScreen = new TitleScreen(new EventHandler(TitleScreenEvent));
            mLoadingScreen = new LoadingScreen(new EventHandler(LoadScreenEvent));
            mMainGameScreen = new MainGameScreen(new EventHandler(MainGameScreenEvent));
            mGameMenuScreen = new GameMenuScreen(new EventHandler(GameMenuScreenEvent));
            //Set the current screen
            mCurrentScreen = mControllerScreen;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (mOldScreen != null && mOldScreen.fadingOut)
            {
                mOldScreen.Draw(spriteBatch);
            }
            mCurrentScreen.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (mOldScreen != null && mOldScreen.fadingOut)
            {
                mOldScreen.Update(gameTime);
            }
            mCurrentScreen.Update(gameTime);
        }

        //This event fires when the Controller detect screen is returning control back to the title screen
        private void ControllerDetectScreenEvent(object obj, EventArgs e)
        {
            //Switch to the title screen, the Controller detect screen is finished being displayed
            screenTansition(mTitleScreen, false, false);
        }

        private void GameMenuScreenEvent(object obj, EventArgs e)
        {
            GameMenuScreen m = (GameMenuScreen)obj;
            switch (m.selectionIndex)
            {   //continue
                case 0:
                    Screen s = mCurrentScreen;
                    s.startFadingOut();
                    MainGameScreen mg = (MainGameScreen)mOldScreen;
                    mg.pause = false;
                    mCurrentScreen = mg;
                    mOldScreen = s;
                    MetaGame.metaGame.IsMouseVisible = true;
                    break;
                //options
                case 1:
                    break;
                //Exit game - add a prompt?
                case 2:
                    screenTansition(mTitleScreen, false, false);
                    break;
                default:
                    break;
            }
        }

        private void screenTansition(Screen newScreen, bool fadeOut = true, bool fadeIn = true)
        {
            mOldScreen = mCurrentScreen;
            if (fadeOut) mOldScreen.startFadingOut();

            mCurrentScreen = newScreen;
            mCurrentScreen.Reset();
            if (fadeIn) mCurrentScreen.startFadingIn();
        }

        private void MainGameScreenEvent(object obj, EventArgs e)
        {
            MainGameScreen m = (MainGameScreen)obj;
            m.pause = true;
            mOldScreen = mCurrentScreen;
            mGameMenuScreen.Reset();
            mCurrentScreen = mGameMenuScreen;
            MetaGame.metaGame.IsMouseVisible = false;
            mCurrentScreen.startFadingIn();
        }

        //This event is fired when the Title screen is returning control back to the main game class
        private void TitleScreenEvent(object obj, EventArgs e)
        {
            TitleScreen titleScreen = (TitleScreen)obj;
            switch (titleScreen.selectionIndex)
            {   //play game
                case 0:
                    screenTansition(mLoadingScreen);
                    break;
                //options
                case 1:
                    break;
                //Exit game - add a prompt?
                case 2:
                    MetaGame.metaGame.Exit();
                    break;
                default:
                    break;
            }
        }

        //This event is fired when the Load screen is returning control back to the main game class
        private void LoadScreenEvent(object obj, EventArgs e)
        {
            //Level.Reset();
            MetaGame.metaGame.IsMouseVisible = true;
            screenTansition(mMainGameScreen);
        }
    }
}