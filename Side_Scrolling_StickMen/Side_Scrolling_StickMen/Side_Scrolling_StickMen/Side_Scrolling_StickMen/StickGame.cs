using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Side_Scrolling_StickMen
{
    public class StickGame
    {
        public Player player;

        public StickGame()
        {
            LoadContent();
        }

        public void LoadContent()
        {
            player = new Player(new Sprite("StickManBasic"), new Vector2(200,200));
        }
        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.draw(spriteBatch);
        }
    }
}
