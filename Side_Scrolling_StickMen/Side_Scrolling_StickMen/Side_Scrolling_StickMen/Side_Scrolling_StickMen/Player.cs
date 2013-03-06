using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Side_Scrolling_StickMen
{
    public class Player : GameObject
    {
        public KeyboardState currentKeyboardState;
        public KeyboardState previousKeyboardState;
        public MouseState currentMouseState;
        public MouseState previousMouseState;

        public Player(Sprite sprite, Vector2 position)
            : base(sprite, position)
        {
            Polygon polygon = new Polygon();
            int width = 228;
            polygon.Points.Add(new Vector2(-width / 2, -width / 2));
            polygon.Points.Add(new Vector2(width / 2, -width / 2));
            polygon.Points.Add(new Vector2(width / 2, width / 2));
            polygon.Points.Add(new Vector2(-width / 2, width / 2));
            polygon.Offset(this.position);
            polygon.BuildEdges();
            this.setHitbox(polygon);
        }

        public override void Update(GameTime gameTime)
        {
            checkKeyboard();
            checkMouse();
            base.Update(gameTime);
        }

        public void checkKeyboard()
        {
            currentKeyboardState = Keyboard.GetState();
            //Moves the player to the right
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                turnDir = 1;
            }
            //Moves the player to the left
            else if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                turnDir = -1;
            }
            else
            {
                turnDir = 0;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Space))
            {
                this.position.Y = 0;
                this.hitbox.setPosition(this.position);
             
                this.velocity.Y = 0;

            }
            previousKeyboardState = currentKeyboardState;
        }

        public void checkMouse()
        {
        }
    }
}