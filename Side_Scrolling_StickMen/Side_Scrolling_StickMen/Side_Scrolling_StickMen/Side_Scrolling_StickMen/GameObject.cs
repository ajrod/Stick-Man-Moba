using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Side_Scrolling_StickMen
{
    public class GameObject
    {
        public Vector2 position;
        public Sprite sprite;
        public float scale = 1;
        public float angle;
        public float radius;
        public double maxHP = 1;
        public double curHP = 1;
        // Boolean deciding if the Object should be drawn or not
        public bool toDraw = true;

        public GameObject(Sprite sprite, Vector2 position)
        {
            this.position = position;
            this.sprite = sprite;
        }


        public void setHealth(double maxHP)
        {
            this.maxHP = maxHP;
            this.curHP = maxHP;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Animate()
        {
        }


        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (toDraw)
            {
                sprite.draw(spriteBatch, position, -angle);
            }
        }
    }
}
