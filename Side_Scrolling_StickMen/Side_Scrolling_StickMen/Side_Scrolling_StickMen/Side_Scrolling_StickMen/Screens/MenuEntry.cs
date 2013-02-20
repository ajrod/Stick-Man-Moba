using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Side_Scrolling_StickMen
{
    public class MenuEntry
    {
        public Vector2 position;

        public bool isSelected = false;

        public Screen screen;

        public float selectionFade = 0;

        public String text;
        public Color deselectedColor = new Color(192, 192, 192);

        public MenuEntry(Screen parentScreen, String text)
        {
            this.screen = parentScreen;

            this.text = text;
        }

        //Draw any objects specific to the screen
        public virtual void Draw(SpriteBatch theBatch)
        {            // Draw the selected entry in yellow, otherwise white.
            Color color = isSelected ? Color.Yellow : deselectedColor;

            // Pulsate the size of the selected menu entry.
            double time = (int)DateTime.Now.Ticks / 10000000f;

            float pulsate = (float)Math.Sin(time * 6) + 1;

            float scale = 1 + pulsate * 0.05f * selectionFade;

            // Modify the alpha to fade text out during transitions.
            color *= screen.TransitionAlpha * screen.Fade;

            Vector2 origin = new Vector2(0, this.screen.MenuFont.LineSpacing / 2);

            theBatch.DrawString(this.screen.MenuFont, text, position, color, 0,
                                   origin, scale, SpriteEffects.None, 0);
        }

        //Update any information specific to the screen
        public virtual void Update(GameTime theTime)
        {            // When the menu selection changes, entries gradually fade between
            // their selected and deselected appearance, rather than instantly
            // popping to the new state.
            float fadeSpeed = (float)theTime.ElapsedGameTime.TotalSeconds * 4;

            if (isSelected)
                selectionFade = Math.Min(selectionFade + fadeSpeed, 1);
            else
                selectionFade = Math.Max(selectionFade - fadeSpeed, 0);
        }

        public virtual int GetHeight()
        {
            return screen.MenuFont.LineSpacing;
        }

        public virtual int GetWidth()
        {
            return (int)screen.MenuFont.MeasureString(text).X;
        }
    }
}