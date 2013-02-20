using System;

namespace Side_Scrolling_StickMen
{
    public class GameMenuScreen : TitleScreen
    {
        public GameMenuScreen(EventHandler screenEvent)
            : base(screenEvent)
        {
            this.menuEntries[0].text = "Continue";
            this.menuEntries[2].text = "Quit Game";
        }
    }
}