using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Side_Scrolling_StickMen
{
    public class StickGame
    {
        public Player player;
        public static WorldObject floor;
        public static Vector2 viewOffset;


        public StickGame()
        {
            LoadContent();
        }

        public void LoadContent()
        {
            player = new Player(new Sprite("StickManBasic"), new Vector2(200, 200));
            floor = new WorldObject(new Sprite("FakeFloor"), new Vector2(0, 600));
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            //player.Offset(playerTranslation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            setViewOffset();
            floor.draw(spriteBatch);
            player.draw(spriteBatch);
        }

        public void setViewOffset()
        {
            viewOffset.X = player.position.X - (MetaGame.RESOLUTION_WIDTH / 2);
            viewOffset.Y = player.position.Y - (MetaGame.RESOLUTION_HEIGHT / 2);
        }
    }
}